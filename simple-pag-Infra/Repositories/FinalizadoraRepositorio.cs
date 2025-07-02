using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Linq;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;
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
        public async Task AddFinalizadora(Finalizadora dados)
        {
            await _context.Finalizadoras.AddAsync(dados);
            _context.SaveChanges();
          
        }
        public async Task AddFinalizadoraPagamento(FinalizadoraPagamento dados)
        {
            await _context.FinalizadoraPagamentos.AddAsync(dados);
            _context.SaveChanges();

        }
        public async Task<IList<FinalizadoraPagamento>> FindFinalizadoraById(string id)
        {
            var result=_context.FinalizadoraPagamentos.Where(p => p.FinalizadoraId == id).ToList();
            return result;
    }

        public IList<Finalizadora> GetAllFinalizadoras()
        {
            return  _context.Finalizadoras.OrderByDescending(r=>r.Registro).ToList();
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
        //public decimal TotalPagamentosAvista()
        //{
        //    var result = _context.Finalizadoras.Where(x => x.QtdParcelas < 1).Sum(x => x.Valor);
        //    return result;
        //}
        //public decimal TotalPagamentosAPrazo()
        //{
        //    var result = _context.Finalizadoras.Where(x => x.QtdParcelas >= 1).Sum(x => x.Valor);
        //    return result;
        //}
        public async Task UpdateAsync(Finalizadora dados)
        {
            _context.Finalizadoras.Update(dados);
            _context.Entry(dados).Property(x => x.Registro).IsModified = false;           
            await _context.SaveChangesAsync();
        }
        public async Task<Finalizadora> FindFinalizadorById(string id)
        {
            var data = await _context.Finalizadoras.FindAsync(id);
            if (data == null)
            {
                data = new Finalizadora();
                data.Notification.Add("Registro não encontrado");
            }
            return data;
        }
        public async Task<IList<Finalizadora>> FindFinalizadoraByUsuarioId(string id)
        {
            var result = _context.Finalizadoras.Where(p => p.UsuarioId == id).ToList();
            return result;
        }

    }
}
