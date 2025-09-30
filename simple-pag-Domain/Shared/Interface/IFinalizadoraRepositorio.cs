using simple_pag_Domain.Entity;


namespace simple_pag_Domain.Shared.Interface
{
    public interface IFinalizadoraRepositorio
    {
        Task CadastrarFinalizadora(Finalizadora usuario);
        IList<Finalizadora> ObterTodasFinalizadoras();
        Task<IList<FinalizadoraPagamento>> ObterPagamentoporFinalizadoraId(string id);
        Task<Finalizadora> FindFinalizadorById(string id);
        Task<bool> CancelamentoFinalizadora(string id);
        decimal TotalPagamentos();
        int TotalQtdePagamentos();
        Task CadastrarFinalizadoraPagamento(FinalizadoraPagamento dados);
        Task<IList<Finalizadora>> FindFinalizadoraByUsuarioId(string id);
        Task<IList<Finalizadora>> ObterPagamentosPorPeriodo(DateTime dataInicio, DateTime dataFim);
        Task<IList<Finalizadora>> ObterPagamentosPorMes(int mes, int ano);
        Task<IList<Finalizadora>> ObterPagamentosPorAno(int ano);
        Task<Finalizadora> ObterFinalizadora(string id);
    }
}
