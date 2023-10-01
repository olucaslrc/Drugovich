using AutoMapper;
using Drugovich.Application.DTOs.App;
using Drugovich.Application.DTOs.Security;
using Drugovich.Domain.Entities;
using Drugovich.Domain.Interfaces;
using Drugovich.Domain.Interfaces.Services;
using Isopoh.Cryptography.Argon2;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Drugovich.Application.Commands.Security.Handlers
{
    public class RegisterManagerCommandHandler : IRequestHandler<RegisterManagerCommand, ManagerDTO>
    {
        private readonly ILogger<RegisterManagerCommandHandler> _logger;
        private readonly IUnityOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ITokenService _token;
        public RegisterManagerCommandHandler(ILogger<RegisterManagerCommandHandler> logger, IUnityOfWork uow, IMapper mapper, ITokenService token)
        {
            _logger = logger;
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
                obj.Password = Argon2.Hash(obj.Password);
                obj.Registered = DateTime.UtcNow;
                obj.LastUpdate = DateTime.UtcNow;

                var aux = await _uow.ManagerRepository.AddAsync(obj);
                var result = _mapper.Map<Manager, ManagerDTO>(aux);
                result.Token = await _token.CreateToken(aux);

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
