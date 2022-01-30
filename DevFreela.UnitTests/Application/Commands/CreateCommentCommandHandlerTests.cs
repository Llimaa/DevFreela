using DevFreela.Application.Commands.CreateComment;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateCommentCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_NewCommentToProject()
        {
            var projectRepository = new Mock<IProjectRepository>();

            var createCommentCommand = new CreateCommentCommand
            {
                Content = "Projeto Legal",
                IdUser = 1,
                IdProject = 1
            };

            var createCommentCommandHandler = new CreateCommentCommandHandler(projectRepository.Object);

            await createCommentCommandHandler.Handle(createCommentCommand, new CancellationToken());

            projectRepository.Verify(pr => pr.AddCommentAsync(It.IsAny<ProjectComment>()), Times.Once);
        }
    }
}
