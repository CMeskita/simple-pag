using MediatR;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using static simple_pag_Domain.Entity.FinalizadoraPagamento;

namespace simple_pag_Application.Command
{
    public class CommandFinalizadora : IRequest<Response>
    {
        public string UsuarioId { get; set; }

        public List<CommandPagamentoFinalizadora> Pagamentos{ get; set; } = new List<CommandPagamentoFinalizadora>();

        public static implicit operator Finalizadora(CommandFinalizadora dto)
=> new Finalizadora(dto.UsuarioId);
    }

    public class CommandPagamentoFinalizadora
    {
      
        public string FinalizadoraId { get; set; }
        public decimal Valor { get; set; }
        public int QtdParcelas { get; set; }

        public modalidadePagamento Modalidade { get; set; }

        public string PagamentoId { get; set; }

        public static implicit operator FinalizadoraPagamento(CommandPagamentoFinalizadora dto)
=> new FinalizadoraPagamento(dto.FinalizadoraId,dto.Valor,dto.QtdParcelas,dto.Modalidade,dto.PagamentoId);
    }
    public class CommandGetAllFinalizadora : IRequest<List<FinalizadoraResponse>>
    {
        //public int pageNumber { get; set; }//quantidade de registros por página
        //public int pageSize { get; set; }//quantidade de páginas
    }
    public class CommandGetIdFinalizadora : IRequest<List<FinalizadoraResponseItem>>
    {
        public string Id { get; set; }
    }
    public class CommandGetIdUsuarioFinalizadora : IRequest<List<FinalizadoraResponse>>
    {
        public string Id { get; set; }
    }
    public class CommandUpdateFinalizadora : IRequest<Response>
    {
        public string Id { get; set; }
        public decimal Valor { get; set; }
        public int QtdParcelas { get; set; }
        public modalidadePagamento Modalidade { get; set; }
        public string Vencimento { get; set; }
        public string FormaPagamento { get; set; }

        public static implicit operator Finalizadora(CommandUpdateFinalizadora dto)
=> new Finalizadora(dto.Id,dto.Valor);
    }
}
