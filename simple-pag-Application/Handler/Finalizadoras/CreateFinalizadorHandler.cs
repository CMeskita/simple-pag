using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Interface;
using simple_pag_Domain.Entity;

using simple_pag_Domain.Models;


namespace simple_pag_Application.Handler.Finalizadoras
{
    public class CreateFinalizadorHandler : IRequestHandler<CommandFinalizadora, Response>
    {
        private readonly IFinalizadoraRepositorio _repository;
        private readonly ILogInformacaoRepositorio _logInformacaoRepositorio;
        private readonly IUnityOffWork _unityOffWork;

        public CreateFinalizadorHandler(IFinalizadoraRepositorio repository, ILogInformacaoRepositorio logInformacaoRepositorio, IUnityOffWork unityOffWork)
        {
            _repository = repository;
            _logInformacaoRepositorio = logInformacaoRepositorio;
            _unityOffWork = unityOffWork;
        }

        public async Task<Response> Handle(CommandFinalizadora request, CancellationToken cancellationToken)
        {
            try
            {
                Finalizadora dados = request;
                _unityOffWork.BeginTransaction();
                await _repository.AddFinalizadora(dados);

                Response response= new Response { Message = "Finalizadora Cadastrada com Sucesso", StatusCode = 201 };

                _ = _logInformacaoRepositorio.AddAsync(new LogInformation { Classe = "Finalizadora", Informacao = response.Message });
                _unityOffWork.CommitTransaction();
                return response;
            }
          
            catch (Exception ex)
            {
                _unityOffWork.Rollback();
                Response response = new Response { Message = ex.Message, StatusCode = 500};

                _ = _logInformacaoRepositorio.AddAsync(new LogInformation { Classe = "Finalizadora", Informacao = response.Message });
               
                return response;
            }

        }
    }
}
