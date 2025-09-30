using simple_pag_Application.Handler.Finalizadoras;
using simple_pag_Application.Handler.FormaPagamentos;
using simple_pag_Application.Handler.Login;
using simple_pag_Application.Handler.Usuarios;

namespace simple_pag.Middleware
{
    public static class ApplicationDependency
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(mdt => mdt.RegisterServicesFromAssemblyContaining<CadastrarFinalizadorHandler>());
            services.AddMediatR(mdt => mdt.RegisterServicesFromAssemblyContaining<CadastrarUsuarioHandler>());
            services.AddMediatR(mdt => mdt.RegisterServicesFromAssemblyContaining<CadastrarFormaPagamentoHandler>());
            services.AddMediatR(mdt => mdt.RegisterServicesFromAssemblyContaining<LoginHandler>());
            //services.AddMediatR(mdt => mdt.RegisterServicesFromAssemblyContaining<AuthorizationHandler>());
           
        }
    }
}
