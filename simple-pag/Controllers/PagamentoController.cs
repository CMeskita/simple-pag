using Microsoft.AspNetCore.Mvc;
using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using Microsoft.AspNetCore.Authorization;

namespace simple_pag.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PagamentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CommandFormaPagamento request)
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

        [HttpGet]
        [Route("todos")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllFormaPagamento([FromQuery] CommandGetAllFormaPagamento request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            };
        }

    }
}
