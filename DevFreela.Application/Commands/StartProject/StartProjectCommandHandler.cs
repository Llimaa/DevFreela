
using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public StartProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(StartProjectCommand command, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetDetailsByIdAsync(command.Id);
            project.Start();
            await _projectRepository.StartAsync(project);
            return Unit.Value;
        }
    }
}
