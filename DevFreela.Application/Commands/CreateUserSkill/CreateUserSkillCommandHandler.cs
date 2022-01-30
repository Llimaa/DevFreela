using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateUserSkill
{
    public class CreateUserSkillCommandHandler : IRequestHandler<CreateUserSkillCommand, Unit>
    {
        private readonly IUserSkillRepository _userSkillRepository;

        public CreateUserSkillCommandHandler(IUserSkillRepository userSkillRepository)
        {
            _userSkillRepository = userSkillRepository;
        }

        public async Task<Unit> Handle(CreateUserSkillCommand request, CancellationToken cancellationToken)
        {
            var userSkill = new UserSkill(request.IdUser, request.IdSkill);

            await _userSkillRepository.AddUserSkill(userSkill);
            return Unit.Value;
        }
    }
}
