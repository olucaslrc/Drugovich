using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Drugovich.Presentation.Controllers.Security
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger _logger;
        public AuthenticationController(ILogger logger)
        {
            _logger = logger;
        }

        //[HttpPost("/account/register")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Register()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Log(LogLevel.Error, ex);
        //    }
        //}

        //[HttpPost("/account/login")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Login()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Log(LogLevel.Error, ex);
        //    }
        //}
    }
}