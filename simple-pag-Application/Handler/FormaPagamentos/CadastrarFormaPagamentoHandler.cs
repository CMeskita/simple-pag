using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;
using simple_pag_Domain.Shared.Models;
using simple_pag_Infra.Conection;
using System;

namespace simple_pag_Application.Handler.FormaPagamentos
{
    public class CadastrarFormaPagamentoHandler : IRequestHandler<CommandFormaPagamento, Response>
    {
        private readonly IFormaPagamentoRepositorio _formaPagamentoRepositorio;
        private readonly IUnityOffWork _unityOffWork;

        public CadastrarFormaPagamentoHandler(IFormaPagamentoRepositorio formaPagamentoRepositorio, IUnityOffWork unityOffWork)
        {
            _formaPagamentoRepositorio = formaPagamentoRepositorio;
            _unityOffWork = unityOffWork;
        }

        public async Task<Response> Handle(CommandFormaPagamento request, CancellationToken cancellationToken)
        {
            try
            {
                _unityOffWork.BeginTransaction();


                Pagamento dados = request;
                if (await _formaPagamentoRepositorio.ExistePagamentoNome(dados.Nome))
                {
                    return new Response { Message = "Já existe pagamento com esse nome", StatusCode = 404 };
                }

                VerificacaoSiglas(dados).Wait();

                await _formaPagamentoRepositorio.CadastrarPagamento(dados);


                _unityOffWork.CommitTransaction();


                return new Response { Message = "Cadastrado com sucesso.", StatusCode = 201 };
            }
            catch (Exception ex)
            {
                _unityOffWork.Rollback();
                return new Response { Message = ex.Message, StatusCode = 500 };
            }
        }
        public async Task<Pagamento> VerificacaoSiglas(Pagamento dados)
        {
            try
            {
                var proximaSigla = dados.Sigla;
                var verificaSigla = await _formaPagamentoRepositorio.ObterTodasSiglasdePagamento();
                int contador = 1;

                for (int i = 0; i < verificaSigla.Count; i++)
                {


                    if (verificaSigla.Contains(proximaSigla))
                    {

                        proximaSigla = StringExtensions.GerarSiglarefresh(dados.Nome, contador);
                        contador = contador + 1;

                    }
                }


                dados.SetSigla(proximaSigla);

               

                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar sigla: {ex.Message}");
            }
        }
    }
}
