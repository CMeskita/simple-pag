using MediatR;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using System.Text.Json.Serialization;
namespace simple_pag_Application.Command
{
    public class CommandFormaPagamento : IRequest<Response>
    {
        public string? Nome { get; set; }

        public static implicit operator Pagamento(CommandFormaPagamento dto) => new Pagamento(dto.Nome);
    }

    public class CommandAlterarFormaPagamento : IRequest<Response> 
    {
        public string Id {  get; set; }
        public string Nome { get; set;}
        [JsonIgnore]
        public int CodFinalizadora { get; set; } = 0;
        [JsonIgnore]
        public string Sigla { get; set; } = string.Empty;
        public static implicit operator Pagamento(CommandAlterarFormaPagamento dto)
            => new Pagamento(dto.Id, dto.Nome, dto.CodFinalizadora, dto.Sigla);
    }
    public class CommandObterFormaPagamentoPorId : IRequest<FormaPagamentoResponse>
    {
        public string Id { get; set; }
    }
    public class CommandObterTodasFormaPagamento : IRequest<List<FormaPagamentoResponse>>
    {

    }
}
