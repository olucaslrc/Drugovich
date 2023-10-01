using Drugovich.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Application.Commands.App
{
    public class AddCustomerCommand : IRequest<CustomerDTO>
    {
        public CustomerDTO Customer { get; set; }
        public AddCustomerCommand(CustomerDTO customerDTO)
        {
            Customer = customerDTO;
        }
    }
}
