using simple_pag_Domain.Shared.Notificacao;
using static simple_pag_Domain.Shared.Enums.Enums;

namespace simple_pag_Domain.Entity
{
    public class FinalizadoraPagamento
    {

        private readonly Notify _notify;
        public FinalizadoraPagamento()
        {
                
        }
        public FinalizadoraPagamento(string finalizadoraid, decimal valor, int qtdParcelas, modalidadePagamento modalidade, string pagamentoid)
        {
            _notify = new Notify();

            Id = Guid.NewGuid().ToString().ToUpper();
            FinalizadoraId = finalizadoraid;
            Valor = valor;
            Parcelas = qtdParcelas;
            Modalidade = modalidade;
            PagamentoId = pagamentoid;
            Vencimento = CalcularVencimento(modalidade, qtdParcelas);
            ValidationRules(false);


        }
       
        public string Id { get; set; }
      
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
        public modalidadePagamento Modalidade { get; set; }
        public DateTime Vencimento { get; set; }
        public string PagamentoId { get; set; }
        public string FinalizadoraId { get; set; }
        public bool IsDeleted { get; protected set; } = false;
        public DateTime? DeletedAt { get; protected set; } = null;

        public virtual Finalizadora Finalizadora { get; set; }
        public virtual Pagamento Pagamentos { get; set; }
        public Notify Notification => _notify;

        private void ValidationRules(bool update = false)
        {
            if (string.IsNullOrEmpty(FinalizadoraId) && update == true)
            {
                _notify.Add("ID não informado");
            }
            if (string.IsNullOrEmpty(PagamentoId) && update == true)
            {
                _notify.Add("ID não informado");
            }
            if (Valor <= 0)
            {
                _notify.Add("Valor não pode ser menor ou igual a zero.");
            }
            if (Parcelas < 0)
            {
                _notify.Add("Prcelas não pode ser menor a zero.");
            }
            if (!Modalidade.Equals(modalidadePagamento.AVISTA) && Parcelas == 0)
            {

                _notify.Add("Não há parcelamento para modalidade.");
            }

            if (Vencimento == null)
            {
                _notify.Add("Vencimento não informado");
            }
            else
            {
                // Validação de data de vencimento conforme modalidade
                if (Modalidade == modalidadePagamento.AVISTA)
                {
                    if (Vencimento.Date != DateTime.Today.Date)
                    {
                        _notify.Add("Para modalidade AVISTA, o vencimento deve ser a data atual.");
                    }

                }
                if (Modalidade == modalidadePagamento.PARCELADO)
                {

                    if (Vencimento.Date < DateTime.Today.Date)
                    {
                        _notify.Add("Para modalidade PARCELADO, o vencimento deve ser uma data futura.");
                    }
                }
             
            }
            if (_notify.HasNotifications)
            {
                throw new BusinessException("Ocorreram erros na tentativa de criação do registro !!!", _notify);
            }
        }
        public static DateTime CalcularVencimento(modalidadePagamento modalidade, int quantidadeParcela)
        {
            if (modalidade == modalidadePagamento.AVISTA)
            {
                // Para AVISTA, o vencimento é a data atual
                return DateTime.UtcNow;
            }
            else if (modalidade == modalidadePagamento.PARCELADO)
            {
                // Para PARCELADO, soma os dias informados à data atual
                var dataVencimento = DateTime.UtcNow.AddMonths(quantidadeParcela);
                return dataVencimento;
            }
            else
            {
                throw new ArgumentException("Modalidade de pagamento inválida.");
            }
        }
    
     
    }
}
