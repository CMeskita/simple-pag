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
            services.AddMediatR(mdt => mdt.RegisterServicesFromAssemblyContaining<CreateFinalizadorHandler>());
            services.AddMediatR(mdt => mdt.RegisterServicesFromAssemblyContaining<CreateUsuarioHandler>());
            services.AddMediatR(mdt => mdt.RegisterServicesFromAssemblyContaining<CreateFormaPagamentoHandler>());
            services.AddMediatR(mdt => mdt.RegisterServicesFromAssemblyContaining<LoginHandler>());
            services.AddMediatR(mdt => mdt.RegisterServicesFromAssemblyContaining<AuthorizationHandler>());
           
        }
    }
}
