using Drugovich.Application.DTOs.App;
using MediatR;

namespace Drugovich.Application.Commands.App
{
    public class AddCustomerGroupCommand : IRequest<CustomerGroupDTO>
    {
        public AddCustomerGroupCommand(AddCustomerGroupDTO customerGroup)
        {
            CustomerGroup = customerGroup;
        }
        public AddCustomerGroupDTO CustomerGroup { get; set; }
    }
}
