using simple_pag_Domain.Entity;


namespace simple_pag_Domain.Shared.Interface
{
    public interface IFormaPagamentoRepositorio
    {
        Task AddPagamento(Pagamento formaPagamento);
        Task<bool> ExistePagamento(string id);
        Task<IList<Pagamento>> GetAllPagamentos();
        Task<Pagamento> FindPagamentoById(string id);
        Task InativarPagamento(Pagamento data);
        Task AtivarPagamento(Pagamento data);
        Task UpdateAsync(Pagamento dados);
        Task<bool> ValidaSigla(Pagamento dados);
        Task<IList<string>> GetAllPSiglas();
        Task<bool> ExistePagamentoNome(string nome);
    }
}
