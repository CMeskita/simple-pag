using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Shared.Interface;

namespace simple_pag_Application.Handler.Finalizadoras
{
    internal class ObterTodasFinalizadoraHandler : IRequestHandler<CommandObterTodasFinalizadora, List<FinalizadoraResponse>>
    {
        private readonly IFinalizadoraRepositorio _finalizadoraRepositorio;

        public ObterTodasFinalizadoraHandler(IFinalizadoraRepositorio finalizadoraRepositorio)
        {
            _finalizadoraRepositorio = finalizadoraRepositorio;
        }

        public async Task<List<FinalizadoraResponse>> Handle(CommandObterTodasFinalizadora request, CancellationToken cancellationToken)
        {
            try
            {
                var listadefinalizdaora = _finalizadoraRepositorio.ObterTodasFinalizadoras().ToList();
                var response = new List<FinalizadoraResponse>
                   (listadefinalizdaora.Select(finalizaora=> new FinalizadoraResponse 
                   {
                       Id =finalizaora.Id,
                       Valor = finalizaora.Valor,                      
                       Registro = finalizaora.Registro
                   }));
                return response;

            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
