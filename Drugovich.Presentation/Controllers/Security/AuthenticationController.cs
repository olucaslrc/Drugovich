using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drugovich.Application.Commands.Security;
using Drugovich.Application.DTOs.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Drugovich.Presentation.Controllers.Security
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IMediator _mediator;
        public AuthenticationController(ILogger<AuthenticationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("/account/register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterManagerDTO model)
        {
            try
            {
                return new OkObjectResult(
                    await _mediator.Send(new RegisterManagerCommand(model))
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }

        [HttpPost("/account/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginManagerDTO model)
        {
            try
            {
                return new OkObjectResult(
                    await _mediator.Send(new LoginManagerCommand(model))
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }
    }
}