using MediatR;
using Microsoft.AspNetCore.Mvc;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Models;


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
        public async Task<IActionResult> CadastrarUsuario([FromBody] CommandUsuario request)
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
        
        [HttpPost]
        [Route("contatos")]
        public async Task<IActionResult> CadastrarContatoDeUsuario([FromBody] CommandContatoUsuario request)
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
        public async Task<IActionResult> ObterTodosUsuario()
        {
            try
            {
                var response = await _mediator.Send(new CommandObterTodosUsuario());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
            ;
        }
        [HttpGet]
        [Route("contatos-usuario")]
        public async Task<IActionResult> ObterTodosContatoPorUuarioId([FromQuery] CommandUsuarioIdContato request)
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
        public async Task<IActionResult> ObterdUsuarioporId([FromQuery] CommandObterUsuarioPorId request)
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
        public async Task<IActionResult> AlterarUsuario([FromBody] CommandAlterarUsuario request)
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
        [Route("contato")]
        public async Task<IActionResult> AlterarContatoDoUsuario([FromBody] CommandAlterarContatoUsuario request)
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
        public async Task<IActionResult> AlterarUsuarioParaInativar([FromBody] CommandInativarUsuario request)
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
        [HttpPost]
        [Route("gera-cnpj-alpha")]
        public async Task<IActionResult> CnpjAlpha()
        {
            try
            {
                var response = CNPJGenerator.GerarCNPJValidoAlphaNumeric();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("valida-cnpj-alpha")]
        public async Task<IActionResult> ValidaCnpjAlpha(string cnpj)
        {
            try
            {
               //var response = CnpjAlphaValidator.IsValidCnpj(cnpj);
                var response = CNPJ.IsValid(cnpj);
                if (response)
                {
                    return Ok(new Response { StatusCode = StatusCodes.Status200OK, Message = "CNPJ Válido" });
                }
                else
                {
                    return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = "CNPJ Inválido" });
                }
               
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }
    }
}

