using Microsoft.EntityFrameworkCore;
using simple_pag_Domain.Interface;
using simple_pag_Infra.Conection;
using simple_pag_Infra.Repositories;

namespace simple_pag.Middleware
{
    public static class PersistenceDependency
    {
        private static string _bancopostgres = "";
      
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
           
            //conifgurando conexões
            if (services == null) throw new ArgumentNullException(nameof(services));

            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            _bancopostgres = Environment.GetEnvironmentVariable("DATABASE") + "";
    

            services.AddDbContext<Context>(opt =>
            {
                opt.UseNpgsql(_bancopostgres);
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            //Repositorys
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddScoped<IFinalizadoraRepositorio,FinalizadoraRepositorio>();
          
            



            //Patterns
            services.AddTransient<IUnityOffWork, UnityOffWork>();
        }
    }
}
