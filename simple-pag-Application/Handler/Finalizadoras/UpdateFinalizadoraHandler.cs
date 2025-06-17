using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Shared.Interface;


namespace simple_pag_Application.Handler.Finalizadoras
{
    public class UpdateFinalizadoraHandler : IRequestHandler<CommandUpdateFinalizadora, Response>
    {
        private readonly IFinalizadoraRepositorio _repository;

        public UpdateFinalizadoraHandler(IFinalizadoraRepositorio repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(CommandUpdateFinalizadora request, CancellationToken cancellationToken)
        {
            try
            {
                var finalizadora = _repository.FindFinalizadoraById(request.Id).Result;
                if (finalizadora == null)
                {
                    return new Response { Message = "Finalização não Existe", StatusCode = 404 };
                }

                await _repository.UpdateAsync(request);

                return new Response { Message = "Alterado com Sucesso", StatusCode = 200 };
            }
            catch (Exception)
            {

                return new Response { Message = "Erro na Execução", StatusCode = 500 };
            }
           

        }
    }
}
