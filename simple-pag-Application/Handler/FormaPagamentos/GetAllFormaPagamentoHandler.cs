using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;

namespace simple_pag_Application.Handler.FormaPagamentos
{
    public class GetAllFormaPagamentoHandler : IRequestHandler<CommandGetAllFormaPagamento, FormaPagamentoResponse>
    {
        private readonly IFormaPagamentoRepositorio _formaPagamentoRepositorio;

        public GetAllFormaPagamentoHandler(IFormaPagamentoRepositorio formaPagamentoRepositorio)
        {
            _formaPagamentoRepositorio = formaPagamentoRepositorio;
        }

        public async Task<FormaPagamentoResponse> Handle(CommandGetAllFormaPagamento request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Pagamento> formaPagamentos = await _formaPagamentoRepositorio.GetAllPagamentos();
                FormaPagamentoResponse response = new FormaPagamentoResponse
                {
                    Lista = formaPagamentos.Select(fp => new FormaPagamentoResponseItem
                    {
                        Id = fp.Id,
                        Nome = fp.Nome,
                        CodFinalizadora = fp.CodFinalizadora.ToString(),
                        Sigla = fp.Sigla,
                        Status = fp.Status
                    }).ToList(),
                };
                return response;
            }
            catch (Exception) { throw; }
        }

    }
}
