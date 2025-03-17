

using simple_pag_Application.Handler.Finalizadoras;
<<<<<<< Updated upstream
using simple_pag_Application.Handler.Usuarios;
=======
using simple_pag_Application.Handler.FormaPagamentos;
>>>>>>> Stashed changes

namespace simple_pag.Middleware
{

    public static class ApplicationDependency
    {

        public static void AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(mdt => mdt.RegisterServicesFromAssemblyContaining<CreateFinalizadorHandler>());
<<<<<<< Updated upstream
            services.AddMediatR(mdt => mdt.RegisterServicesFromAssemblyContaining<CreateUsuarioHandler>());


=======
            services.AddMediatR(mdt => mdt.RegisterServicesFromAssemblyContaining<CreateFormaPagamentoHandler>());
>>>>>>> Stashed changes


        }
    }
}
