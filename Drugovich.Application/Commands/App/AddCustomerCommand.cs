using Drugovich.Application.DTOs.App;
using MediatR;

namespace Drugovich.Application.Commands.App
{
    public class AddCustomerCommand : IRequest<CustomerDTO>
    {
        public AddCustomerDTO Customer { get; set; }
        public AddCustomerCommand(AddCustomerDTO customerDTO)
        {
            Customer = customerDTO;
        }
    }
}
