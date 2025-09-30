using static simple_pag_Domain.Entity.FinalizadoraPagamento;
using static simple_pag_Domain.Shared.Enums.Enums;

namespace simple_pag_Application.Repsonse
{
    public class FinalizadoraResponse
    {
        public string Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Registro { get; set; }
    }
    public class FinalizadoraResponseItem
    {       
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
        public modalidadePagamento Modalidade { get; set; }
        public string Pagamento { get; set; }
        public DateTime Vencimento { get; set; }

    }
    public class FinalizadoraCancelamentoResponse
    {
        List<FinalizadoraResponseItem> PagamentodaFinalizadora { get; set; }
    }
}
