using MediatR;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
namespace simple_pag_Application.Command
{
    public class CommandFormaPagamento : IRequest<Response>
    {
        public string Nome { get; set; }
        public int CodFinalizadora { get; set; }
        public string Sigla { get; set; }

        public static implicit operator FormaPagamento(CommandFormaPagamento formpag)
            => new FormaPagamento(formpag.Nome, formpag.CodFinalizadora, formpag.Sigla);
    }

    public class CommandUpdateFormaPagamento : IRequest<Response> 
    {
        public string Id {  get; set; }
        public string Nome { get; set;}
        public int CodFinalizadora { get; set; }
        public string Sigla { get; set; }
        public static implicit operator FormaPagamento(CommandUpdateFormaPagamento dto)
            => new FormaPagamento(dto.Id, dto.Nome, dto.CodFinalizadora, dto.Sigla);
    }
    public class CommandGetIdFormaPagamento : IRequest<FormaPagamentoResponseItem>
    {
        public string Id { get; set; }
    }
    public class CommandGetAllFormaPagamento : IRequest<FormaPagamentoResponse>
    {

    }
}
