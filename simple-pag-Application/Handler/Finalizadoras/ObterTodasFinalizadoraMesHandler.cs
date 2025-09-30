using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;


namespace simple_pag_Application.Handler.Finalizadoras
{
    public class ObterTodasFinalizadoraMesHandler : IRequestHandler<CommandObterFinalizadoraMes, List<FinalizadoraResponse>>
    {
        private readonly IFinalizadoraRepositorio _repository;

        public ObterTodasFinalizadoraMesHandler(IFinalizadoraRepositorio repository)
        {
            _repository = repository;
        }

        public  async Task<List<FinalizadoraResponse>> Handle(CommandObterFinalizadoraMes request, CancellationToken cancellationToken)
        {
            try
            {
                ICollection<Finalizadora> listadepagamentoporfinalizadora = await _repository.ObterPagamentosPorMes(request.Mes,request.Ano);

                var response = new List<FinalizadoraResponse>();

                foreach (var item in listadepagamentoporfinalizadora)
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
