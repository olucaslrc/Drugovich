using AutoMapper;
using Drugovich.Application.DTOs.App;
using Drugovich.Domain.Entities;
using Drugovich.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Drugovich.Application.Commands.App.Handlers
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, CustomerDTO>
    {
        private readonly ILogger<AddCustomerCommandHandler> _logger;
        private readonly IUnityOfWork _uow;
        private readonly IMapper _mapper;
        public AddCustomerCommandHandler(ILogger<AddCustomerCommandHandler> logger, IUnityOfWork uow, IMapper mapper)
        {
            _logger = logger;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var obj = _mapper.Map<AddCustomerDTO, Customer>(request.Customer);
                obj.Id = Guid.NewGuid();
                obj.Registered = DateTime.UtcNow;
                obj.LastUpdate = DateTime.UtcNow;

                var aux = await _uow.CustomerRepository.AddAsync(obj);
                var result = _mapper.Map<Customer, CustomerDTO>(aux);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, DateTime.UtcNow);
                throw new Exception(ex.Message);
            }
        }
    }
}
