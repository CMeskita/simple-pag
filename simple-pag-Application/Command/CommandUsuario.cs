using MediatR;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using System.Text.Json.Serialization;

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

    public class CommandObterTodosUsuario : IRequest<List<UsuarioResponse>>
    {
    }
    public class CommandObterUsuarioPorId : IRequest<UsuarioResponse>
    {
        public string Id { get; set; }
    }
    public class CommandAlterarUsuario : IRequest<Response>
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string ChavePrivada { get; set; }= string.Empty;
        [JsonIgnore]
        public DateTime Registro { get; set; }= DateTime.Now;
        [JsonIgnore]
        public bool Status { get; set; }= true;


        public static implicit operator Usuario(CommandAlterarUsuario usuario)
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
    public class CommandAlterarContatoUsuario : IRequest<Response>
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Conteudo { get; set; }

        [JsonIgnore]
        public string UsuarioId { get; set; } = string.Empty;

        public static implicit operator Contato(CommandAlterarContatoUsuario dto)
            => new Contato(dto.Id,dto.Descricao, dto.Conteudo,dto.UsuarioId);
    }
    public class CommandUsuarioIdContato : IRequest<List<UsuarioContatosResponse>>
    {
        public string Id { get; set; }
    }
}
