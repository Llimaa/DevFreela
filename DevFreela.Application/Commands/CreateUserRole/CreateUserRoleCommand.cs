using MediatR;

namespace DevFreela.Application.Commands.CreateUserRole
{
    public class CreateUserRoleCommand : IRequest<Unit>
    {
        public string Role { get; set; }
        public int UserId { get; set; }
    }
}
