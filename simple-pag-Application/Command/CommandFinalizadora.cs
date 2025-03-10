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
}
