using MediatR;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace simple_pag_Application.Command
{
    public class CommandFinalizadora : IRequest<Response>
    {
        [Required()]
        public decimal Valor { get; set; }
        [Required()]
        public int QtdParcelas { get; set; }
        [Required()]
        public string Modalidade { get; set; }
        [Required()]
        public string Vencimento { get; set; }
        [Required()]
        public string FormaPagamento { get; set; }

        public static implicit operator Finalizadora(CommandFinalizadora dto)
=> new Finalizadora(dto.Valor, dto.QtdParcelas, dto.Modalidade, dto.Vencimento, dto.FormaPagamento);
    }
    public class CommandGetAllFinalizadora : IRequest<FinalizadoraResponse>
    {
        public int pageNumber { get; set; }//quantidade de registros por página
        public int pageSize { get; set; }//quantidade de páginas
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
