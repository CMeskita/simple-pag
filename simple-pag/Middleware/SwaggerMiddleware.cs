using Microsoft.OpenApi.Models;
using System.Reflection;

namespace simple_pag.Middleware
{
    public  static class SwaggerMiddleware
    {
        public static void AddSwaggerMiddleware(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                // Configuração básica do Swagger
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API - Pagamentos",
                    Version = "v1",
                    Description = "API para gerenciamento de pagamentos simples.",
                    Contact = new OpenApiContact
                    {
                        Name = "Danielle Mesquita",
                        Email = string.Empty,
                        // Url = new Uri("https://www.seusite.com") // Adicione uma URL válida, se necessário
                    },
                });

                // Configuração de autenticação via JWT
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Insira o token JWT no cabeçalho usando o esquema Bearer. Exemplo: 'Bearer {seu_token}'",
                    // Para inserir o token JWT no Swagger UI com essas definições, siga estes passos:

                    // 1. Execute sua aplicação e acesse o Swagger UI (geralmente em /swagger).
                    // 2. Clique no botão "Authorize" no canto superior direito da interface do Swagger UI.
                    // 3. Na janela que abrir, insira o token JWT no campo de texto, precedido de "Bearer " (com espaço).
                    //    Exemplo: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...

                    // 4. Clique em "Authorize" para aplicar o token a todas as requisições protegidas.
                    // 5. Agora, ao testar endpoints protegidos, o Swagger enviará o token JWT no cabeçalho Authorization automaticamente.

                    // Nenhuma alteração de código é necessária, pois a configuração já está correta para o Swagger reconhecer o esquema "Bearer".
                });

                // Requisito de segurança para todas as operações
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        Array.Empty<string>() // Escopos vazios
                    }
                });

                // Adiciona comentários XML para documentação, se disponíveis
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    options.IncludeXmlComments(xmlPath);
                }
            });
        }
    }
}

