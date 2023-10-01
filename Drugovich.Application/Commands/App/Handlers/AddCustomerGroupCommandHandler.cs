using AutoMapper;
using Drugovich.Application.DTOs.App;
using Drugovich.Domain.Entities;
using Drugovich.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Drugovich.Application.Commands.App.Handlers
{
    public class AddCustomerGroupCommandHandler : IRequestHandler<AddCustomerGroupCommand, CustomerGroupDTO>
    {
        private readonly ILogger<AddCustomerGroupCommandHandler> _logger;
        private readonly IUnityOfWork _uow;
        private readonly IMapper _mapper;
        public AddCustomerGroupCommandHandler(ILogger<AddCustomerGroupCommandHandler> logger, IUnityOfWork uow, IMapper mapper)
        {
            _logger = logger;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CustomerGroupDTO> Handle(AddCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var obj = _mapper.Map<AddCustomerGroupDTO, CustomerGroup>(request.CustomerGroup);
                obj.Id = Guid.NewGuid();
                obj.Registered = DateTime.UtcNow;
                obj.LastUpdate = DateTime.UtcNow;

                var aux = await _uow.CustomerGroupRepository.AddAsync(obj);
                var result = _mapper.Map<CustomerGroup, CustomerGroupDTO>(aux);

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
