using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<int> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
        {
            var project = new Project(command.Title, command.Description, command.IdClient, command.IdFreelancer, command.TotalCost);
            await _projectRepository.AddAsync(project);
            return project.Id;
        }
    }
}
