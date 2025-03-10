using simple_pag_Domain.Entity;
using simple_pag_Domain.Interface;
using simple_pag_Infra.Conection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_pag_Infra.Repositories
{
    public class FinalizadoraRepositorio : IFinalizadoraRepositorio
    {
        private readonly Context _context;

        public FinalizadoraRepositorio(Context context)
        {
            _context = context;
        }
        public async Task AddFinalizadora(Finalizadora finalizadora)
        {
            await _context.Finalizadoras.AddAsync(finalizadora);
            _context.SaveChanges();
          
        }

        public bool ExisteFinalizadora(string sigla)
        {
            throw new NotImplementedException();
        }

        public Task<Finalizadora> FindFinalizadoraById(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Finalizadora> GetAllFinalizadoras()
        {
            throw new NotImplementedException();
        }

        public Task InativarFinalizadora(string id)
        {
            throw new NotImplementedException();
        }

        public decimal TotalPagamentos()
        {
            throw new NotImplementedException();
        }

        public decimal TotalPagamentosAPrazo()
        {
            throw new NotImplementedException();
        }

        public decimal TotalPagamentosAvista()
        {
            throw new NotImplementedException();
        }

        public int TotalQtdePagamentos()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Finalizadora dados)
        {
            throw new NotImplementedException();
        }
    }
}
