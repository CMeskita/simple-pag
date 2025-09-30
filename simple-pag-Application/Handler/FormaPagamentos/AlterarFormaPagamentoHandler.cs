
using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Funcao;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;
using simple_pag_Domain.Shared.Models;
using simple_pag_Infra.Repositories;

namespace simple_pag_Application.Handler.FormaPagamentos
{
    public class AlterarFormaPagamentoHandler : IRequestHandler<CommandAlterarFormaPagamento ,Response>
    {
        private readonly IFormaPagamentoRepositorio _repository;

        public AlterarFormaPagamentoHandler(IFormaPagamentoRepositorio fpRepository)
        {
            _repository = fpRepository;
        }
        public async Task<Response> Handle(CommandAlterarFormaPagamento request, CancellationToken cancellationToken)
        {
            try
            {
                var novasigla = "";
                var formapagamento = _repository.ObterPagamentoById(request.Id).Result;
                if (formapagamento == null)
                {
                    return new Response { Message = "Forma de pagamento não Existe", StatusCode = 404 };
                }
                var sigla = await _repository.ObterTodasSiglasdePagamento();
                for (int i = 0; i < sigla.Count; i++)
                { int contador = 1;
                    if (sigla.Contains(novasigla))
                    {
                        novasigla = StringExtensions.GerarSiglarefresh(request.Nome, contador);
                    }
                    contador += contador;
                }

                if (sigla.Contains(novasigla))
                {
                   var proximaSigla = await ValidarSiglasCadastradas.VerificacaoSiglas(request, sigla);
                    formapagamento.SetSigla(proximaSigla.Sigla);
                }

                await _repository.AlterarPagamento(formapagamento);

                return new Response { Message = "Alterado com Sucesso", StatusCode = 200 };
            }
            catch (Exception)
            {

                return new Response { Message = "Erro na Execução", StatusCode = 500 };
            }
        }
    }
}
