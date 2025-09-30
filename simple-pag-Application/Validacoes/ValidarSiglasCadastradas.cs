using simple_pag_Domain.Entity;
using simple_pag_Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static simple_pag_Domain.Entity.Finalizadora;

namespace simple_pag_Application.Funcao
{
    public static class ValidarSiglasCadastradas
    {
        public static async Task<Pagamento> VerificacaoSiglas(Pagamento dados, IList<string> siglas)
        {
            try
            {
                var sigla = dados.Sigla;
              
                int contador = 1;
            
                for (int i = 0; i < siglas.Count; i++)
                {
                 
                    if (siglas.Contains(sigla))
                    {

                        sigla = StringExtensions.GerarSiglarefresh(dados.Nome, contador);
                        contador = contador + 1;
                        sigla = sigla;
                 
                    }
                }
                

                dados.SetSigla(sigla);


                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar sigla: {ex.Message}");
            }
        }
    }
}
