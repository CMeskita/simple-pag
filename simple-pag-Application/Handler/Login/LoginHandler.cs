using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Application.ServiceJWT;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;
using simple_pag_Domain.Shared.Models;


namespace simple_pag_Application.Handler.Login
{
    public class LoginHandler : IRequestHandler<CommandLogin, TokenResponse>
    {
        private readonly IUsuarioRepositorio _repositorio;
        private readonly ITokenService _tokenService;
        public LoginHandler(IUsuarioRepositorio repositorio, ITokenService tokenService)
        {
            _repositorio = repositorio;
            _tokenService = tokenService;
        }

        public async Task<TokenResponse> Handle(CommandLogin request, CancellationToken cancellationToken)
        {
            try
            {
                Usuario usuario = await _repositorio.GetUsuariobyEmail(request.Email);
                if (usuario.Email == null)
                {
                    return new TokenResponse
                    {
                        Message = "Usuário não encontrado",
                        StatusCode = 404
                    };
                }
                //var hash = request.Senha.StringHash();
                if (request.Senha.StringHash() != usuario.ChavePrivada)
                {
                    return new TokenResponse
                    {
                        Message = "Senha incorreta",
                        StatusCode = 401
                    };
                }

                var token = _tokenService.GerandoJWTTokens(usuario, 720);
                if (token == null)
                {
                    return new TokenResponse
                    {
                        Message = "Erro ao gerar token",
                        StatusCode = 500
                    };
                }
                var refreshtoken = _tokenService.GerandoJWTTokens(usuario, 120);
                if (refreshtoken == null)
                {
                    return new TokenResponse
                    {
                        Message = "Erro ao gerar token",
                        StatusCode = 500
                    };
                }
                return new TokenResponse
                {
                    Message = "Login realizado com sucesso",
                    StatusCode = 200,
                    Token = token.Access_Token,
                    RefreshToken = refreshtoken.Access_Token,
                };


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
