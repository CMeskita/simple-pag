using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared;
using simple_pag_Domain.Shared.Interface;
using static simple_pag_Domain.Entity.Finalizadora;
using static simple_pag_Domain.Entity.FinalizadoraPagamento;
using static simple_pag_Domain.Shared.Enums.Enums;


namespace simple_pag_Application.Handler.Finalizadoras
{
    public class CadastrarFinalizadorHandler : IRequestHandler<CommandFinalizadora, Response>
    {
        private readonly IFinalizadoraRepositorio _repository;
        private readonly IFormaPagamentoRepositorio _pagamentoepository;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IUnityOffWork _unityOffWork;
        private decimal soma = 0;
        public CadastrarFinalizadorHandler(IUsuarioRepositorio usuarioRepositorio, IFormaPagamentoRepositorio pagamento, IFinalizadoraRepositorio repository, IUnityOffWork unityOffWork)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _pagamentoepository = pagamento;
            _repository = repository;
            _unityOffWork = unityOffWork;
        }

        public async Task<Response> Handle(CommandFinalizadora request, CancellationToken cancellationToken)
        {
            try
            {
               
                Finalizadora finalizadora = request;

                AddFinalizadora(finalizadora, request);

                var validarUsuario = await _usuarioRepositorio.CheckUserIdlExist(request.UsuarioId);
                if (!validarUsuario)
                {
                    return new Response
                    {
                        Message = Constants_Message.STATUS_CODE_NOTFOUND + " - " + request.UsuarioId,
                        StatusCode = Constants_Code.STATUS_CODE_NOTFOUND
                    };
                }
                Response validacao =await ValidarFormaPagamento(request.Pagamentos);

                if (validacao.StatusCode != Constants_Code.STATUS_CODE_SUCCESS)
                {
                    return new Response
                    {
                        Message = validacao.Message,
                        StatusCode = validacao.StatusCode
                    };
                }
                _unityOffWork.BeginTransaction();

                foreach (var item in request.Pagamentos)
                {
                    //soma += item.Valor;
                    var dados = new FinalizadoraPagamento(finalizadora.Id, item.Valor, item.QtdParcelas, item.Modalidade, item.PagamentoId);
                    await _repository.CadastrarFinalizadoraPagamento(dados);
                }

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
                _unityOffWork.Rollback();
                return new Response { Message = ex.Message, StatusCode = Constants_Code.STATUS_CODE_INTERNAL_SERVER_ERROR };
            }

        }
        public void ValidaModalidadePagamento(CommandFinalizadora request, Finalizadora finalizadora)
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
        public async Task<Response> ValidarFormaPagamento(List<CommandPagamentoFinalizadora> pagamentos)
        {//Valida forma de pagamento com modalidade avista ou aprzao
            if (pagamentos == null || pagamentos.Count == 0)
            {
                return new Response
                {
                    Message = Pagamento_Modalidade.PAGAMENTO_MENSAGEM,
                    StatusCode = Constants_Code.STATUS_CODE_BADREQUEST
                };
            }
            foreach (var item in pagamentos)
            {
                var pagamento = await _pagamentoepository.ObterPagamentoById(item.PagamentoId);

                bool isAvista = pagamento.Nome.Trim() is Pagamento_Modalidade.AVISTA_PIX
                                                          or Pagamento_Modalidade.AVISTA_DINHEIRO
                                                          or Pagamento_Modalidade.AVISTA_TRANSFERENCIA;

                if (isAvista && !(item.Modalidade == modalidadePagamento.AVISTA && item.QtdParcelas == 0))
                {
                    return new Response
                    {
                        Message = Pagamento_Modalidade.AVISTA_MENSAGEM,
                        StatusCode = Constants_Code.STATUS_CODE_BADREQUEST
                    };
                }

                if (!isAvista && !(item.Modalidade == modalidadePagamento.PARCELADO && item.QtdParcelas > 0))
                {
                    return new Response
                    {
                        Message = "Verificar Modalidade Parcelado e Parcelas",
                        StatusCode = Constants_Code.STATUS_CODE_BADREQUEST
                    };
                }
            }

            return new Response
            {
                Message = "Validação realizada com sucesso",
                StatusCode = Constants_Code.STATUS_CODE_SUCCESS
            };

        }
        public void AddFinalizadora(Finalizadora finalizadora, CommandFinalizadora request)
        {
            if (finalizadora == null)
            {
                throw new ArgumentNullException(nameof(finalizadora), "Finalizadora não pode ser nula.");
            }
            soma = request.Pagamentos.Sum(p => p.Valor);

            finalizadora.TotalPagamento(soma);

            ValidaModalidadePagamento(request, finalizadora);

            _repository.CadastrarFinalizadora(finalizadora);

        }

    }
}
