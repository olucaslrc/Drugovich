using AutoMapper;
using Drugovich.Application.Commands.App;
using Drugovich.Application.DTOs;
using Drugovich.Domain.Entities;
using Drugovich.Domain.Interfaces;
using MediatR;

namespace Drugovich.Application.Commands.App.Handlers
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, CustomerDTO>
    {
        private readonly IUnityOfWork _uow;
        private readonly IMapper _mapper;
        public AddCustomerCommandHandler(IUnityOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var obj = _mapper.Map<CustomerDTO, Customer>(request.Customer);
                obj.Id = Guid.NewGuid();
                obj.Registered = DateTime.UtcNow;
                obj.LastUpdate = DateTime.UtcNow;

                var aux = await _uow.CustomerRepository.AddAsync(obj);
                var result = _mapper.Map<Customer, CustomerDTO>(aux);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
