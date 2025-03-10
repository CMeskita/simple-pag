
using simple_pag_Application.Handler.Finalizadoras;

namespace simple_pag.Middleware
{

    public static class ApplicationDependency
    {

        public static void AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(mdt => mdt.RegisterServicesFromAssemblyContaining<CreateFinalizadorHandler>());
    


        }
    }
}
