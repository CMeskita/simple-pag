using simple_pag_Domain.Entity;
using System;


namespace simple_pag_Domain.Interface
{
    public interface IFinalizadoraRepositorio
    {
        Task AddFinalizadora(Finalizadora usuario);
        bool ExisteFinalizadora(string sigla);
        Task<IList<Finalizadora>> GetAllFinalizadoras();
        Task<Finalizadora> FindFinalizadoraById(string id);
        Task InativarFinalizadora(string id);
        Task UpdateAsync(Finalizadora dados);
        decimal TotalPagamentos();
        int TotalQtdePagamentos();
        decimal TotalPagamentosAvista();
        decimal TotalPagamentosAPrazo();
        //Task AddFinalizadoraPagamento(FinalizadoraPagamento dados);
    }
}
