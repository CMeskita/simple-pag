
namespace simple_pag_Application.Repsonse
{
    public class FormaPagamentoResponse
    {
        public List<FormaPagamentoResponseItem> Lista { get; set; }
    }

    public class FormaPagamentoResponseItem
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string CodFinalizadora { get; set; }
        public string Sigla { get; set; }
        public bool Status { get; set; }
    }
}
