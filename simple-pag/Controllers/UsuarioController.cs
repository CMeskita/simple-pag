using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Infra.Conection;

namespace simple_pag.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController (IMediator mediator) {

            _mediator = mediator;
        }
       
        //EndPoint de criação de novos usuários
        [HttpPost("CreateUsuario")]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateUsuario ([FromBody] CommandUsuario request) {

            try
            {
                if (ModelState.IsValid)
                {   
                    var response = await _mediator.Send(request);
                   
                    return StatusCode(201, response);
                }
                else
                {
                    return BadRequest(new Response {StatusCode = StatusCodes.Status400BadRequest, Message = "Model invalido, averiguar todas propriedados do objeto"});
                }
            }
            catch (System.Exception ex)
            {
                 Console.WriteLine(ex);
             
                 return BadRequest(new Response {StatusCode = StatusCodes.Status500InternalServerError, Message = ex.Message});
            }
        }

         //Leitura de todos os usuarios
        [HttpGet("GetAllUsuarios")]
        public async Task<IActionResult> GetAllUsuarios () {

            try
            {
                var existsResults = await _mediator.Send(null);

                    if (existsResults != null)
                    {   
                        string resultados = existsResults.ToJson();
                        return Ok(new Response {Message = resultados, StatusCode = StatusCodes.Status200OK});
                    }
                    else
                    {
                       return NotFound(new Response {Message = "Dados não encontrados.", StatusCode = StatusCodes.Status404NotFound}); 
                    }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);

                string msg = ex.Message.ToString();

                return BadRequest(new Response {Message = msg, StatusCode = StatusCodes.Status500InternalServerError});
            }
        }


        //Retornar o Id do Usuário
        [HttpGet("FindUsuario/[request]")]
        public async Task<IActionResult> FindUsuario ([FromQuery] CommandUsuario request) {

            try
            {
                var existsResults = await _mediator.Send(request);

                if (existsResults != null)
                {   
                    string resposta = existsResults.ToJson();
                    return Ok(new Response{Message = resposta, StatusCode = StatusCodes.Status200OK});
                }
                else
                {
                    return NotFound(new Response{Message = "Dados não encontrados.", StatusCode = StatusCodes.Status404NotFound});
                }
            }
            catch (System.Exception ex)
            {
                 Console.WriteLine(ex);

                 return BadRequest(new Response{Message = ex.Message, StatusCode = StatusCodes.Status500InternalServerError});
            }

        }

        //Endpoint que checa se usuário existe dentro da base de dados
        [HttpGet("ExisteUsuario/[request]")]
        public async Task<IActionResult> ExisteUsuario ([FromQuery] CommandUsuario request) {//<= Id NÂO autoincremental!

            try
            {
                var existsResults = await _mediator.Send(request);

                int statusCodeInReturn = existsResults.StatusCode;

                if (statusCodeInReturn == 200)
                {
                    return Ok(new Response {Message = "Usuário Existe em nossa Base De Dados!", StatusCode = StatusCodes.Status200OK});
                }
                else if (statusCodeInReturn == 404)
                {
                    return NotFound(new Response {Message = "Usuário não encontrado em nossa base de dados", StatusCode = StatusCodes.Status404NotFound});
                }
                else {
                    return BadRequest(new Response {Message = "Error!", StatusCode = StatusCodes.Status500InternalServerError});
                }
            }
            catch (System.Exception ex)
            {
                 return BadRequest(new Response {Message = ex.Message, StatusCode = StatusCodes.Status500InternalServerError});
            }
        }

        //Endpoint de Exclusão Lógica
        [HttpPut("InativarUsuario")]
        [Consumes("application/json")]
        public async Task<IActionResult> Update([FromBody] CommandUsuario request) {

            try
            {   
                var existsResults = await _mediator.Send(request);
                int statusCodeInReturn = existsResults.StatusCode;
                string message = existsResults.Message;

                if (statusCodeInReturn == 200)
                {
                    return Ok(new Response {Message = message, StatusCode = StatusCodes.Status200OK});
                }
                else
                {
                    return BadRequest(new Response{Message = message, StatusCode = StatusCodes.Status500InternalServerError});
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Response{Message = ex.Message, StatusCode = StatusCodes.Status500InternalServerError});
            }
        }

        //EndPoint de Atualização de dados do Usuário
        [HttpPut("UpdateUsuario")]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateUsuario ([FromBody] CommandUsuario request) {

            try
            {
                var resultados = await _mediator.Send(request);
                int statusCodeInReturn = resultados.StatusCode;
                string message = resultados.Message;

                if (statusCodeInReturn == 200)
                {
                    return Ok(new Response{Message = message, StatusCode = StatusCodes.Status200OK});
                }
                else
                {
                   return BadRequest(new Response{Message = message, StatusCode = StatusCodes.Status500InternalServerError}); 
                }
            }
            catch (System.Exception ex)
            {
                 return BadRequest(new Response{Message = ex.Message, StatusCode = StatusCodes.Status500InternalServerError}); 
            }
        }

        //EndPoint para Deletar dados
       /* [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete (string id) {

            try
            {
                var existsResults = ""; /*_context.Usuario.Find(id);*/

              /* if (existsResults != null)
               {    
                   
                    //_context.Usuario.Remove(existsResults);
                    //_context.SaveChanges();
                  
                    return Ok(new {message = "Dados deletados com sucesso"});
               }
               else
               {    
                    return NotFound(new {message = "Dados não encontradoss"});
               } 
            }
            catch (System.Exception ex)
            {
                 // TODO
                 Console.WriteLine(ex);

                 retlurn Problem();
            }
        }*/
    }
}