using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;

namespace simple_pag_Application.Handler.Usuarios
{
    public class GetAllUsuariosHandler : IRequestHandler<CommandGetAllUsuario, UsuarioResponse>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public GetAllUsuariosHandler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<UsuarioResponse> Handle(CommandGetAllUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Usuario> finalizadora = await _repositorio.GetUsuariosPaginadas(request.pageNumber,request.pageSize);
                UsuarioResponse response = new UsuarioResponse
                {
                    Dados = finalizadora.Select(fin => new UsuarioResponseItem
                    {
                        Id = fin.Id,
                        Nome = fin.Nome,
                        Email = fin.Email,
                        Status = fin.Status,
                        Registro = fin.Registro


                    }).ToList(),

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
