using simple_pag_Domain.Models;
using simple_pag_Domain.Shared.Notificacao;
using System.Xml.Linq;

namespace simple_pag_Domain.Entity
{
    public class Finalizadora
    {
        private readonly Notify _notify;
        public Finalizadora()
        {
            _notify = new Notify();
        }
        public Finalizadora(decimal valor, int qtdParcelas, string modalidade, string vencimento, string formaPagamento)
        {
            Id = Guid.NewGuid().ToString().ToUpper();
            Valor = valor;
            QtdParcelas = qtdParcelas;
            Modalidade = modalidade.ToUpper();
            Vencimento = vencimento.ToString();
            PagamentoId = formaPagamento;
            Registro = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss");
            ValidationRules(false);
        }

        public Finalizadora(string id, decimal valor, int qtdParcelas, string modalidade, string vencimento, string formaPagamento)
        {
            Id = id;
            Valor = valor;
            QtdParcelas = qtdParcelas;
            Modalidade = modalidade;
            Vencimento = vencimento;
            PagamentoId = formaPagamento;
            ValidationRules(true);
        }

        public Notify Notification => _notify;

        public string Id { get; protected set; }
        public decimal Valor { get; protected set; }
        public int QtdParcelas { get; protected set; }
        public string Modalidade { get; protected set; }
        public string Vencimento { get; protected set; }
        public string Registro { get; protected set; }
        public string PagamentoId { get; protected set; }

        public virtual Pagamento Pagamentos { get; protected set; }

        private void ValidationRules(bool update = false)
        {
            if (string.IsNullOrEmpty(Id) && update == true)
            {
                _notify.Add("ID não informado");
            }
            if (Valor <= 0)
            {
                _notify.Add("Valor não pode ser menor ou igual a zero.");
            }
            if (QtdParcelas <= 0)
            {
                _notify.Add("Prcelas não pode ser menor ou igual a zero.");
            }
            if (string.IsNullOrEmpty(Modalidade))
            {
                _notify.Add("Modalidade não informado");
            }
            if (string.IsNullOrEmpty(Vencimento))
            {
                _notify.Add("Vencimento não informado");
            }
            if (string.IsNullOrEmpty(PagamentoId))
            {
                _notify.Add("Forma de Pagamento não informado");
            }
            
        }
    }
}
