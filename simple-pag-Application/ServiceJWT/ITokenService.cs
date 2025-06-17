using Newtonsoft.Json.Linq;
using simple_pag_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using simple_pag_Domain.Shared.Models;

namespace simple_pag_Application.ServiceJWT
{
    public interface ITokenService
    {
        Tokens GerandoJWTTokens(Usuario user,int time);
        ClaimsPrincipal ValidandoTokenExpirado(string token);
        string ObterEmailToken(string token);
        //string GenerateTokens();
        // RefreshToken GerandoRefreshToken(Usuario user);

        //bool ValidToken(string token);
    }
}
