using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Core.Repositories;
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
    public class StartProjectCommandHandlerTests
    {
        [Fact]
        public async Task StartDataIsOk_Execute_UpdateStatusToCAncel()
        {
            var project = new Project("Nome do projeto 01", "Descrição", 1, 1, 10000);
            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetDetailsByIdAsync(0).Result).Returns(project);
            var deleteProjectCommand = new StartProjectCommand(0);

            Assert.True(project.Status == ProjectStatusEnum.Created);

            var deleteProjectCommandHandler = new StartProjectCommandHandler(projectRepositoryMock.Object);
            await deleteProjectCommandHandler.Handle(deleteProjectCommand, new CancellationToken());

            Assert.True(project.Status == ProjectStatusEnum.Inprogress);
            projectRepositoryMock.Verify(pr => pr.GetDetailsByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
