using MediatR;
using simple_pag_Application.Repsonse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_pag_Application.Command
{
    public class CommandLogin : IRequest<TokenResponse>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
    public class CommandAuthorization : IRequest<AuthResponse>
    {
        [Required()]
        public string Session { get; set; }
        [Required()]
        public string authorizationHeader { get; set; }
        
    }
}
