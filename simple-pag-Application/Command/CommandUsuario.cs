using simple_pag_Domain.Entity;

namespace simple_pag_Application.Command
{
    public class CommandUsuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string ChavePrivada { get; set; }

        public static implicit operator Usuario(CommandUsuario usuario)
            => new Usuario(usuario.Nome, usuario.Email, usuario.ChavePrivada);
    }
}
