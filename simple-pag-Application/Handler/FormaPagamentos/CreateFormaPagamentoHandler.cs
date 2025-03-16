using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Interface;
using simple_pag_Infra.Conection;
using System;

namespace simple_pag_Application.Handler.FormaPagamentos
{
    public class CreateFormaPagamentoHandler : IRequestHandler<CommandFormaPagamento, Response>
    {
        private readonly IFormaPagamentoRepositorio _formaPagamentoRepositorio;
        private readonly IUnityOffWork _unityOffWork;

        public CreateFormaPagamentoHandler(IFormaPagamentoRepositorio formaPagamentoRepositorio , IUnityOffWork unityOffWork)
        {
            _formaPagamentoRepositorio = formaPagamentoRepositorio;
            _unityOffWork = unityOffWork;
        }

        public async Task<Response> Handle(CommandFormaPagamento request, CancellationToken cancellationToken)
        {
            try
            {
                _unityOffWork.BeginTransaction();
                FormaPagamento dados = request;
                await _formaPagamentoRepositorio.AddPagamento(dados);
                _unityOffWork.CommitTransaction();
                return new Response { Message = "Cadastrado com sucesso.", StatusCode = 201 };
            }
            catch (Exception ex)
            {
                _unityOffWork.Rollback();
                return new Response { Message = ex.Message, StatusCode = 500 };
            }
        }
    }
}
