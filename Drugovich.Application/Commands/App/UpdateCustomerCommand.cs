using Drugovich.Application.DTOs.App;
using MediatR;

namespace Drugovich.Application.Commands.App
{
    public class UpdateCustomerCommand : IRequest<CustomerDTO>
    {
        public CustomerDTO Customer { get; set; }
        public UpdateCustomerCommand(CustomerDTO customer)
        {
            Customer = customer;
        }
    }
}
