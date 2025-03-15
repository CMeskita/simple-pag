using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Infra.Conection;
using simple_pag_Infra.Repositories;

namespace simple_pag_Application.Handler.Usuarios
{
    public class FindUsuarioHandler : IRequestHandler<CommandUsuario, Response>
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;
        private readonly UnityOffWork _unityOffWork;

        public FindUsuarioHandler(UsuarioRepositorio usuarioRepositorio, UnityOffWork unityOffWork) {

            _unityOffWork = unityOffWork;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<Response> Handle(CommandUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                _unityOffWork.BeginTransaction();
                Usuario usuario = request;
                var resultado = _usuarioRepositorio.FindUsuarioById(usuario.Id);

                if (resultado != null)
                {
                    _unityOffWork.CommitTransaction();
                    string resultadoConvert = resultado.ToJson();
                    return new Response{Message = resultadoConvert, StatusCode = 200};
                }
                else
                {
                    _unityOffWork.Rollback();
                    return new Response {Message = "Dados não encontrados", StatusCode = 404};
                }
            }
            catch (System.Exception ex)
            {   
                 _unityOffWork.Rollback();
                 return new Response {Message = ex.Message, StatusCode = 500};
            }
        }
    }
}