using AutoMapper;
using Drugovich.Application.DTOs.App;
using Drugovich.Domain.Entities;
using Drugovich.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Application.Queries.Handlers
{
    public class GetCustomersGroupQueryHandler : IRequestHandler<GetCustomersGroupQuery, List<CustomerGroupDTO>>
    {
        private readonly ILogger<GetCustomersGroupQueryHandler> _logger;
        private readonly IUnityOfWork _uow;
        private readonly IMapper _mapper;
        public GetCustomersGroupQueryHandler(ILogger<GetCustomersGroupQueryHandler> logger, IUnityOfWork uow, IMapper mapper)
        {
            _logger = logger;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<CustomerGroupDTO>> Handle(GetCustomersGroupQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var getCustomers = await _uow.CustomerGroupRepository.GetAllAsync();
                return _mapper.Map<List<CustomerGroup>, List<CustomerGroupDTO>>(getCustomers.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, DateTime.UtcNow);
                throw new Exception(ex.Message);
            }
        }
    }
}
