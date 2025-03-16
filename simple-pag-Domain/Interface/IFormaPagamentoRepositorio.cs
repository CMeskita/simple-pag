using simple_pag_Domain.Entity;


namespace simple_pag_Domain.Interface
{
    public interface IFormaPagamentoRepositorio
    {
        Task AddPagamento(FormaPagamento formaPagamento);
        bool ExistePagamento(string sigla);
        Task<IList<FormaPagamento>> GetAllPagamentos();
        Task<FormaPagamento> FindPagamentoById(string id);
        Task InativarPagamento(string id);
        Task UpdateAsync(FormaPagamento dados);
    }
}
