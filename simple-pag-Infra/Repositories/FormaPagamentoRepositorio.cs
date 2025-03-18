using simple_pag_Infra.Conection;
using simple_pag_Domain.Interface;
using simple_pag_Domain.Entity;
using Microsoft.EntityFrameworkCore;

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

        public bool ExistePagamento(string sigla)
        {
            throw new NotImplementedException();
        }

        public async Task<FormaPagamento> FindPagamentoById(string id)
        {
            return await _context.FormaPagamentos.FindAsync(id);
        }

        public async Task<IList<FormaPagamento>> GetAllPagamentos()
        {
            return await _context.FormaPagamentos.ToListAsync();
        }

        public Task InativarPagamento(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(FormaPagamento dados)
        {
            _context.FormaPagamentos.Update(dados);
            await _context.SaveChangesAsync();
        }

    }
}
