using simple_pag_Domain.Entity;


namespace simple_pag_Domain.Shared.Interface
{
    public interface IFinalizadoraRepositorio
    {
        Task AddFinalizadora(Finalizadora usuario);
        IList<Finalizadora> GetAllFinalizadoras();
        Task<IList<FinalizadoraPagamento>> FindFinalizadoraById(string id);
        Task UpdateAsync(Finalizadora dados);
        decimal TotalPagamentos();
        int TotalQtdePagamentos();
        Task AddFinalizadoraPagamento(FinalizadoraPagamento dados);
        Task<IList<Finalizadora>> FindFinalizadoraByUsuarioId(string id);


    }
}
