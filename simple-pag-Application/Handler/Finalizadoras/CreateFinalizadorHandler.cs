using Amazon.Runtime.Internal;
using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared;
using simple_pag_Domain.Shared.Interface;
using static simple_pag_Domain.Entity.Finalizadora;
using static simple_pag_Domain.Entity.FinalizadoraPagamento;


namespace simple_pag_Application.Handler.Finalizadoras
{
    public class CreateFinalizadorHandler : IRequestHandler<CommandFinalizadora, Response>
    {
        private readonly IFinalizadoraRepositorio _repository;
        private readonly IFormaPagamentoRepositorio _pagamentoepository;
        private readonly IUnityOffWork _unityOffWork;
        private decimal soma = 0;
        public CreateFinalizadorHandler(IFormaPagamentoRepositorio pagamento, IFinalizadoraRepositorio repository, IUnityOffWork unityOffWork)
        {
            _pagamentoepository = pagamento;
            _repository = repository;
            _unityOffWork = unityOffWork;
        }

        public async Task<Response> Handle(CommandFinalizadora request, CancellationToken cancellationToken)
        {
            try
            {
                _unityOffWork.BeginTransaction();
                Finalizadora finalizadora = request;

                Response validacao = ValidarFormaPagamento(request.Pagamentos);

                if (validacao.StatusCode != Constants_Code.STATUS_CODE_SUCCESS)
                {
                    return new Response
                    {
                        Message = validacao.Message,
                        StatusCode = validacao.StatusCode
                    };
                }
                
                foreach (var item in request.Pagamentos)
                {
                    soma += item.Valor;
                    var dados = new FinalizadoraPagamento(finalizadora.Id, item.Valor, item.QtdParcelas, item.Modalidade, item.PagamentoId);
                    await _repository.AddFinalizadoraPagamento(dados);
                }

                ValidaModalidadePAgamento(request, finalizadora);

                finalizadora.TotalPagamento(soma);
                await _repository.AddFinalizadora(finalizadora);


                _unityOffWork.CommitTransaction();

                return new Response { Message = Constants_Message.STATUS_CODE_CREATED, StatusCode = Constants_Code.STATUS_CODE_CREATED };
            }

            catch (BusinessException ex)
            {
                _unityOffWork.Rollback();
                return new Response { Message = ex.Message, StatusCode = Constants_Code.STATUS_CODE_BADREQUEST };

            }
            catch (Exception ex)
            {
                return new Response { Message = ex.Message, StatusCode = Constants_Code.STATUS_CODE_INTERNAL_SERVER_ERROR };
            }

        }
        public void ValidaModalidadePAgamento(CommandFinalizadora request,Finalizadora finalizadora) 
        {
            //se o pagamento for a vista, somente pix e dinheiro
            if (request.Pagamentos.All(p => (int)p.Modalidade == 1))
            {
                finalizadora.SetStatus(PagamentoStatus.Confirmado);
            }
            else
            {
                finalizadora.SetStatus(PagamentoStatus.Pendente);
            }
        }
        public Response ValidarFormaPagamento(List<CommandPagamentoFinalizadora> pagamentos)
        {
            if (pagamentos == null || pagamentos.Count == 0)
            {
                return new Response
                {
                    Message = "Nenhum pagamento informado",
                    StatusCode = Constants_Code.STATUS_CODE_BADREQUEST
                };
            }
            foreach (var item in pagamentos)
            {
                var validapagamento = _pagamentoepository.FindPagamentoById(item.PagamentoId).Result;

                if (validapagamento.Nome.Trim() == "PIX" || validapagamento.Nome.Trim() == "AVISTA")
                {
                    if (item.Modalidade != modalidadePagamento.AVISTA)
                    {

                        return new Response
                        {
                            Message = "Gentileza Trocar Forma de Pagamento",
                            StatusCode = Constants_Code.STATUS_CODE_BADREQUEST
                        };

                    }

                }
                else
                {
                    if (item.Modalidade != modalidadePagamento.PARCELADO)
                    {

                        return new Response
                        {
                            Message = "Gentileza Trocar Forma de Pagamento",
                            StatusCode = Constants_Code.STATUS_CODE_BADREQUEST
                        };

                    }
                }

            


            }
            return new Response
            {
                Message = "validado com sucesso",
                StatusCode = Constants_Code.STATUS_CODE_SUCCESS
            };


        }
    }
   
}
