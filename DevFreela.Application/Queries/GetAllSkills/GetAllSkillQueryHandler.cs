using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillQueryHandler : IRequestHandler<GetAllSkillQuery, IList<SkillViewModel>>
    {

        private readonly ISkillRepository _skillRepository;

        public GetAllSkillQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<IList<SkillViewModel>> Handle(GetAllSkillQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skillRepository.GetAllAsync();

            var skillViewModel = skills
                .Select(s => new SkillViewModel(s.Id, s.Description)).ToList();
            return skillViewModel;
        }
    }
}
