using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Interface;
using simple_pag_Domain.Entity;

namespace simple_pag_Application.Handler.Finalizadoras
{
    public class CreateFinalizadorHandler : IRequestHandler<CommandFinalizadora, Response>
    {
        private readonly IFinalizadoraRepositorio _repository;

        public CreateFinalizadorHandler(IFinalizadoraRepositorio repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(CommandFinalizadora request, CancellationToken cancellationToken)
        {
            try
            {
                Finalizadora dados = request;

                await _repository.AddFinalizadora(dados);

                return new Response { Message = "Finalizadora Cadastrada com Sucesso", StatusCode = 201 };
            }
          
            catch (Exception ex)
            {
                return new Response { Message = ex.Message, StatusCode = 500};
            }
        }
    }
}
