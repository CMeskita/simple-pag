using simple_pag_Domain.Entity;
using System;


namespace simple_pag_Domain.Interface
{
    public interface IFinalizadoraRepositorio
    {
        Task AddFinalizadora(Finalizadora usuario);
        Task<IList<Finalizadora>> GetAllFinalizadoras();
        Task<Finalizadora> FindFinalizadoraById(string id);     
        Task UpdateAsync(Finalizadora dados);
        decimal TotalPagamentos();
        int TotalQtdePagamentos();
        decimal TotalPagamentosAvista();
        decimal TotalPagamentosAPrazo();
        Task<IList<Finalizadora>> GetFinalizadorasPaginadas(int pageNumber, int pageSize);
      
    }
}
