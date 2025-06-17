using simple_pag_Infra.Conection;
using simple_pag_Domain.Entity;
using Microsoft.EntityFrameworkCore;
using simple_pag_Domain.Shared.Interface;



namespace simple_pag_Infra.Repositories
{
    public class FormaPagamentoRepositorio : IFormaPagamentoRepositorio
    {
        private readonly Context _context;

        public FormaPagamentoRepositorio(Context context)
        {
            _context = context;
        }

        public async Task AddPagamento(Pagamento formaPagamento)
        {
            var maximoCod = await ObterUltimoCodFinalizadoraAsync() ?? 0;
            formaPagamento.SetCodPagamento(maximoCod + 1);
            await _context.Pagamentos.AddAsync(formaPagamento);
            _context.SaveChanges();
        }

        public async Task<bool> ExistePagamento(string id)
        {
            return await _context.Pagamentos.AnyAsync(a => a.Id == id);
        }
        public async Task<bool> ExistePagamentoNome(string nome)
        {
            return await _context.Pagamentos.AnyAsync(a => a.Nome == nome.Trim());
        }

        public async Task<Pagamento> FindPagamentoById(string id)
        {
            var data = await _context.Pagamentos.FindAsync(id);
            if (data == null)
            {
                data = new Pagamento();
                data.Notification.Add("Registro não encontrado");
            }
            return data;
        }

        public async Task<IList<Pagamento>> GetAllPagamentos()
        {
            return await _context.Pagamentos.ToListAsync();
        }

        public async Task InativarPagamento(Pagamento data)
        {
            data.InativarFormaPagamento();
            _context.Pagamentos.Attach(data).Property(x => x.Status).IsModified = true;
            await _context.SaveChangesAsync();
        }
        public async Task AtivarPagamento(Pagamento data)
        {
            data.AtivarFormaPagamento();
            _context.Pagamentos.Attach(data).Property(x => x.Status).IsModified = true;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pagamento dados)
        {
            _context.Pagamentos.Update(dados);
            _context.Entry(dados).Property(p => p.Status).IsModified = false;
            _context.Entry(dados).Property(x => x.Registro).IsModified = false;
            await _context.SaveChangesAsync();
        }
        public async Task<int?> ObterUltimoCodFinalizadoraAsync()
        {
            // Retorna o maior valor de CodFinalizadora ou null se não houver registros
            return await _context.Pagamentos.MaxAsync(p => (int?)p.CodFinalizadora);
        }
        public async Task<bool> ValidaSigla(Pagamento dados)
        {
            return await _context.Pagamentos.AnyAsync(a => a.Sigla == dados.Sigla && a.Id != dados.Id);
        }
        public async Task<IList<string>> GetAllPSiglas()
        {
            return await _context.Pagamentos.Select(s => s.Sigla).ToListAsync();
        }
    }
}
