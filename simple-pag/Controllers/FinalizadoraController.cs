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
        public FinalizadoraController(IMediator mediator) { _mediator = mediator;}
        [HttpPost]       
        public async Task<IActionResult> CadastrarFinalizadora([FromBody] CommandFinalizadora request)
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
        }
        [HttpGet]
        public async Task<IActionResult> ObterTodasFinalizadora()
        {
            try
            {
                var response = await _mediator.Send(new CommandObterTodasFinalizadora());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            };
        }
        [HttpGet]
        [Route("id")]     
        public async Task<IActionResult> ObertFinalizadoraPorId([FromQuery] CommandObterFinalizadoraId request)
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
        [HttpGet]
        [Route("usuario")]//pegar todas as finalizadors por usuario
        public async Task<IActionResult> ObterFinalizadoraporUsuarioId([FromQuery] CommandObterFinalizadoraPorUsuarioId request)
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
        [Route("usuario-finalizadora")]
        public async Task<IActionResult> ObterPagamentosPorUsuarioIdEFinalizadoraId([FromQuery] CommandObterFinalizadoraId request)
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
        public async Task<IActionResult> ObterFinalizadoraPeriodo([FromQuery] CommandObterFinalizadoraPeriodo request)
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
        public async Task<IActionResult> ObterTodasFinalizadoraMes([FromQuery] CommandObterFinalizadoraMes request)
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
        public async Task<IActionResult> ObterTodasFinalizadoraAno([FromQuery] CommandObterFinalizadoraAno request)
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

        [HttpDelete]
        [Route("cancelamento")]
        public async Task<IActionResult> CancelarFinalizadora([FromQuery] CommandCancelamentoFinalizadora request)
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
        }

    }


}
