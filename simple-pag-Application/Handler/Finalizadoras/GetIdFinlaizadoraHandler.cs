using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;


namespace simple_pag_Application.Handler.Finalizadoras
{
    public class GetIdFinlaizadoraHandler : IRequestHandler<CommandGetIdFinalizadora, FinalizadoraResponseItem>
    {
        private readonly IFinalizadoraRepositorio _repository;

        public GetIdFinlaizadoraHandler(IFinalizadoraRepositorio repository)
        {
            _repository = repository;
        }

        public async Task<FinalizadoraResponseItem> Handle(CommandGetIdFinalizadora request, CancellationToken cancellationToken)
        {
            try
            {
                Finalizadora finalizadora = _repository.FindFinalizadoraById(request.Id).Result;

                if (finalizadora == null)
                {
                    return null;
                }

                FinalizadoraResponseItem response = new FinalizadoraResponseItem
                {
                    Id = finalizadora.Id,
                    Valor = finalizadora.Valor,
                    QtdParcelas = finalizadora.QtdParcelas,
                    Modalidade = finalizadora.Modalidade,
                    Vencimento = finalizadora.Vencimento,
                    FormaPagamento = finalizadora.PagamentoId,
                };



                return response;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
