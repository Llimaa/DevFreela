using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using Xunit;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        public Project project { get; set; }

        public ProjectTests()
        {
            project = new Project("New Project", "Está é a descrição do projeto", 1, 1, 100);
        }

        [Fact]
        public void ProjectStartWorks()
        {
            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotNull(project.Title);
            Assert.NotNull(project.Description);
        }

        [Fact]
        public void StartProjectShouldReturnStatusStart()
        {
            project.Start();
            Assert.Equal(ProjectStatusEnum.Inprogress, project.Status);
            Assert.NotNull(project.StartedAt);
        }

        [Fact]
        public void StartProjectShouldReturnStatusFinish()
        {
            project.Start();
            project.Finish();
            Assert.Equal(ProjectStatusEnum.Finished, project.Status);
        }

        [Fact]
        public void StartProjectShouldReturnStatusCancel()
        {
            project.Cancel();
            Assert.Equal(ProjectStatusEnum.Cancelled, project.Status);
        }

        [Fact]
        public void UpdateProjectShouldReturnProjectUpdated()
        {
            project.Update("Atualizado", "Description", 500);
            Assert.Equal(500, project.TotalCost);
            Assert.Equal("Atualizado", project.Title);
        }
    }
}
