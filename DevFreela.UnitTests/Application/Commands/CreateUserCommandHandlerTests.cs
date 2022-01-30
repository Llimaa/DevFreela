using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.CreateUserRole;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Service;
using DevFreela.Infrastructure.Persistence.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUserId()
        {
            var userRepository = new Mock<IUserRepository>();
            var authService = new Mock<IAuthService>();

            var createUserRoleCommand = new CreateUserRoleCommand
            {
                Role = "Client",
                UserId = 1
            };

            var createUserCommand = new CreateUserCommand
            {
                FullName = "Marcos Lima",
                Email = "lima@gmail.com",
                Password = "lima123",
                Roles = new List<CreateUserRoleCommand> { createUserRoleCommand },
                BirthDate = DateTime.Now.AddYears(-20)
            };

            var createUserCommandHandler = new CreateUserCommandHandler(userRepository.Object, authService.Object);

            var id = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            Assert.True(id >= 0);

            Assert.Equal(1, createUserCommand.Roles.Count);

            userRepository.Verify(ur => ur.AddAsync(It.IsAny<User>()), Times.Once());


        }
    }
}
