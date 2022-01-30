using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(DeleteProjectCommand command, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetDetailsByIdAsync(command.Id);

            project.Cancel();
            await _projectRepository.CancelAsync(project);
            return Unit.Value;
        }
    }
}
