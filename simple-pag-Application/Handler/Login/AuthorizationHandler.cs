
using MediatR;
using Microsoft.AspNetCore.Http;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Application.ServiceJWT;

namespace simple_pag_Application.Handler.Login
{
    public class AuthorizationHandler : IRequestHandler<CommandAuthorization, AuthResponse>
    {
        private readonly ITokenService _tokenService;

        public AuthorizationHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<AuthResponse> Handle(CommandAuthorization request, CancellationToken cancellationToken)
        {
            try
            {

                var session = request.authorizationHeader;
                _tokenService.ValidandoTokenExpirado(session);

                return new AuthResponse
                {
                    IsAuthorized = true 
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
