using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        CommandAuthorization _commandAuthorization;
        public FinalizadoraController(IMediator mediator)
        {
            _mediator = mediator;
            _commandAuthorization = new CommandAuthorization();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateFinalizadora([FromBody] CommandFinalizadora request)
        {
            try
            {
                //var headre = HttpContext.Request.Headers.Authorization.ToString();
              

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
        [Authorize]
        public async Task<IActionResult> GetAllFinalizadora([FromQuery] CommandGetAllFinalizadora request)
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
        [HttpGet]
        [Route("id")]
        [Authorize]
        public async Task<IActionResult> GetIdFinalizadora([FromQuery] CommandGetIdFinalizadora request)
        {
            try
            {
                var response = await _mediator.Send(request);
                if (response == null)
                {
                    return NotFound(new Response { StatusCode = StatusCodes.Status404NotFound, Message = "Catalogo não encontrado" });
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateFinalizadora([FromBody] CommandUpdateFinalizadora request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }
      

    }

  
}
