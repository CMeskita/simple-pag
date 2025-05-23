using simple_pag_Domain.Entity;


namespace simple_pag_Domain.Interface
{
    public interface IFormaPagamentoRepositorio
    {
        Task AddPagamento(FormaPagamento formaPagamento);
        Task<bool> ExistePagamento(string id);
        Task<IList<FormaPagamento>> GetAllPagamentos();
        Task<FormaPagamento> FindPagamentoById(string id);
        Task InativarPagamento(FormaPagamento data);
        Task AtivarPagamento(FormaPagamento data);
        Task UpdateAsync(FormaPagamento dados);
    }
}
