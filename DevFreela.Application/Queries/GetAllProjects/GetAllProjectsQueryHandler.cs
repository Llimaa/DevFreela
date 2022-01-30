using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IList<ProjectViewModel>>
    {
        private readonly IProjectRepository _rojectRepository;

        public GetAllProjectsQueryHandler(IProjectRepository rojectRepository)
        {
            _rojectRepository = rojectRepository;
        }

        public async Task<IList<ProjectViewModel>> Handle(GetAllProjectsQuery query, CancellationToken cancellationToken)
        {
            var project = await _rojectRepository.GetAllAsync();

            var projectViewModel = project
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();
            return projectViewModel;
        }
    }
}
