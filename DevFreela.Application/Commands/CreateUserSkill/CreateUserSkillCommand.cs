using MediatR;

namespace DevFreela.Application.Commands.CreateUserSkill
{
    public class CreateUserSkillCommand : IRequest<Unit>
    {
        public int IdSkill { get; set; }
        public int IdUser { get; set; }
    }
}
