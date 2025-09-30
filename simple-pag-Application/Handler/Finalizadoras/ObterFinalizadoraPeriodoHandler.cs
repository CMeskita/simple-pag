using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;

namespace simple_pag_Application.Handler.Finalizadoras
{
    public class ObterFinalizadoraPeriodoHandler : IRequestHandler<CommandObterFinalizadoraPeriodo, List<FinalizadoraResponse>>
    {
        private readonly IFinalizadoraRepositorio _repository;

        public ObterFinalizadoraPeriodoHandler(IFinalizadoraRepositorio repository)
        {
            _repository = repository;
        }

        public async Task<List<FinalizadoraResponse>> Handle(CommandObterFinalizadoraPeriodo request, CancellationToken cancellationToken)
        {
            try
            {
                ICollection<Finalizadora> listadefinalizadora =await _repository.ObterPagamentosPorPeriodo(request.Inicio,request.Fim);
                
                var response = new List<FinalizadoraResponse>();

                foreach (var item in listadefinalizadora)
                {
                    FinalizadoraResponse finalizadora = new FinalizadoraResponse
                    {
                        Id = item.Id,
                        Valor = item.Valor,
                        Registro = item.Registro,
                        
                    };

                    response.Add(finalizadora);
                }
              
             
                return response;

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
