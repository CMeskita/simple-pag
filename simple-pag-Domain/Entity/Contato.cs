using simple_pag_Domain.Shared.Notificacao;

namespace simple_pag_Domain.Entity
{
    public class Contato
    {

        private readonly Notify _notify;
        public Contato(string descricao, string conteudo, string usuarioId)
        {
            Id = Guid.NewGuid().ToString().ToUpper();
            Descricao = descricao.ToUpper();
            Conteudo = conteudo;
            Registro = DateTime.UtcNow;
            Status = true;
            UsuarioId = usuarioId;
        }

        public Contato(string id, string descricao, string conteudo,string usuarioId)
        {
            Id = id;
            Descricao = descricao;
            Conteudo = conteudo;
            UsuarioId = usuarioId;

          
        }
        public void MudarStatus(bool status) { Status = status; }
        public Notify Notification => _notify;
        public string Id { get; protected set; }
        public string Descricao { get; protected set; }
        public string Conteudo { get; protected set; }
        public DateTime Registro { get; protected set; }
        public bool Status { get; protected set; }
        public string UsuarioId { get; protected set; }
        public virtual Usuario Usuario { get; set; }
    
     public void ValidationRules(bool update = false)
        {

            if (string.IsNullOrEmpty(Id) && update == true)
            {
                _notify.Add("ID não informado");
            }
            if (string.IsNullOrEmpty(Descricao))
            {
                _notify.Add("Descricao não informado");
            }
            if (string.IsNullOrEmpty(Conteudo))
            {
                _notify.Add("Conteudo não informado");
            }
            }
        }
    }
