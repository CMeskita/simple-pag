using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Shared.Interface;


namespace simple_pag_Application.Handler.Finalizadoras
{
    public class GetIdFinlaizadoraHandler : IRequestHandler<CommandGetIdFinalizadora, List<FinalizadoraResponseItem>>
    {
        private readonly IFinalizadoraRepositorio _repository;

        public GetIdFinlaizadoraHandler(IFinalizadoraRepositorio repository)
        {
            _repository = repository;
        }

        public async Task<List<FinalizadoraResponseItem>> Handle(CommandGetIdFinalizadora request, CancellationToken cancellationToken)
        {
            try
            {
                var finalizadora = _repository.FindFinalizadoraById(request.Id).Result;
                var response = new List<FinalizadoraResponseItem>
                    (finalizadora.Select(f => new FinalizadoraResponseItem
                    {
                        Valor = f.Valor,
                        Parcelas = f.Parcelas,
                        Modalidade = f.Modalidade,
                        Pagamento = f.PagamentoId,
                        Vencimento = f.Vencimento
                    }));
                return response;

            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
