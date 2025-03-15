using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Infra.Conection;
using simple_pag_Infra.Repositories;


namespace simple_pag_Application.Handler.Usuarios
{
    public class ExisteUsuarioHandler : IRequestHandler<CommandUsuario, Response>
    {   
        private readonly UnityOffWork _unityOffWork;
        private readonly UsuarioRepositorio  _repositorio;

        public ExisteUsuarioHandler (UnityOffWork unityOffWork, UsuarioRepositorio usuarioRepositorio ) {

            _unityOffWork = unityOffWork;
            _repositorio = usuarioRepositorio;
        }

        public async Task<Response> Handle(CommandUsuario request, CancellationToken cancellationToken)
        {
           try
            {
                _unityOffWork.BeginTransaction();
                Usuario usuario = request;
                bool resultado = _repositorio.ExisteUsuario(usuario.Email);
                if (resultado)
                {
                    _unityOffWork.CommitTransaction();
                    return new Response{Message = "Usuário existe na base de dados", StatusCode = 200};
                }
                else
                {
                   _unityOffWork.Rollback();
                   return new Response{Message = "Usuário não encontrado", StatusCode = 404}; 
                }
            }
            catch (System.Exception ex)
            {
                 _unityOffWork.Rollback();
                 return new Response{Message = ex.Message, StatusCode = 500};
            } 
        }
    }


}