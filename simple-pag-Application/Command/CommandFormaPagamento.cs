using MediatR;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
namespace simple_pag_Application.Command
{
    public class CommandFormaPagamento : IRequest<Response>
    {
        public string Nome { get; set; }

        public static implicit operator Pagamento(CommandFormaPagamento formpag)
            => new Pagamento(formpag.Nome);
    }

    public class CommandUpdateFormaPagamento : IRequest<Response> 
    {
        public string Id {  get; set; }
        public string Nome { get; set;}
        public int CodFinalizadora { get; set; }
        public string Sigla { get; set; }
        public static implicit operator Pagamento(CommandUpdateFormaPagamento dto)
            => new Pagamento(dto.Id, dto.Nome, dto.CodFinalizadora, dto.Sigla);
    }
    public class CommandGetIdFormaPagamento : IRequest<FormaPagamentoResponseItem>
    {
        public string Id { get; set; }
    }
    public class CommandGetAllFormaPagamento : IRequest<FormaPagamentoResponse>
    {

    }
}
