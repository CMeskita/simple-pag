using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;

namespace simple_pag_Application.Handler.FormaPagamentos
{
    public class ObterTodasFormaPagamentoHandler : IRequestHandler<CommandObterTodasFormaPagamento, List<FormaPagamentoResponse>>
    {
        private readonly IFormaPagamentoRepositorio _formaPagamentoRepositorio;

        public ObterTodasFormaPagamentoHandler(IFormaPagamentoRepositorio formaPagamentoRepositorio)
        {
            _formaPagamentoRepositorio = formaPagamentoRepositorio;
        }

        public async Task<List<FormaPagamentoResponse>> Handle(CommandObterTodasFormaPagamento request, CancellationToken cancellationToken)
        {
            try
            {
               var ListaformaPagamentos =  _formaPagamentoRepositorio.ObterTodosPagamentos().ToList();
                var response = new List<FormaPagamentoResponse>
                    (ListaformaPagamentos.Select(pagamento => new FormaPagamentoResponse
                    {
                        Id = pagamento.Id,
                        Nome = pagamento.Nome,
                        CodFinalizadora = pagamento.CodFinalizadora,
                        Sigla = pagamento.Sigla,
                        Status = pagamento.Status
                    }));

                return response;
            }
            catch (Exception) { throw; }
        }

    }
}
