using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;
using simple_pag_Domain.Shared.Models;

namespace simple_pag_Application.Handler.Usuarios
{
    public class CreateUsuarioHandler : IRequestHandler<CommandUsuario, Response>
    {
        private readonly IUsuarioRepositorio _repositorio;

        private readonly IUnityOffWork _unityOffWork;

        private CommandContatoUsuario ContatoUsuario = null;

        public CreateUsuarioHandler(IUsuarioRepositorio repositorio, IUnityOffWork unityOffWork)
        {
            _repositorio = repositorio;
            _unityOffWork = unityOffWork;
        }

        public async Task<Response> Handle(CommandUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                _unityOffWork.BeginTransaction();

                Usuario? usuario =  _repositorio.GetUsuariobyEmail(request.Email).Result; 
                if (usuario.Email != null)
                {
                    return new Response
                    {
                        Message = "Usuário já cadastrado",
                        StatusCode = 409
                    };
                }


                Usuario dados = request;
                
                await _repositorio.AddUsuario(dados);

                var contato = StringExtensions.ObjetoParaDicionario(dados);
               
                foreach (var item in contato)
                {
                    if (item.Key == "Email")
                    {
                         ContatoUsuario = new CommandContatoUsuario
                         {
                            Descricao = item.Key.ToString(),
                            Conteudo = item.Value.ToString(),                     
                            UsuarioId = dados.Id,
                         

                        };

                    }
                }
                await _repositorio.AddContatoUsuario(ContatoUsuario);

                _unityOffWork.CommitTransaction();

                return new Response { Message = "Dados Cadastrados com Sucesso", StatusCode = 201 };

            }
            catch (System.Exception ex)
            {
                _unityOffWork.Rollback();

                return new Response { Message = ex.Message, StatusCode = 500 };
            }
        }
    }
}
