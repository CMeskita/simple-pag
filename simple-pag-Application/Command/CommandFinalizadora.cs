using MediatR;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;

namespace simple_pag_Application.Command
{
    public class CommandFinalizadora : IRequest<Response>
    {
        public decimal Valor { get; set; }
        public int QtdParcelas { get; set; }
        public string Modalidade { get; set; }
        public string Vencimento { get; set; }
        public string FormaPagamento { get; set; }

        public static implicit operator Finalizadora(CommandFinalizadora dto)
=> new Finalizadora(dto.Valor, dto.QtdParcelas, dto.Modalidade, dto.Vencimento, dto.FormaPagamento);
    }
    public class CommandGetAllFinalizadora : IRequest<FinalizadoraResponse>
    {
    }
    public class CommandGetIdFinalizadora : IRequest<FinalizadoraResponseItem>
    {
        public string Id { get; set; }
    }
    public class CommandUpdateFinalizadora : IRequest<Response>
    {
        public string Id { get; set; }
        public decimal Valor { get; set; }
        public int QtdParcelas { get; set; }
        public string Modalidade { get; set; }
        public string Vencimento { get; set; }
        public string FormaPagamento { get; set; }

        public static implicit operator Finalizadora(CommandUpdateFinalizadora dto)
=> new Finalizadora(dto.Id,dto.Valor, dto.QtdParcelas, dto.Modalidade, dto.Vencimento, dto.FormaPagamento);
    }
}
