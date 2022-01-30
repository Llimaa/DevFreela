using DevFreela.Application.Commands.CreateUserRole;
using MediatR;
using System;
using System.Collections.Generic;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUserCommand()
        {

        }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<CreateUserRoleCommand> Roles { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
