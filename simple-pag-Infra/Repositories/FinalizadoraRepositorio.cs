using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
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
        public async Task CadastrarFinalizadora(Finalizadora dados)
        {
            await _context.Finalizadoras.AddAsync(dados);
            _context.SaveChanges();
          
        }
        public async Task CadastrarFinalizadoraPagamento(FinalizadoraPagamento dados)
        {
            await _context.FinalizadoraPagamentos.AddAsync(dados);
            _context.SaveChanges();

        }
        public async Task<IList<FinalizadoraPagamento>> ObterPagamentoporFinalizadoraId(string id)
        {
            var result=_context.FinalizadoraPagamentos.Where(p => p.FinalizadoraId == id).ToList();
            return result;
    }

        public IList<Finalizadora> ObterTodasFinalizadoras()
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
    
        public async Task<bool> CancelamentoFinalizadora(string id)
        {

            var data = await _context.Finalizadoras.FindAsync(id);

            if (data is null) return false;

            data.Delete();

            if (data.Notification.HasNotifications)
                return false;

            _context.Entry(data).Property(p => p.IsDeleted).IsModified = true;
            _context.Entry(data).Property(p => p.DeletedAt).IsModified = true;
            _context.Finalizadoras.Update(data);
            await _context.SaveChangesAsync();

            return true;
        }
            public async Task<Finalizadora> FindFinalizadorById(string id)
        {
           var finalizadoras = _context.Finalizadoras
                .Include(p => p.FinalizadoraPagamentos)
                .ThenInclude(fp => fp.Pagamentos)
                .FirstOrDefault(p => p.Id == id);
   
            return finalizadoras;
        }

        public async Task<Finalizadora> ObterFinalizadora(string id) 
        {
            var result = _context.Finalizadoras.Where(p => p.Id == id).FirstOrDefault();
            if (result == null)
            {
                result = new Finalizadora();
                result.Notification.Add("Finalizadora não encontrada");
            }
            return result;


        }
        public async Task<IList<Finalizadora>> FindFinalizadoraByUsuarioId(string id)
        {
            var result = _context.Finalizadoras.Where(p => p.UsuarioId == id).ToList();
            return result;
        }
        public async Task<IList<Finalizadora>> ObterPagamentosPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            var t = DateTime.SpecifyKind(dataInicio, DateTimeKind.Utc);
            var f = DateTime.SpecifyKind(dataFim, DateTimeKind.Utc);

            var result = _context.Finalizadoras
                 .Where(p => p.Registro >= t && p.Registro <= f).ToList();              

            return result;
        }
        public async Task<IList<Finalizadora>> ObterPagamentosPorMes(int mes,int ano)
        {

            var result = _context.Finalizadoras
                .Where(x => x.Registro.Month == mes && x.Registro.Year == ano).ToList();

            return result;
        }
        public async Task<IList<Finalizadora>> ObterPagamentosPorAno(int ano)
        {

            var result = _context.Finalizadoras
                .Where(x => x.Registro.Year == ano).ToList();

            return result;
        }

    }
}
