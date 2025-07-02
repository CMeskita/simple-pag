using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_pag_Application.Handler.Finalizadoras
{
    public class GetUserIdFinalizadoraHandler : IRequestHandler<CommandGetIdUsuarioFinalizadora, List<FinalizadoraResponse>>
    {
        private readonly IFinalizadoraRepositorio _repository;

        public GetUserIdFinalizadoraHandler(IFinalizadoraRepositorio repository)
        {
            _repository = repository;
        }

        public Task<List<FinalizadoraResponse>> Handle(CommandGetIdUsuarioFinalizadora request, CancellationToken cancellationToken)
        {
            try
            {
                var finalizadora = _repository.FindFinalizadoraByUsuarioId(request.Id).Result;
                var response = new List<FinalizadoraResponse>
                    (finalizadora.Select(f => new FinalizadoraResponse
                    {
                        Id = f.Id,
                        Valor = f.Valor,
                        Registro = f.Registro,

                    }));
            return Task.FromResult(response);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
