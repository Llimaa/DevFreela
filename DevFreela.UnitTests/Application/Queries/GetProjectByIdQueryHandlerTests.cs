using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System.Threading;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetProjectByIdQueryHandlerTests
    {
        [Fact]
        public async void GivenProjectById_Executed_ReturnOneProjectViewModels()
        {
            var project = new Project("New project", "Description", 1, 1, 10200);

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetDetailsByIdAsync(0).Result).Returns(project);

            var getProjectQuery = new GetProjectByIdQuery(0);
            var getProjectByIdQueryHandler = new GetProjectByIdQueryHandler(projectRepositoryMock.Object);

            var projectDetailsViewModel = await getProjectByIdQueryHandler.Handle(getProjectQuery, new CancellationToken());

            Assert.NotNull(projectDetailsViewModel);
            projectRepositoryMock.Verify(pr => pr.GetDetailsByIdAsync(It.IsAny<int>()).Result, Times.Once());

        }
    }
}
