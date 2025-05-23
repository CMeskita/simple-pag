using Microsoft.EntityFrameworkCore;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Interface;
using simple_pag_Infra.Conection;

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
        public async Task<Finalizadora> FindFinalizadoraById(string id)
        {
            var data = await _context.Finalizadoras.FindAsync(id);
            if (data == null)
            {
                data = new Finalizadora();
                data.Notification.Add("Registro não encontrado");
            }
            return data;
        }

        public async Task<IList<Finalizadora>> GetAllFinalizadoras()
        {
            return await _context.Finalizadoras.ToListAsync();
        }

        public async Task<IList<Finalizadora>> GetFinalizadorasPaginadas(int pageNumber, int pageSize)
        {
            return await _context.Finalizadoras
                .OrderBy(x => x.Registro) // Ordena por Valor
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public decimal TotalPagamentos()
        {
            decimal result = _context.Finalizadoras.Sum(x => x.Valor);
            return result;
        }
        public int TotalQtdePagamentos()
        {
            var result = _context.Finalizadoras.Count();
            return result;
        }
        public decimal TotalPagamentosAvista()
        {
            var result = _context.Finalizadoras.Where(x => x.QtdParcelas < 1).Sum(x => x.Valor);
            return result;
        }
        public decimal TotalPagamentosAPrazo()
        {
            var result = _context.Finalizadoras.Where(x => x.QtdParcelas >= 1).Sum(x => x.Valor);
            return result;
        }
        public async Task UpdateAsync(Finalizadora dados)
        {
            _context.Finalizadoras.Update(dados);
            _context.Entry(dados).Property(x => x.Registro).IsModified = false;           
            await _context.SaveChangesAsync();
        }
    }
}
