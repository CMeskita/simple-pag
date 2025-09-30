using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;

namespace simple_pag_Application.Handler.Usuarios
{
    public class AlterarContatoHandler : IRequestHandler<CommandAlterarContatoUsuario, Response>
    {
        private readonly IUsuarioRepositorio _repositorio;
        private readonly IUnityOffWork _unityOffWork;

        public AlterarContatoHandler(IUnityOffWork unityOffWork, IUsuarioRepositorio usuarioRepositorio)
        {
            _unityOffWork = unityOffWork;
            _repositorio= usuarioRepositorio;
        }

        public async Task<Response> Handle(CommandAlterarContatoUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                _unityOffWork.BeginTransaction();

                var validacontato = _repositorio.FindContatoById(request.Id).Result;
                if (validacontato == null )
                {
                    return new Response { Message = "Usuário não Existe", StatusCode = 404 };
                }
                var validausuario = await _repositorio.FindContatoByUsuario(validacontato.UsuarioId);
                if (validausuario == null) 
                {
                    return new Response { Message = "Contato não pertence ao usuario", StatusCode = 404 };
                }
                foreach (var item in validausuario.Contatos)
                {
                    Contato contato = request;
                    await _repositorio.UpdateAsync(contato);
                }
               
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
