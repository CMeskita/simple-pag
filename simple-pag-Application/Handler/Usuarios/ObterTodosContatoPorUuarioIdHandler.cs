using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Shared.Interface;


namespace simple_pag_Application.Handler.Usuarios
{
    public class ObterTodosContatoPorUuarioIdHandler : IRequestHandler<CommandUsuarioIdContato, List<UsuarioContatosResponse>>
    {
        private readonly IUsuarioRepositorio _repositorio;
        public ObterTodosContatoPorUuarioIdHandler(IUsuarioRepositorio repository)
        {
            _repositorio = repository;
        }
        public async Task<List<UsuarioContatosResponse>> Handle(CommandUsuarioIdContato request, CancellationToken cancellationToken)
        {
            try
            {
                var listadecontatosporusuario = _repositorio.FindContatoByUsuario(request.Id).Result;
                var response = new List<UsuarioContatosResponse>
                    (listadecontatosporusuario.Contatos.Select(usuario => new UsuarioContatosResponse
                    {
                        Id = usuario.Id,
                         Descricao= usuario.Descricao,
                         Conteudo = usuario.Conteudo,
                        Registro = usuario.Registro,
                        Status = usuario.Status,

                    }));
                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
