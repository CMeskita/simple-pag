namespace simple_pag_Domain.Entity
{
    public class Contato
    {
        public Contato(string descricao, string conteudo, string usuarioId)
        {
            Id = Guid.NewGuid().ToString().ToUpper();
            Descricao = descricao.ToUpper();
            Conteudo = conteudo;
            Registro = DateTime.UtcNow.ToString();
            Status = true;
            UsuarioId = usuarioId;
        }

        public string Id { get; protected set; }
        public string Descricao { get; protected set; }
        public string Conteudo { get; protected set; }
        public string Registro { get; protected set; }
        public bool Status { get; protected set; }
        public string UsuarioId { get; protected set; }
    }
}
