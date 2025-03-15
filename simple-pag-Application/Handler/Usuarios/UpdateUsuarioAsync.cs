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
    public class UpdateUsuarioAsync : IRequestHandler<CommandUsuario, Response>
    {
        private readonly UsuarioRepositorio _repositorio;
        private readonly UnityOffWork _unityOffWork;

        public UpdateUsuarioAsync (UsuarioRepositorio repositorio, UnityOffWork unityOffWork) {
            _repositorio = repositorio;
            _unityOffWork = unityOffWork;
        }

        public async Task<Response> Handle(CommandUsuario request, CancellationToken cancellationToken)
        {
           try
           {
            _unityOffWork.BeginTransaction();
            Usuario usuario = request;
            await _repositorio.UpdateAsync(usuario);
            _unityOffWork.CommitTransaction();
            return new Response {Message = "Dados atualizados com sucesso!", StatusCode = 200};
           }
           catch (System.Exception ex)
           {
             _unityOffWork.Rollback();
             return new Response {Message = ex.Message, StatusCode = 500};
           }
        }
    }
}