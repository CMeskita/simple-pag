
using Microsoft.EntityFrameworkCore;
using simple_pag_Domain.Entity;
using simple_pag_Infra.Mapping;
using simple_pag_Domain.Shared.Interface;
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
        public DbSet<Contato> Contatos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            modelbuilder.ApplyConfiguration(new ContatoMap());
            modelbuilder.ApplyConfiguration(new FinalizadoraMap());
            modelbuilder.ApplyConfiguration(new FinalizadoraPagamentoMap());
            modelbuilder.ApplyConfiguration(new PagamentosMap());
            modelbuilder.ApplyConfiguration(new UsuarioMap());


            modelbuilder.Entity<Finalizadora>().HasKey(r => r.Id);
            modelbuilder.Entity<Pagamento>().HasKey(m => m.Id);
            modelbuilder.Entity<Usuario>().HasKey(s => s.Id);
            modelbuilder.Entity<FinalizadoraPagamento>().HasKey(b =>b.Id);
            modelbuilder.Entity<Contato>().HasKey(b => b.Id);
            base.OnModelCreating(modelbuilder);


            // Filtro global para todas as entidades que implementam ISoftDeletable
            foreach (var entityType in modelbuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(Context) // ou o nome do seu DbContext
                        .GetMethod(nameof(ConfigureSoftDeleteFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                        .MakeGenericMethod(entityType.ClrType);

                    method.Invoke(null, new object[] { modelbuilder });
                }
            }

        }
        private static void ConfigureSoftDeleteFilter<TEntity>(ModelBuilder model) where TEntity : class, ISoftDeletable
        {
            model.Entity<TEntity>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
