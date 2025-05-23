using simple_pag_Infra.Conection;
using simple_pag_Domain.Interface;
using simple_pag_Domain.Entity;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace simple_pag_Infra.Repositories
{
    public class FormaPagamentoRepositorio : IFormaPagamentoRepositorio
    {
        private readonly Context _context;

        public FormaPagamentoRepositorio(Context context)
        {
            _context = context;
        }

        public async Task AddPagamento(FormaPagamento formaPagamento)
        {
            await _context.FormaPagamentos.AddAsync(formaPagamento);
            _context.SaveChanges();
        }

        public async Task<bool> ExistePagamento(string id)
        {
            return await _context.FormaPagamentos.AnyAsync(a => a.Id == id);
        }

        public async Task<FormaPagamento> FindPagamentoById(string id)
        {
            var data = await _context.FormaPagamentos.FindAsync(id);
            if (data == null)
            {
                data = new FormaPagamento();
                data.Notification.Add("Registro não encontrado");
            }
            return data;
        }

        public async Task<IList<FormaPagamento>> GetAllPagamentos()
        {
            return await _context.FormaPagamentos.ToListAsync();
        }

        public async Task InativarPagamento(FormaPagamento data)
        {
            data.InativarFormaPagamento();
            _context.FormaPagamentos.Attach(data).Property(x => x.Status).IsModified = true;
            await _context.SaveChangesAsync();
        }
        public async Task AtivarPagamento(FormaPagamento data)
        {
            data.AtivarFormaPagamento();
            _context.FormaPagamentos.Attach(data).Property(x => x.Status).IsModified = true;
            
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FormaPagamento dados)
        {
            _context.FormaPagamentos.Update(dados);
            _context.Entry(dados).Property(p => p.Status).IsModified = false;
            _context.Entry(dados).Property(x => x.Registro).IsModified = false;
            await _context.SaveChangesAsync();
        }

  
    }
}
