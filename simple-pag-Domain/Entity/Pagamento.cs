using simple_pag_Domain.Shared.Models;
using simple_pag_Domain.Shared.Notificacao;

namespace simple_pag_Domain.Entity
{
    public class Pagamento
    {
        private readonly Notify _notify;


        public Pagamento()
        {
            _notify = new Notify();
        }
        public Pagamento(string nome)
        {
            Id = Guid.NewGuid().ToString().ToUpper();
            Nome = StringExtensions.RemoverAcentos(nome).ToUpper().Trim();   
            Sigla = StringExtensions.GerarSiglaAsync(nome).Trim();
            Registro = DateTime.UtcNow;      
            Status = true;
            ValidationRules(false);
        }

        public Pagamento(string id, string nome, int codFinalizadora, string sigla)
        {
            Id = id;
            Nome = StringExtensions.RemoverAcentos(nome).ToUpper().Trim();
            CodFinalizadora = codFinalizadora;
            Sigla = StringExtensions.GerarSiglaAsync(nome).Trim(); 

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
        public void SetCodPagamento(int codFinalizadora)
        {
            CodFinalizadora = codFinalizadora;
        }
        public void SetSigla(string sigla)
        {
            Sigla = sigla;
        }
        public Notify Notification => _notify;
        public string Id { get; protected set; }
        public string? Nome { get; protected set; }
        public int CodFinalizadora { get; protected set; }
        public DateTime Registro { get; protected set; }
        public string Sigla { get; protected set; }
        public bool Status { get; protected set; }

        public virtual ICollection<FinalizadoraPagamento> FinalizadoraPagamentos { get; set; }

        private void ValidationRules(bool update = false)
        {
            if (string.IsNullOrEmpty(Id) && update == true)
            {
                _notify.Add("ID não informado");
            }
                   
            if (string.IsNullOrEmpty(Nome))
            {
                _notify.Add("Nome não informado");
            }
           
        }

    }
}
