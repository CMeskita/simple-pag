using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;



namespace simple_pag_Application.Handler.Usuarios
{
    public class AlterarUsuarioHandler : IRequestHandler<CommandAlterarUsuario, Response>
    {
        private readonly IUsuarioRepositorio _repositorio;
        private readonly IUnityOffWork _unityOffWork;

        public AlterarUsuarioHandler(IUsuarioRepositorio repositorio, IUnityOffWork unityOffWork)
        {
            _repositorio = repositorio;
            _unityOffWork = unityOffWork;
        }

        public async Task<Response> Handle(CommandAlterarUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                _unityOffWork.BeginTransaction();
                var validausuario = _repositorio.CheckUserIdlExist(request.Id).Result;
                if (validausuario == false)
                {
                    return new Response { Message = "Usuário não Existe", StatusCode = 404 };
                }
                var usuario = await _repositorio.FindContatoByUsuario(request.Id);

                Usuario usarios = request;
                await _repositorio.UpdateAsync(usarios);
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
