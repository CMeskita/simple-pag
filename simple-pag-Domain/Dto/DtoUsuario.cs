
using simple_pag_Domain.Entity;

namespace simple_pag_Domain.Dto
{
    public class DtoUsuario
    {
        public string Nome {  get; set; }
        public string Email { get; set; }
        public string ChavePrivada { get; set; }

        public static implicit operator Usuario(DtoUsuario usuario)
            => new Usuario(usuario.Nome, usuario.Email, usuario.ChavePrivada);
    }
}
