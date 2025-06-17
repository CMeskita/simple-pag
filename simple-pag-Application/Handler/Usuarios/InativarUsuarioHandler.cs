using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_pag_Application.Handler.Usuarios
{
    public  class InativarUsuarioHandler : IRequestHandler<CommandInativarUsuario, Response>
    {
        private readonly IUsuarioRepositorio _repositorio;
        private readonly IUnityOffWork _unityOffWork;

        public InativarUsuarioHandler(IUsuarioRepositorio repositorio, IUnityOffWork unityOffWork)
        {
            _repositorio = repositorio;
            _unityOffWork = unityOffWork;
        }

        public async Task<Response> Handle(CommandInativarUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                _unityOffWork.BeginTransaction();
                var usuario = _repositorio.FindUsuarioById(request.Id).Result;
                if (usuario == null)
                {
                    return new Response { Message = "Finalização não Existe", StatusCode = 404 };
                }

                usuario.InativarUsuario();

                await _repositorio.UpdateAsync(usuario);
                _unityOffWork.CommitTransaction();

                return new Response { Message = "Alterado com Sucesso", StatusCode = 200 };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
