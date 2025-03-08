using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using simple_pag_Domain.Dto;
using simple_pag_Domain.Entity;
using simple_pag_Infra.Data;

namespace simple_pag.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataConnectionContext _context;

        public UsuarioController (DataConnectionContext context) {

            _context = context;
        }

       
        //EndPoint de criação de novos usuários
        [HttpPost("Create")]
        [Consumes("application/json")]
        public IActionResult Create ([FromBody] Usuario usuario) {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Usuario.Add(usuario);
                    _context.SaveChanges();

                    return Ok(new {message = "Dados inseridos com sucesso"});
                }
                else
                {
                    return BadRequest(new {message = "Erro: Não foi possível inserir dados"});
                }
            }
            catch (System.Exception ex)
            {
                 Console.WriteLine(ex);

                 return Problem();
            }
        }

         //Leitura de todos os usuarios
        [HttpGet("GetAll")]
        public IActionResult GetAll () {

            try
            {
                 var existsResults = _context.Usuario.ToList();

                    if (existsResults != null)
                    {
                        return Ok(existsResults);
                    }
                    else
                    {
                       return NotFound(new {message = "Dados não encontrados"}); 
                    }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);

                return Problem();
            }
        }

        //Retornar o Id do Usuário
        [HttpGet("GetId")]
        [Consumes("application/json")]
        public IActionResult GetId ([FromBody] string email) {

            try
            {
                var existsResults = _context.Usuario.FirstOrDefault(u => u.Email == email);

                if (existsResults != null)
                {
                    return Ok(existsResults.Id);
                }
                else
                {
                    return NotFound(new {message = "Dados não encontrados"});
                }
            }
            catch (System.Exception ex)
            {
                 Console.WriteLine(ex);

                 return Problem();
            }

        }

        //Endpoint de Retorno com base no ID
        [HttpGet("Get/{id}")]
        public IActionResult Get (string id) {//<= Id NÂO autoincremental!

            try
            {
                var existsResults = _context.Usuario.Find(id);

                if (existsResults != null)
                {
                    return Ok(existsResults);
                }
                else
                {
                    return NotFound(new {message = "Dados não encontrados"});
                }
            }
            catch (System.Exception ex)
            {
                 Console.WriteLine(ex);

                 return Problem();
            }
        }

        //Endpoint de Atualizacao
        [HttpPut("Update/{id}")]
        [Consumes("application/json")]
        public IActionResult Update(string id, [FromBody] DtoUsuario dtoUsuario) {

            try
            {   
                 var existsResults = _context.DtoUsuarios.Find(id);

                if (ModelState.IsValid && existsResults != null)
                {   
                    existsResults.Nome = dtoUsuario.Nome;
                    existsResults.Email = dtoUsuario.Email;
                    existsResults.ChavePrivada = dtoUsuario.ChavePrivada;

                    _context.DtoUsuarios.Update(existsResults);
                    _context.SaveChanges();

                    return Ok(new {message = "Dados atualizados com sucesso"});
                } 
                else if (existsResults == null) {

                    return NotFound(new {message = "Dados não encontrados"});
                }
                else if (!ModelState.IsValid) {

                    return BadRequest(new {message = "Erro: Erro na requisição"});
                }
                else
                {
                    return Forbid();
                }
            }
            catch (System.Exception ex)
            {
                 Console.WriteLine(ex);

                 return Problem();
            }
        }

        //EndPoint para Deletar dados
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete (string id) {

            try
            {
               var existsResults = _context.Usuario.Find(id);

               if (existsResults != null)
               {
                    _context.Usuario.Remove(existsResults);
                    _context.SaveChanges();

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

                 return Problem();
            }
        }
    }
}