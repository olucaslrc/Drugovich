using AutoMapper;
using Drugovich.Application.DTOs.App;
using Drugovich.Domain.Entities;
using Drugovich.Domain.Interfaces;
using Isopoh.Cryptography.Argon2;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Application.Commands.App.Handlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDTO>
    {
        private readonly ILogger<UpdateCustomerCommandHandler> _logger;
        private readonly IUnityOfWork _uow;
        private readonly IMapper _mapper;
        public UpdateCustomerCommandHandler(ILogger<UpdateCustomerCommandHandler> logger, IUnityOfWork uow, IMapper mapper)
        {
            _logger = logger;
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<CustomerDTO> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Customer, bool>> predicate = customer => customer.Id == request.Customer.Id;
                var getManager = await _uow.CustomerRepository.QueryAsync(predicate);

                if (getManager == null)
                {
                    return new CustomerDTO { Name = "User not found." };
                }

                Expression<Func<CustomerGroup, bool>> groupPredicate = group => group.Id == request.Customer.FK_CustomerGroup;
                var getGroup = await _uow.CustomerGroupRepository.QueryAsync(groupPredicate);
                if (getGroup == null)
                {
                    return new CustomerDTO { Name = "Group not found." };
                }
                getManager.CustomerGroup = getGroup;
                _uow.CustomerRepository.Update(getManager);

                return _mapper.Map<Customer, CustomerDTO>(getManager);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message, DateTime.UtcNow);
                throw new Exception(ex.Message);
            }
        }
    }
}
