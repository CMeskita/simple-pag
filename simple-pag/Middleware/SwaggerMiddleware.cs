using Microsoft.OpenApi.Models;
using System.Reflection;

namespace simple_pag.Middleware
{
    public  static class SwaggerMiddleware
    {
        public static void AddSwaggerMiddleware(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API - Pagamentos",
                    Version = "v1",
                    Description = "Pagamentos Simples.",
                 
                    Contact = new OpenApiContact
                    {
                        Name = "Danielle Mesquita",
                        Email = string.Empty,

                       // Url = new Uri("www.google.com")
                    },
                });


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                        {
                              new OpenApiSecurityScheme
                              {
                                  Reference = new OpenApiReference
                                  {
                                      Type = ReferenceType.SecurityScheme,
                                      Id = "Bearer"
                                  }
                              },
                             Array.Empty<string>()
            }
                });

             
            });

        }
    }
}

