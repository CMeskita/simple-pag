using MediatR;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using static simple_pag_Domain.Entity.FinalizadoraPagamento;
using static simple_pag_Domain.Shared.Enums.Enums;

namespace simple_pag_Application.Command
{
    public class CommandFinalizadora : IRequest<Response>
    {
        public required string UsuarioId { get; set; }

        public List<CommandPagamentoFinalizadora> Pagamentos{ get; set; } = new List<CommandPagamentoFinalizadora>();

        public static implicit operator Finalizadora(CommandFinalizadora dto)
=> new Finalizadora(dto.UsuarioId);
    }

    public class CommandPagamentoFinalizadora
    {
      
        public required string FinalizadoraId { get; set; }
        public decimal Valor { get; set; }
        public int QtdParcelas { get; set; }

        public modalidadePagamento Modalidade { get; set; }

        public required string PagamentoId { get; set; }

        public static implicit operator FinalizadoraPagamento(CommandPagamentoFinalizadora dto)
=> new FinalizadoraPagamento(dto.FinalizadoraId,dto.Valor,dto.QtdParcelas,dto.Modalidade,dto.PagamentoId);
    }
    public class CommandObterTodasFinalizadora : IRequest<List<FinalizadoraResponse>>
    {
    }
    public class CommandObterFinalizadoraId : IRequest<List<FinalizadoraResponseItem>>
    {
        public required string Id { get; set; }
    }

    public class CommandObterFinalizadoraPorUsuarioId : IRequest<List<FinalizadoraResponse>>
    {
        public required string Id { get; set; }
    }
    public class CommandObterPagamentopotFinalizadora : IRequest<Response>
    {
        public required string Id { get; set; }
        public decimal Valor { get; set; }
        public required string UsuarioId { get; set; }
        public List<CommandAlterarPagamentoFinalizadora> Pagamentos { get; set; } = new List<CommandAlterarPagamentoFinalizadora>();

        public static implicit operator Finalizadora(CommandObterPagamentopotFinalizadora dto)
=> new Finalizadora(dto.Id,dto.Valor);
    }
    public class CommandAlterarPagamentoFinalizadora : IRequest<Response>
    {
        public required string Id { get; set; }
        public int QtdParcelas { get; set; }
        public modalidadePagamento Modalidade { get; set; }
        public DateTime Vencimento { get; set; }
    }
    
    public class CommandObterFinalizadoraPeriodo : IRequest<List<FinalizadoraResponse>>
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

    }
    public class CommandObterFinalizadoraMes : IRequest<List<FinalizadoraResponse>>
    {

        public int Mes { get; set; }
        public int Ano { get; set; }

    }
    public class CommandObterFinalizadoraAno : IRequest<List<FinalizadoraResponse>>
    {
        public int Ano { get; set; }

    }
    public class CommandCancelamentoFinalizadora : IRequest<Response>
    {

        public required string Id { get; set; }
      
    }
    

}
