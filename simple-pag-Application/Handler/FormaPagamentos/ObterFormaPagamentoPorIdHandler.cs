using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;

namespace simple_pag_Application.Handler.FormaPagamentos
{
    public class ObterFormaPagamentoPorIdHandler : IRequestHandler<CommandObterFormaPagamentoPorId, FormaPagamentoResponse>
    {
        private readonly IFormaPagamentoRepositorio _formaPagamentoRepositorio;

        public ObterFormaPagamentoPorIdHandler(IFormaPagamentoRepositorio formaPagamentoRepositorio)
        {
            _formaPagamentoRepositorio = formaPagamentoRepositorio;
        }

        public async Task<FormaPagamentoResponse> Handle(CommandObterFormaPagamentoPorId request, CancellationToken cancellationToken)
        {
            try
            {
                Pagamento formaPagamento = _formaPagamentoRepositorio.ObterPagamentoById(request.Id).Result;

                if (formaPagamento == null)
                {
                    return null;
                }
                FormaPagamentoResponse response = new FormaPagamentoResponse
                {
                    Id = formaPagamento.Id,
                    Nome = formaPagamento.Nome,
                    Sigla = formaPagamento.Sigla,
                    CodFinalizadora = formaPagamento.CodFinalizadora,
                    Status = formaPagamento.Status,
                };
                return response;
            }
            catch (Exception ) { throw; }
        }
    }
}
