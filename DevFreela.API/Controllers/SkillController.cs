using DevFreela.Application.Commands.CreateSkill;
using DevFreela.Application.Commands.CreateUserSkill;
using DevFreela.Application.Queries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillController : ControllerBase
    {

        private readonly IMediator _mediator;

        public SkillController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllSkillQuery();
            var skills = await _mediator.Send(query);
            return Ok(skills);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateSkillCommand createSkillCommand)
        {
            await _mediator.Send(createSkillCommand);
            return NoContent();
        }

        [HttpPost("user-skill")]
        public async Task<IActionResult> PostUserSkill(CreateUserSkillCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
