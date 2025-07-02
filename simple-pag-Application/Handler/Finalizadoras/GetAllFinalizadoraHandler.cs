using MediatR;
using simple_pag_Application.Command;
using simple_pag_Application.Repsonse;
using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Interface;

namespace simple_pag_Application.Handler.Finalizadoras
{
    internal class GetAllFinalizadoraHandler : IRequestHandler<CommandGetAllFinalizadora, List<FinalizadoraResponse>>
    {
        private readonly IFinalizadoraRepositorio _finalizadoraRepositorio;

        public GetAllFinalizadoraHandler(IFinalizadoraRepositorio finalizadoraRepositorio)
        {
            _finalizadoraRepositorio = finalizadoraRepositorio;
        }

        public async Task<List<FinalizadoraResponse>> Handle(CommandGetAllFinalizadora request, CancellationToken cancellationToken)
        {
            try
            {
                var finalizadora = _finalizadoraRepositorio.GetAllFinalizadoras().ToList();
                var response = new List<FinalizadoraResponse>
                   (finalizadora.Select(f=> new FinalizadoraResponse 
                   {
                       Id =f.Id,
                       Valor = f.Valor,                      
                       Registro = f.Registro
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
