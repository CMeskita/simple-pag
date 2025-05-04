using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace simple_pag.Middleware
{
    public static class JwtMiddleware
    {
        private static string Auth = Environment.GetEnvironmentVariable("AUTHENTICATION") + "";
        public static void AddJwtMiddleware(this IServiceCollection services)
        {
            if (string.IsNullOrEmpty(Auth))
            {
                throw new InvalidOperationException("AUTHENTICATION não configurada.");
            }
            {
                var key = Encoding.ASCII.GetBytes(Auth);


                services.AddAuthorization(options =>
                {
                    options.AddPolicy("AdminPolicy", policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        policy.RequireRole("Admin");
                    });
                });

                services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
               .AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });


            }
        }
    }
}
