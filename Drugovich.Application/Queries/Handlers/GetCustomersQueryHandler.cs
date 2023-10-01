using AutoMapper;
using Drugovich.Application.DTOs.App;
using Drugovich.Domain.Entities;
using Drugovich.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Drugovich.Application.Queries.Handlers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerDTO>>
    {
        private readonly ILogger<GetCustomersQueryHandler> _logger;
        private readonly IUnityOfWork _uow;
        private readonly IMapper _mapper;
        public GetCustomersQueryHandler(ILogger<GetCustomersQueryHandler> logger, IUnityOfWork uow, IMapper mapper)
        {
            _logger = logger;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<CustomerDTO>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var getCustomers = await _uow.CustomerRepository.GetAllAsync();
                return _mapper.Map<List<Customer>, List<CustomerDTO>>(getCustomers.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, DateTime.UtcNow);
                throw new Exception(ex.Message);
            }
        }
    }
}
