using simple_pag_Domain.Notificacao;
using System.Drawing;

namespace simple_pag_Domain.Entity
{
    public class FormaPagamento
    {
        private readonly Notify _notify;

        public FormaPagamento()
        {
            _notify = new Notify();
        }
        public FormaPagamento(string nome, int codFinalizadora, string sigla)
        {
            Id = Guid.NewGuid().ToString().ToUpper();
            Nome = nome;
            CodFinalizadora = codFinalizadora;
            Registro = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss");
            Sigla = sigla;
            Status = true;
            ValidationRules(false);
        }

        public FormaPagamento(string id, string nome, int codFinalizadora, string sigla)
        {
            Id = id;
            Nome = nome;
            CodFinalizadora = codFinalizadora;
            Sigla = sigla;

            ValidationRules(true);
        }
        public void InativarFormaPagamento()
        {
            Status = true;
        }
        public void AtivarFormaPagamento()
        {
            Status = false;
        }

        public Notify Notification => _notify;
        public string Id { get; protected set; }
        public string Nome { get; protected set; }
        public int CodFinalizadora { get; protected set; }
        public string Registro { get; protected set; }
        public string Sigla { get; protected set; }
        public bool Status { get; protected set; }

        private void ValidationRules(bool update = false)
        {
            if (string.IsNullOrEmpty(Id) && update == true)
            {
                _notify.Add("ID não informado");
            }
            
            if (CodFinalizadora <= 0)
            {
                _notify.Add("Finalizadora não pode ser menor ou igual a zero.");
            }
            if (string.IsNullOrEmpty(Nome))
            {
                _notify.Add("Nome não informado");
            }
            if (string.IsNullOrEmpty(Sigla))
            {
                _notify.Add("Sigla não informado");
            }
           
        }

    }
}
