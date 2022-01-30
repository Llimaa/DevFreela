using DevFreela.Application.Commands.UpdateUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class UpdateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_UpdateUser()
        {
            // Arrage
            var user = new User("Marcos Lima", "lima", DateTime.Now, "323232");

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(pr => pr.GetByIdAsync(0).Result).Returns(user);

            var updateUserCommand = new UpdateUserCommand
            {
                Id = 0,
                FullName = "Lima Marcos",
                BirthDate = DateTime.Now.AddYears(-10)
 
            };

            var updateUserCommandHandler = new UpdateUserCommandHandler(userRepositoryMock.Object);

            // Act
            await updateUserCommandHandler.Handle(updateUserCommand, new CancellationToken());

            //Assert
            Assert.Equal(user.FullName, updateUserCommand.FullName);
            Assert.Equal(user, userRepositoryMock.Object.GetByIdAsync(0).Result);
            userRepositoryMock.Verify(pr => pr.GetByIdAsync(It.IsAny<int>()), Times.Exactly(2));
            userRepositoryMock.Verify(pr => pr.SaveChangesAsync(), Times.Once);
        }
    }
}
