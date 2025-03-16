using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using Amazon.Runtime.Internal;
using static simple_pag_Application.Command.CommandFormaPagamento;

namespace simple_pag.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FormaPagamentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
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
