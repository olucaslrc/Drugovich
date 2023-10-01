using AutoMapper;
using Drugovich.Application.DTOs;
using Drugovich.Application.DTOs.Security;
using Drugovich.Domain.Entities;
using Drugovich.Domain.Interfaces;
using Drugovich.Domain.Interfaces.Services;
using MediatR;

namespace Drugovich.Application.Commands.Security.Handlers
{
    public class RegisterManagerCommandHandler : IRequestHandler<RegisterManagerCommand, ManagerDTO>
    {
        private readonly IUnityOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ITokenService _token;
        public RegisterManagerCommandHandler(IUnityOfWork uow, IMapper mapper, ITokenService token)
        {
            _uow = uow;
            _mapper = mapper;
            _token = token;
        }

        public async Task<ManagerDTO> Handle(RegisterManagerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var obj = _mapper.Map<RegisterManagerDTO, Manager>(request.Manager);
                obj.Id = Guid.NewGuid();
                obj.Registered = DateTime.UtcNow;
                obj.LastUpdate = DateTime.UtcNow;

                var aux = await _uow.ManagerRepository.AddAsync(obj);
                var result = _mapper.Map<Manager, ManagerDTO>(aux);
                result.Token = _token.CreateToken();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
