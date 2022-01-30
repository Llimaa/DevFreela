using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class LoginUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnLoginUserViewModel()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            authServiceMock.Setup(au => au.ComputeSha256Hash("LIma@gmail123")).Returns("asdfsdfdfdfdfdfd");
            var passwordHash = authServiceMock.Object.ComputeSha256Hash("LIma@gmail123");

            var user = new User("Marcos Lima", "lima@gmail.com", DateTime.Now.AddYears(-10), passwordHash);

            userRepositoryMock.Setup(ur => ur.GetByEmailAndPasswordAsync(It.IsAny<string>(), passwordHash).Result).Returns(user);
            authServiceMock.Setup(au => au.GenerateJwtToken("lima@gmail.com", new List<UserRole>())).Returns("dsdsdsdsdsdsdsdsdsds");

            var loginUserCommand = new LoginUserCommand
            {
                Email = "lima@gmail.com",
                Password = "LIma@gmail123"
            };

            var loginUserCommandHandler = new LoginUserCommandHandler(authServiceMock.Object, userRepositoryMock.Object);

            var result = await loginUserCommandHandler.Handle(loginUserCommand, new CancellationToken());

            Assert.NotNull(result);
            Assert.Equal(result.Token, authServiceMock.Object.GenerateJwtToken(user.Email, user.UserRoles));
            userRepositoryMock.Verify(pr => pr.GetByEmailAndPasswordAsync(It.IsAny<string>(), passwordHash), Times.Once);
        }
    }
}
