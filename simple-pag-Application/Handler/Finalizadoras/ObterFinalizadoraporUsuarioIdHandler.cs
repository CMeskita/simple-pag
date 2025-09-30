using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Shared.Interface;

namespace simple_pag_Application.Handler.Finalizadoras
{
    public class ObterFinalizadoraporUsuarioIdHandler : IRequestHandler<CommandObterFinalizadoraPorUsuarioId, List<FinalizadoraResponse>>
    {
        private readonly IFinalizadoraRepositorio _repository;

        public ObterFinalizadoraporUsuarioIdHandler(IFinalizadoraRepositorio repository)
        {
            _repository = repository;
        }

        public Task<List<FinalizadoraResponse>> Handle(CommandObterFinalizadoraPorUsuarioId request, CancellationToken cancellationToken)
        {
            try
            {
                var listadefinalizadoras = _repository.FindFinalizadoraByUsuarioId(request.Id).Result;
                var response = new List<FinalizadoraResponse>
                    (listadefinalizadoras.Select(finalizadora => new FinalizadoraResponse
                    {
                        Id = finalizadora.Id,
                        Valor = finalizadora.Valor,
                        Registro = finalizadora.Registro,

                    }));
            return Task.FromResult(response);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
