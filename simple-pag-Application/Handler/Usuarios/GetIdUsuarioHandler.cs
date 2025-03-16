using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Interface;
using simple_pag_Infra.Repositories;

namespace simple_pag_Application.Handler.Usuarios
{
    public class GetIdUsuarioHandler : IRequestHandler<CommandGetIdUsuario, UsuarioResponseItem>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public GetIdUsuarioHandler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<UsuarioResponseItem> Handle(CommandGetIdUsuario request, CancellationToken cancellationToken)
        {

            try
            {
                Usuario usuario = _repositorio.FindUsuarioById(request.Id).Result;

                if (usuario == null)
                {
                    return null;
                }
                UsuarioResponseItem response = new UsuarioResponseItem
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Status = usuario.Status,
                    Registro = usuario.Registro


                };



                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
