
using Microsoft.EntityFrameworkCore;
using simple_pag_Domain.Entity;
using System.Reflection.Emit;

namespace simple_pag_Infra.Conection
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Finalizadora> Finalizadoras { get; set; }
        public DbSet<FinalizadoraPagamento> FinalizadoraPagamentos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Finalizadora>().HasKey(r => r.Id);
            modelbuilder.Entity<Pagamento>().HasKey(m => m.Id);
            modelbuilder.Entity<Usuario>().HasKey(s => s.Id);
            modelbuilder.Entity<FinalizadoraPagamento>().HasKey(b =>b.Id);

            base.OnModelCreating(modelbuilder);

        }
    }
}
