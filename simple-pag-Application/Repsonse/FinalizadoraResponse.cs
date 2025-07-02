using static simple_pag_Domain.Entity.FinalizadoraPagamento;

namespace simple_pag_Application.Repsonse
{
    public class FinalizadoraResponse
    {
        public string Id { get; set; }
        public decimal Valor { get; set; }
        public string Registro { get; set; }
    }
    public class FinalizadoraResponseItem
    {       
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
        public modalidadePagamento Modalidade { get; set; }
        public string Pagamento { get; set; }
        public string Vencimento { get; set; }

    }
}
