using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Interface;

namespace simple_pag_Application.Handler.Finalizadoras
{
    internal class GetAllFinalizadoraHandler : IRequestHandler<CommandGetAllFinalizadora, FinalizadoraResponse>
    {
        private readonly IFinalizadoraRepositorio _finalizadoraRepositorio;

        public GetAllFinalizadoraHandler(IFinalizadoraRepositorio finalizadoraRepositorio)
        {
            _finalizadoraRepositorio = finalizadoraRepositorio;
        }

        public async Task<FinalizadoraResponse> Handle(CommandGetAllFinalizadora request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Finalizadora> finalizadora =await _finalizadoraRepositorio.GetAllFinalizadoras();
                FinalizadoraResponse response = new FinalizadoraResponse
                {
                    Dados = finalizadora.Select(fin => new FinalizadoraResponseItem
                    {
                        Id = fin.Id,
                        Valor = fin.Valor,
                        QtdParcelas = fin.QtdParcelas,
                        Modalidade = fin.Modalidade,
                        Vencimento = fin.Vencimento,
                        FormaPagamento = fin.FormaPagamento

                    }).ToList(),

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
