using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Interface;
using simple_pag_Domain.Entity;
using System.Net;

namespace simple_pag_Application.Handler.Usuarios
{
    public class CreateUsuarioHandler : IRequestHandler<CommandUsuario, Response>
    {
        private readonly IUsuarioRepositorio _repositorio;

        private readonly IUnityOffWork _unityOffWork;

        public CreateUsuarioHandler (IUsuarioRepositorio repositorio, IUnityOffWork unityOffWork) {

            _repositorio = repositorio;

            _unityOffWork = unityOffWork;
        }

        public async Task<Response> Handle(CommandUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                _unityOffWork.BeginTransaction();

                Usuario dados = request;

                await _repositorio.AddUsuario(dados);

                _unityOffWork.CommitTransaction();

                return new Response {Message = "Dados Cadastrados com Sucesso", StatusCode = 201};
                
            }
            catch (System.Exception ex)
            {
                _unityOffWork.Rollback();

                return new Response {Message = ex.Message, StatusCode = 500};
            }
        }



        public async Task<Response> InativarUsuarioHandle (CommandUsuario request, CancellationToken cancellationToken) {

            try
            {
                _unityOffWork.BeginTransaction();
                Usuario usuario = request;
                await _repositorio.InativarUsuario(usuario.Id);
                _unityOffWork.CommitTransaction();
                return new Response {Message = "Usuario inativado com sucesso", StatusCode = 200};
            }
            catch (System.Exception ex)
            {
                 _unityOffWork.Rollback();
                 return new Response {Message = ex.Message, StatusCode = 500};
            }
        } 

        public async Task<Response> UpdateAsyncHandle (CommandUsuario request, CancellationToken cancellationToken) {

            try
            {
                _unityOffWork.BeginTransaction();
                Usuario usuario = request;
                await _repositorio.UpdateAsync(usuario);
                _unityOffWork.CommitTransaction();
                return new Response{Message = "Dados Atualizados com sucesso", StatusCode= 200};
            }
            catch (System.Exception ex)
            {
                _unityOffWork.Rollback();
                return new Response{Message = ex.Message, StatusCode = 500};
            }
        }
    }
}