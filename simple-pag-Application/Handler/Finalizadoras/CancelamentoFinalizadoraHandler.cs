using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared;
using simple_pag_Domain.Shared.Interface;
using simple_pag_Infra.Conection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace simple_pag_Application.Handler.Finalizadoras
{
    public class CancelamentoFinalizadoraHandler : IRequestHandler<CommandCancelamentoFinalizadora, Response>
    {
        private readonly IFinalizadoraRepositorio _repository;
        private readonly IUnityOffWork _unityOffWork;

        public CancelamentoFinalizadoraHandler(IFinalizadoraRepositorio repository, IUnityOffWork unityOffWork)
        {
            _repository = repository;
            _unityOffWork = unityOffWork;
        }

        public async Task<Response> Handle(CommandCancelamentoFinalizadora request, CancellationToken cancellationToken)
        {

            try
            {

                var finalizadora = await _repository.ObterFinalizadora(request.Id);
                if (finalizadora.Notification.HasNotifications)
                {
                    return new Response {  StatusCode = Constants_Code.STATUS_CODE_NOTFOUND, Message = Constants_Message.STATUS_CODE_NOTFOUND };
                }
                _unityOffWork.BeginTransaction();
                await _repository.CancelamentoFinalizadora(finalizadora.Id);

                _unityOffWork.CommitTransaction();

                return new Response { Message = "Alterado com Sucesso", StatusCode = 200 };

            }
            catch (Exception)
            {
                _unityOffWork.Rollback();

                throw;
            }



        }
    }
}
