using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;

namespace simple_pag_Application.Handler.Usuarios
{
    public class ObterTodosUsuarioHandler : IRequestHandler<CommandObterTodosUsuario, List<UsuarioResponse>>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public ObterTodosUsuarioHandler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<UsuarioResponse>> Handle(CommandObterTodosUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                var listadeusuario =  _repositorio.GetAllUsuarios().ToList();
                var response = new List<UsuarioResponse>
                    (listadeusuario.Select(usuario => new UsuarioResponse
                    {
                        Id = usuario.Id,
                        Nome = usuario.Nome,
                        Email = usuario.Email,
                        Status = usuario.Status,
                        Registro = usuario.Registro


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
