using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;

namespace simple_pag_Application.Handler.Usuarios
{
    public class CreateUsuarioHandler : IRequestHandler<CommandUsuario, Response>
    {
        private readonly IUsuarioRepositorio _repositorio;

        private readonly IUnityOffWork _unityOffWork;

        public CreateUsuarioHandler(IUsuarioRepositorio repositorio, IUnityOffWork unityOffWork)
        {
            _repositorio = repositorio;
            _unityOffWork = unityOffWork;
        }

        public async Task<Response> Handle(CommandUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                _unityOffWork.BeginTransaction();

                Usuario? usuario =  _repositorio.GetUsuariobyEmail(request.Email).Result; 
                if (usuario != null)
                {
                    return new Response
                    {
                        Message = "Usuário já cadastrado",
                        StatusCode = 409
                    };
                }

                Usuario dados = request;
                dados.HashChavePrimaria(request.ChavePrivada);
                await _repositorio.AddUsuario(dados);

                _unityOffWork.CommitTransaction();

                return new Response { Message = "Dados Cadastrados com Sucesso", StatusCode = 201 };

            }
            catch (System.Exception ex)
            {
                _unityOffWork.Rollback();

                return new Response { Message = ex.Message, StatusCode = 500 };
            }
        }
    }
}
