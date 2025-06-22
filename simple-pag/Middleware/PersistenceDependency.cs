using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using simple_pag_Application.ServiceJWT;
using simple_pag_Domain.Shared.Interface;
using simple_pag_Infra.Conection;
using simple_pag_Infra.MongoRepositorio;
using simple_pag_Infra.Repositories;

namespace simple_pag.Middleware
{
    public static class PersistenceDependency
    {
        private static string _bancopostgres = "";
        private static string _bancomongo = "";
        private static string _mongoname = "";

        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //variaveis de ambiente
            _bancopostgres = Environment.GetEnvironmentVariable("DATABASE") + "";
            _bancomongo = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING") + "";
            _mongoname = Environment.GetEnvironmentVariable("MONGO_DATABASE") + "";

            //conifgurando conexões
            if (services == null) throw new ArgumentNullException(nameof(services));

            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            //postgres
            services.AddDbContext<Context>(opt =>
            {
                opt.UseNpgsql(_bancopostgres);
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddScoped<IDbContextTransaction>(provider =>
            {
                var context = provider.GetService<Context>();
                if (context == null)
                    throw new InvalidOperationException("Context não pode ser nulo ao iniciar uma transação.");
                try
                {
                    return context.Database.BeginTransaction();
                }
                catch (Exception ex)
                {
                    // Log ou debug aqui
                    throw new InvalidOperationException("Erro ao iniciar transação: " + ex.Message, ex);
                }
            });

            ////Mongo


            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = _bancomongo ?? throw new InvalidOperationException("MONGO_CONNECTION_STRING não configurada.");
                options.DatabaseName = _mongoname ?? throw new InvalidOperationException("MONGO_DATABASE não configurado.");
            });
            //services.AddSingleton<IMongoClient>(sp =>
            //{
            //    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
            //    return new MongoClient(settings.ConnectionString);
            //});
            //services.AddScoped(sp =>
            ////{
            ////    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
            ////    var client = sp.GetRequiredService<IMongoClient>();
            ////    return client.GetDatabase(settings.DatabaseName);
            //});


            //Repositorys

            services.AddScoped<IFinalizadoraRepositorio, FinalizadoraRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            //services.AddScoped<ILogInformacaoRepositorio, LogInformacaoRepositorio>();
            services.AddScoped<IFormaPagamentoRepositorio, FormaPagamentoRepositorio>();
            services.AddScoped<ITokenService, TokenService>();

            //Patterns

            services.AddTransient<IUnityOffWork, UnityOffWork>();
        }
    }
}
