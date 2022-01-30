using DevFreela.Application.Commands.CreateUserRole;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserRoleCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_CreateNewRoleToUser()
        {
            var userRoleRepository = new Mock<IUserRoleRepository>();

            var createUserRoleCommand = new CreateUserRoleCommand
            {
                Role = "Client",
                UserId = 1
            };

            var createUserRoleCommandHandler = new CreateUserRoleCommandHandler(userRoleRepository.Object);

            await createUserRoleCommandHandler.Handle(createUserRoleCommand, new CancellationToken());

            userRoleRepository.Verify(pr => pr.AddAsync(It.IsAny<UserRole>()), Times.Once);
        }
    }
}
