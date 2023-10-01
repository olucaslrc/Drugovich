using AutoMapper;
using Drugovich.Application.DTOs.App;
using Drugovich.Domain.Entities;
using Drugovich.Domain.Interfaces;
using Drugovich.Domain.Interfaces.Services;
using Isopoh.Cryptography.Argon2;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Application.Commands.Security.Handlers
{
    public class LoginManagerCommandHandler : IRequestHandler<LoginManagerCommand, ManagerDTO>
    {
        private readonly ILogger<LoginManagerCommandHandler> _logger;
        private readonly IUnityOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ITokenService _token;
        public LoginManagerCommandHandler(ILogger<LoginManagerCommandHandler> logger, IUnityOfWork uow, IMapper mapper, ITokenService token)
        {
            _logger = logger;
            _uow = uow;
            _mapper = mapper;
            _token = token;
        }

        public async Task<ManagerDTO> Handle(LoginManagerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Manager, bool>> predicate = manager => manager.Email == request.Manager.Email;
                var getManager = await _uow.ManagerRepository.QueryAsync(predicate);

                if (getManager == null)
                {
                    return new ManagerDTO{ Name = "User not found."};
                }

                if (Argon2.Verify(getManager.Password, request.Manager.Password))
                {
                    var aux = _mapper.Map<Manager, ManagerDTO>(getManager);
                    aux.Token = await _token.CreateToken(getManager);

                    return aux;
                }
                return new ManagerDTO { Name = "Incorret Password or E-mail" };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, DateTime.UtcNow);
                throw new Exception(ex.Message);
            }
        }
    }
}
