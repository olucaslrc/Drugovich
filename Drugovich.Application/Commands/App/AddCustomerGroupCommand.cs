using Drugovich.Application.DTOs;
using Drugovich.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Application.Commands
{
    public class AddCustomerGroupCommand : IRequest<CustomerGroupDTO>
    {
        public AddCustomerGroupCommand(CustomerGroupDTO customerGroup) 
        {
            CustomerGroup = customerGroup;
        }
        public CustomerGroupDTO CustomerGroup { get; set; }
    }
}
