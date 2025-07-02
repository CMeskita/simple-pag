using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared;
using simple_pag_Domain.Shared.Interface;
namespace simple_pag_Application.Handler.Usuarios
{
    public class CreateContatoHandler : IRequestHandler<CommandContatoUsuario, Response>
    {
        private readonly IUsuarioRepositorio _repositorio;

        private readonly IUnityOffWork _unityOffWork;

        public CreateContatoHandler(IUsuarioRepositorio repositorio, IUnityOffWork unityOffWork)
        {
            _repositorio = repositorio;
            _unityOffWork = unityOffWork;
        }

        public async Task<Response> Handle(CommandContatoUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                _unityOffWork.BeginTransaction();

                Contato dados = request;
                var usruario=await _repositorio.FindUsuarioById(dados.UsuarioId);
                if (usruario==null)
                {
                    return new Response { Message = "Informe um usuário Cadastrado", StatusCode = Constants_Code.STATUS_CODE_NOTFOUND };

                }
                await _repositorio.AddContatoUsuario(dados);
                _unityOffWork.CommitTransaction();

                return new Response { Message = Constants_Message.STATUS_CODE_CREATED, StatusCode = Constants_Code.STATUS_CODE_CREATED };

            }
            catch (BusinessException ex)
            {
                _unityOffWork.Rollback();

                return new Response { Message = ex.Message, StatusCode = Constants_Code.STATUS_CODE_BADREQUEST };
            }
            catch (Exception ex)
            {
                return new Response { Message = ex.Message, StatusCode = Constants_Code.STATUS_CODE_INTERNAL_SERVER_ERROR };
            }
        }
    }
}
