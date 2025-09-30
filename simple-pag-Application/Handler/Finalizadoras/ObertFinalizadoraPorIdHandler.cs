using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Shared.Interface;


namespace simple_pag_Application.Handler.Finalizadoras
{
    public class ObertFinalizadoraPorIdHandler : IRequestHandler<CommandObterFinalizadoraId, List<FinalizadoraResponseItem>>
    {
        private readonly IFinalizadoraRepositorio _repository;

        public ObertFinalizadoraPorIdHandler(IFinalizadoraRepositorio repository)
        {
            _repository = repository;
        }

        public async Task<List<FinalizadoraResponseItem>> Handle(CommandObterFinalizadoraId request, CancellationToken cancellationToken)
        {
            try
            {
                var finalizadora = _repository.ObterPagamentoporFinalizadoraId(request.Id).Result;
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
