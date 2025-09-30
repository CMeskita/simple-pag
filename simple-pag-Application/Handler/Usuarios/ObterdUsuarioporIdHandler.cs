using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;
using simple_pag_Infra.Repositories;

namespace simple_pag_Application.Handler.Usuarios
{
    public class ObterdUsuarioporIdHandler : IRequestHandler<CommandObterUsuarioPorId, UsuarioResponse>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public ObterdUsuarioporIdHandler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<UsuarioResponse> Handle(CommandObterUsuarioPorId request, CancellationToken cancellationToken)
        {

            try
            {
                Usuario usuario = _repositorio.FindUsuarioById(request.Id).Result;

                if (usuario == null)
                {
                    return null;
                }
                UsuarioResponse response = new UsuarioResponse
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
