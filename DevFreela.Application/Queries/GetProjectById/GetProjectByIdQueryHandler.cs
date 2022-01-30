using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
    {
        private readonly IProjectRepository _projecRepository;

        public GetProjectByIdQueryHandler(IProjectRepository projecRepository)
        {
            _projecRepository = projecRepository;
        }
        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery query, CancellationToken cancellationToken)
        {
            var project = await _projecRepository.GetDetailsByIdAsync(query.Id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client?.FullName,
                project.Freelancer?.FullName
                );

            return projectDetailsViewModel;
        }
    }
}
