using Drugovich.Application.DTOs;
using Drugovich.Application.DTOs.Security;
using MediatR;

namespace Drugovich.Application.Commands.Security
{
    public class RegisterManagerCommand : IRequest<ManagerDTO>
    {
        public RegisterManagerDTO Manager { get; set; }
        public RegisterManagerCommand(RegisterManagerDTO manager) 
        {
            Manager = manager;
        }
    }
}
