using Drugovich.Application.DTOs.App;
using Drugovich.Application.DTOs.Security;
using MediatR;

namespace Drugovich.Application.Commands.Security
{
    public class LoginManagerCommand : IRequest<ManagerDTO>
    {
        public LoginManagerDTO Manager { get; set; }
        public LoginManagerCommand(LoginManagerDTO manager)
        {
            Manager = manager;
        }
    }
}
