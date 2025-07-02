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

        [HttpGet]
        [Route("user")]//pegar todas as finalizadors por usuario
        public async Task<IActionResult> GetUserIdFinalizadora([FromQuery] CommandGetIdUsuarioFinalizadora request)
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
        [HttpGet]//pegar pagamento por usuario e finalizadora
        [Route("user-pagamento")]
        public async Task<IActionResult> GetUserIdPagamentoFinalizadora([FromQuery] CommandGetIdFinalizadora request)
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
        
        [HttpGet]//pegar pagamento por usuario e finalizadora
        [Route("faturamento-periodo")]
        public async Task<IActionResult> GetFinalizadoraPeriodo([FromQuery] CommandGetIdFinalizadora request)
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
        [HttpGet]//pegar pagamento por usuario e finalizadora
        [Route("faturamento-mes")]
        public async Task<IActionResult> GetFinalizadoraMes([FromQuery] CommandGetIdFinalizadora request)
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
        [HttpGet]//pegar pagamento por usuario e finalizadora
        [Route("faturamento-ano")]
        public async Task<IActionResult> GetFinalizadoraAno([FromQuery] CommandGetIdFinalizadora request)
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

    }


}
