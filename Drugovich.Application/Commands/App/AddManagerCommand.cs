using Drugovich.Application.DTOs.App;
using MediatR;

namespace Drugovich.Application.Commands.App
{
    public class AddManagerCommand : IRequest<ManagerDTO>
    {
        public AddManagerCommand(ManagerDTO manager)
        {
            Manager = manager;
        }
        public ManagerDTO Manager { get; set; }
    }
}
