using Amazon.Runtime.Internal;
using MediatR;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;

namespace simple_pag_Application.Command
{
    public class CommandUsuario:IRequest<Response>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string ChavePrivada { get; set; }

        public static implicit operator Usuario(CommandUsuario usuario)
            => new Usuario(usuario.Nome, usuario.Email, usuario.ChavePrivada);
    }
    public class CommandGetAllUsuario : IRequest<UsuarioResponse>
    {
    }
    public class CommandGetIdUsuario : IRequest<UsuarioResponseItem>
    {
        public string Id { get; set; }
    }
    public class CommandUpdateUsuario : IRequest<Response>
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string ChavePrivada { get; set; }

        public static implicit operator Usuario(CommandUpdateUsuario usuario)
            => new Usuario(usuario.Nome, usuario.Email, usuario.ChavePrivada);
    }
}
