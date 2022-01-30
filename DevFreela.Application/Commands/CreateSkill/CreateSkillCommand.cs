using MediatR;

namespace DevFreela.Application.Commands.CreateSkill
{
    public class CreateSkillCommand: IRequest<Unit>
    {
        public string Description { get; set; }
    }
}
