using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Service;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }
        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(command.Password);
            var user = new User(command.FullName, command.Email, command.BirthDate, passwordHash);
            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }
}
