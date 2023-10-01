using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Drugovich.Presentation.Controllers.App
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly ILogger _logger;
        public AppController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [Route("/customers/all")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, DateTime.UtcNow);
            }
            return null;
        }
    }
}
