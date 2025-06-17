
using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Shared.Interface;

namespace simple_pag_Application.Handler.FormaPagamentos
{
    public class UpdateFormaPagamentoHandler : IRequestHandler<CommandUpdateFormaPagamento ,Response>
    {
        private readonly IFormaPagamentoRepositorio _fpRepository;

        public UpdateFormaPagamentoHandler(IFormaPagamentoRepositorio fpRepository)
        {
            _fpRepository = fpRepository;
        }
        public async Task<Response> Handle(CommandUpdateFormaPagamento request, CancellationToken cancellationToken)
        {
            try
            {
                var formapagamento = _fpRepository.FindPagamentoById(request.Id).Result;
                if (formapagamento == null)
                {
                    return new Response { Message = "Forma de pagamento não Existe", StatusCode = 404 };
                }

                await _fpRepository.UpdateAsync(request);

                return new Response { Message = "Alterado com Sucesso", StatusCode = 200 };
            }
            catch (Exception)
            {

                return new Response { Message = "Erro na Execução", StatusCode = 500 };
            }
        }
    }
}
