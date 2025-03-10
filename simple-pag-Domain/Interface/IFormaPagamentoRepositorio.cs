using simple_pag_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_pag_Domain.Interface
{
    public interface IFormaPagamentoRepositorio
    {
        Task AddPagamento(FormaPagamento usuario);
        bool ExistePagamento(string sigla);
        IList<FormaPagamento> GetAllPagamentos();
        Task<FormaPagamento> FindPagamentoById(string id);
        Task InativarPagamento(string id);
        Task UpdateAsync(FormaPagamento dados);
    }
}
