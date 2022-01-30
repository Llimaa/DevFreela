using DevFreela.Application.Commands.FinishProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class FinishProjectCommandHandlerTests
    {
        [Fact]
        public async Task FinishDataIsOk_Execute_UpdateStatusToCAncel()
        {
            var project = new Project("Nome do projeto 01", "Descrição", 1, 1, 10000);
            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetDetailsByIdAsync(0).Result).Returns(project);
            var deleteProjectCommand = new FinishProjectCommand(0);
            project.Start();

            Assert.True(project.Status == ProjectStatusEnum.Inprogress);

            var deleteProjectCommandHandler = new FinishProjectCommandHandler(projectRepositoryMock.Object);
            await deleteProjectCommandHandler.Handle(deleteProjectCommand, new CancellationToken());

            Assert.True(project.Status == ProjectStatusEnum.Finished);
            projectRepositoryMock.Verify(pr => pr.GetDetailsByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
