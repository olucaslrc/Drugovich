using Drugovich.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Application.Commands
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
