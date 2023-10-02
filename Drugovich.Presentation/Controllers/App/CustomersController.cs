using Drugovich.Application.Commands.App;
using Drugovich.Application.DTOs.App;
using Drugovich.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drugovich.Presentation.Controllers.App
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IMediator _mediator;
        public CustomersController(ILogger<CustomersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("all")]
        [Authorize(Roles = "Level1,Level2")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                return new OkObjectResult(
                    await _mediator.Send(new GetCustomersQuery())
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, DateTime.UtcNow);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "Level1,Level2")]
        public async Task<IActionResult> AddCustomer([FromBody]AddCustomerDTO model)
        {
            try
            {
                return new OkObjectResult(
                    await _mediator.Send(new AddCustomerCommand(model))
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, DateTime.UtcNow);
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [Route("group/update")]
        [Authorize(Roles = "Level1,Level2")]
        public async Task<IActionResult> UpdateCustomerGroup([FromBody]CustomerDTO model)
        {
            try
            {
                return new OkObjectResult(
                    await _mediator.Send(new UpdateCustomerCommand(model))
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, DateTime.UtcNow);
                return StatusCode(500);
            }
        }
    }
}
