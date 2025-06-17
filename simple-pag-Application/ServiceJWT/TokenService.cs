using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace simple_pag_Application.ServiceJWT
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TokenService> _logger;
        private static readonly string Auth = Environment.GetEnvironmentVariable("AUTHENTICATION") ?? string.Empty;
        private static readonly byte[] Keytoken = Encoding.UTF8.GetBytes(Auth);

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            if (string.IsNullOrEmpty(Auth) || Auth.Length < 32)
            {
                throw new InvalidOperationException("A chave de autenticação deve ser configurada e ter pelo menos 32 caracteres.");
            }
         
        }

        public Tokens GerandoJWTTokens(Usuario user, int time)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = CreateTokenDescriptor(user, time);
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return new Tokens(
                    tokenHandler.WriteToken(token),
                    user.Id,
                    tokenDescriptor.Expires ?? DateTime.UtcNow
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao gerar o token para o usuário {Email}", user.Email);
                throw new InvalidOperationException("Erro ao gerar o token.", ex);
            }
        }
        private SecurityTokenDescriptor CreateTokenDescriptor(Usuario user, int time)
        {
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(JwtRegisteredClaimNames.Name, user.Nome),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(time),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Keytoken), SecurityAlgorithms.HmacSha256Signature)
            };
        }

        public ClaimsPrincipal ValidandoTokenExpirado(string token)
        {
            

            var parametroDeValidacao = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Keytoken),
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var validandoToken = tokenHandler.ValidateToken(token, parametroDeValidacao, out SecurityToken securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return validandoToken;
        }

        public string ObterEmailToken(string token)
        {
            var principal = ValidandoTokenExpirado(token);
            var claims = principal.Identities.First().Claims.ToList();
            var email = claims?.FirstOrDefault(x => x.Type.Equals("name", StringComparison.CurrentCultureIgnoreCase))?.Value?.Trim();

            if (email == null)
            {
                throw new InvalidOperationException("O token não contém um e-mail válido.");
            }

            return email;
        }
    }
}
