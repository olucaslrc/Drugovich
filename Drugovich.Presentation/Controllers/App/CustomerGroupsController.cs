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
    public class CustomerGroupsController : ControllerBase
    {
        private readonly ILogger<CustomerGroupsController> _logger;
        private readonly IMediator _mediator;
        public CustomerGroupsController(ILogger<CustomerGroupsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("all")]
        [Authorize(Roles = "Level1,Level2")]
        public async Task<IActionResult> GetCustomerGroups()
        {
            try
            {
                return new ObjectResult(await _mediator.Send(new GetCustomersGroupQuery()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, DateTime.UtcNow);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "Level2")]
        public async Task<IActionResult> AddCustomerGroup([FromBody] AddCustomerGroupDTO model)
        {
            try
            {
                return new ObjectResult(await _mediator.Send(new AddCustomerGroupCommand(model)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, DateTime.UtcNow);
                return StatusCode(500);
            }
        }
    }
}
