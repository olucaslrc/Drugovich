using Drugovich.Application.Commands.App;
using Drugovich.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Application.Commands.App.Handlers
{
    public class AddManagerCommandHandler : IRequestHandler<AddManagerCommand, ManagerDTO>
    {
        public async Task<ManagerDTO> Handle(AddManagerCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
