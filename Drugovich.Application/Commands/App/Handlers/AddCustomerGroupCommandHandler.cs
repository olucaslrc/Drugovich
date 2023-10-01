using AutoMapper;
using Drugovich.Application.DTOs;
using Drugovich.Domain.Entities;
using Drugovich.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Application.Commands.Handlers
{
    public class AddCustomerGroupCommandHandler : IRequestHandler<AddCustomerGroupCommand, CustomerGroupDTO>
    {
        private readonly IUnityOfWork _uow;
        private readonly IMapper _mapper;
        public AddCustomerGroupCommandHandler(IUnityOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CustomerGroupDTO> Handle(AddCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var obj = _mapper.Map<CustomerGroupDTO, CustomerGroup>(request.CustomerGroup);
                obj.Id = Guid.NewGuid();
                obj.Registered = DateTime.UtcNow;
                obj.LastUpdate = DateTime.UtcNow;

                var aux = await _uow.CustomerGroupRepository.AddAsync(obj);
                var result = _mapper.Map<CustomerGroup, CustomerGroupDTO>(aux);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
