using simple_pag_Domain.Entity;


namespace simple_pag_Domain.Shared.Interface
{
    public interface IFormaPagamentoRepositorio
    {
        Task CadastrarPagamento(Pagamento formaPagamento);
        Task<bool> ExistePagamento(string id);
        IList<Pagamento> ObterTodosPagamentos();
        Task<Pagamento> ObterPagamentoById(string id);
        Task InativarPagamento(Pagamento data);
        Task AtivarPagamento(Pagamento data);
        Task AlterarPagamento(Pagamento dados);
        Task<bool> ValidaSigladoPagamento(Pagamento dados);
        Task<IList<string>> ObterTodasSiglasdePagamento();
        Task<bool> ExistePagamentoNome(string nome);
    }
}
