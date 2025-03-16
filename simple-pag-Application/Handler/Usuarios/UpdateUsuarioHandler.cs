using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Interface;
using simple_pag_Infra.Conection;
using simple_pag_Infra.Repositories;


namespace simple_pag_Application.Handler.Usuarios
{
    public class UpdateUsuarioHandler : IRequestHandler<CommandUpdateUsuario, Response>
    {
        private readonly IUsuarioRepositorio _repositorio;
        private readonly IUnityOffWork _unityOffWork;

        public UpdateUsuarioHandler(IUsuarioRepositorio repositorio, IUnityOffWork unityOffWork)
        {
            _repositorio = repositorio;
            _unityOffWork = unityOffWork;
        }

        public async Task<Response> Handle(CommandUpdateUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                _unityOffWork.BeginTransaction();
                var usuario = _repositorio.FindUsuarioById(request.Id).Result;
                if (usuario == null)
                {
                    return new Response { Message = "Finalização não Existe", StatusCode = 404 };
                }

                await _repositorio.UpdateAsync(request);
                _unityOffWork.CommitTransaction();

                return new Response { Message = "Alterado com Sucesso", StatusCode = 200 };
            }
            catch (Exception)
            {
                _unityOffWork.Rollback();
                return new Response { Message = "Erro na Execução", StatusCode = 500 };
            }
        }
    }
}
