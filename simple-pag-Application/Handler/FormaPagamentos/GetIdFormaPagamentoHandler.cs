using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Interface;

namespace simple_pag_Application.Handler.FormaPagamentos
{
    public class GetIdFormaPagamentoHandler : IRequestHandler<CommandGetIdFormaPagamento, FormaPagamentoResponseItem>
    {
        private readonly IFormaPagamentoRepositorio _formaPagamentoRepositorio;

        public GetIdFormaPagamentoHandler(IFormaPagamentoRepositorio formaPagamentoRepositorio)
        {
            _formaPagamentoRepositorio = formaPagamentoRepositorio;
        }

        public async Task<FormaPagamentoResponseItem> Handle(CommandGetIdFormaPagamento request, CancellationToken cancellationToken)
        {
            try
            {
                FormaPagamento formaPagamento = _formaPagamentoRepositorio.FindPagamentoById(request.Id).Result;

                if (formaPagamento == null)
                {
                    return null;
                }
                FormaPagamentoResponseItem response = new FormaPagamentoResponseItem
                {
                    Id = formaPagamento.Id,
                    Nome = formaPagamento.Nome,
                    Sigla = formaPagamento.Sigla,
                    Status = formaPagamento.Status,
                };
                return response;
            }
            catch (Exception ) { throw; }
        }
    }
}
