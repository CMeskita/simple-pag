using MediatR;
using Microsoft.AspNetCore.Mvc;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;

namespace simple_pag.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {

            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] CommandUsuario request)
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
        public async Task<IActionResult> GetAllUsuario([FromQuery] CommandGetAllUsuario request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
            ;
        }
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetIdUsuario([FromQuery] CommandGetIdUsuario request)
        {
            try
            {
                var response = await _mediator.Send(request);
                if (response == null)
                {
                    return NotFound(new Response { StatusCode = StatusCodes.Status404NotFound, Message = "Catalogo não encontrado" });
                }
                ;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }
        [HttpPut]

        public async Task<IActionResult> UpdateUsuario([FromBody] CommandUpdateUsuario request)
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
        [HttpPut]
        [Route("inativar")]
        public async Task<IActionResult> UpdateStatusUsuario([FromBody] CommandInativarUsuario request)
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

