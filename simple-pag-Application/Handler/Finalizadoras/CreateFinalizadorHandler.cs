using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared;
using simple_pag_Domain.Shared.Interface;


namespace simple_pag_Application.Handler.Finalizadoras
{
    public class CreateFinalizadorHandler : IRequestHandler<CommandFinalizadora, Response>
    {
        private readonly IFinalizadoraRepositorio _repository;
        //private readonly ILogInformacaoRepositorio _logInformacaoRepositorio;
        private readonly IUnityOffWork _unityOffWork;

        public CreateFinalizadorHandler(IFinalizadoraRepositorio repository, IUnityOffWork unityOffWork)
        {
            _repository = repository;
            //_logInformacaoRepositorio = logInformacaoRepositorio;
            _unityOffWork = unityOffWork;
        }

        public async Task<Response> Handle(CommandFinalizadora request, CancellationToken cancellationToken)
        {
            try
            {
                _unityOffWork.BeginTransaction();
                

                Finalizadora finalizadora = request;

                await _repository.AddFinalizadora(finalizadora);

                foreach (var item in request.Pagamentos)
                {
                    var dados = new FinalizadoraPagamento(finalizadora.Id,item.Valor,item.QtdParcelas,item.Modalidade,item.PagamentoId);

                    await _repository.AddFinalizadoraPagamento(dados);
                }
             

               

                //_ = _logInformacaoRepositorio.AddAsync(new LogInformation { Classe = "Finalizadora", Informacao = response.Message });
                _unityOffWork.CommitTransaction();

                return new Response { Message = Constants_Message.STATUS_CODE_CREATED, StatusCode = Constants_Code.STATUS_CODE_CREATED };
            }
          
            catch (BusinessException ex)
            {
                _unityOffWork.Rollback();
                return new Response { Message = ex.Message, StatusCode = Constants_Code.STATUS_CODE_BADREQUEST };

                //_ = _logInformacaoRepositorio.AddAsync(new LogInformation { Classe = "Finalizadora", Informacao = response.Message });

            }
            catch (Exception ex)
            {
                return new Response { Message = ex.Message, StatusCode = Constants_Code.STATUS_CODE_INTERNAL_SERVER_ERROR };
            }

        }
    }
}
