using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class DeleteProjectCommandHandlerTests
    {
        [Fact]
        public async Task DeleteDataIsOk_Execute_UpdateStatusToCAncel()
        {
            var project = new Project("Nome do projeto 01", "Descrição", 1, 1, 10000);
            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetDetailsByIdAsync(0).Result).Returns(project);
            var deleteProjectCommand = new DeleteProjectCommand(0);

            Assert.False(project.Status == ProjectStatusEnum.Cancelled);

            var deleteProjectCommandHandler = new DeleteProjectCommandHandler(projectRepositoryMock.Object);
            await deleteProjectCommandHandler.Handle(deleteProjectCommand, new CancellationToken());

            Assert.True(project.Status == ProjectStatusEnum.Cancelled);
            projectRepositoryMock.Verify(pr => pr.GetDetailsByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
