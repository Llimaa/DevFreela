using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Core.Entities;
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
    public class UpdateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_UpdateProject()
        {
            // Arrage
            var project = new Project("Nome do projeto 01", "Descrição", 1, 1, 10000);
            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetDetailsByIdAsync(0).Result).Returns(project);

            var createProjectCommand = new UpdateProjectCommand
            {
                Id = 0,
                Title = "Titudo de teste",
                Description = "Descrição do projeto",
                TotalCost = 3000,
            };

            var createProjectCommandHandler = new UpdateProjectCommandHandler(projectRepositoryMock.Object);

            // Act
            await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            //Assert
            Assert.Equal(project.TotalCost, createProjectCommand.TotalCost);
            Assert.Equal(project, projectRepositoryMock.Object.GetDetailsByIdAsync(0).Result);
            projectRepositoryMock.Verify(pr => pr.GetDetailsByIdAsync(It.IsAny<int>()), Times.Exactly(2));
            projectRepositoryMock.Verify(pr => pr.SaveChangesAsync(), Times.Once);
        }
    }
}
