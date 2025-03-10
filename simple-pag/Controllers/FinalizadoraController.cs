using MediatR;
using Microsoft.AspNetCore.Mvc;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;

namespace simple_pag.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FinalizadoraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinalizadoraController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CommandFinalizadora request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return StatusCode(201, response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }
    }
}
