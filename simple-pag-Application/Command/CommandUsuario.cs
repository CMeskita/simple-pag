using Amazon.Runtime.Internal;
using MediatR;
using Microsoft.Win32;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;

namespace simple_pag_Application.Command
{
    public class CommandUsuario : IRequest<Response>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string ChavePrivada { get; set; }


        public static implicit operator Usuario(CommandUsuario usuario)
            => new Usuario(usuario.Nome, usuario.Email, usuario.ChavePrivada);

    }

    public class CommandGetAllUsuario : IRequest<UsuarioResponse>
    {
        //public int pageNumber { get; set; }//quantidade de registros por página
        //public int pageSize { get; set; }//quantidade de páginas
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
        public string Registro { get; set; }
        public bool Status { get; set; }

        internal void Atualizar(string chavePrivada, string registro, bool status)
        {
            ChavePrivada = chavePrivada;
            Registro = registro;
            Status = status;
        }

        public static implicit operator Usuario(CommandUpdateUsuario usuario)
            => new Usuario(usuario.Id, usuario.Nome, usuario.Email, usuario.ChavePrivada, usuario.Registro, usuario.Status);
    }
    public class CommandInativarUsuario : IRequest<Response>
    {
        public string Id { get; set; }
    }
    public class CommandContatoUsuario : IRequest<Response>
    {
        public string Descricao { get;  set; }
        public string Conteudo { get;  set; }

        public string UsuarioId { get;  set; }
        public static implicit operator Contato(CommandContatoUsuario dto)
            => new Contato(dto.Descricao,dto.Conteudo,dto.UsuarioId);
    }
}
