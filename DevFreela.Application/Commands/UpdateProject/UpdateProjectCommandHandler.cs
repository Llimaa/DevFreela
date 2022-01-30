using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public UpdateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(UpdateProjectCommand command, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetDetailsByIdAsync(command.Id);
            project.Update(command.Title, command.Description, command.TotalCost);
            await _projectRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
