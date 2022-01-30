using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateUserRole
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, Unit>
    {
        private readonly IUserRoleRepository _roleRepository;

        public CreateUserRoleCommandHandler(IUserRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Unit> Handle(CreateUserRoleCommand command, CancellationToken cancellationToken)
        {

            var userRole = new UserRole(command.UserId, command.Role);
            await _roleRepository.AddAsync(userRole);
            return Unit.Value;
        }
    }
}
