using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static simple_pag_Domain.Entity.Finalizadora;

namespace simple_pag_Application.Repsonse
{
    public class FinalizadoraResponse
    {
        public List<FinalizadoraResponseItem> Dados { get; set; }
    }
    public class FinalizadoraResponseItem
    {
        public string Id { get;  set; }
        public decimal Valor { get;  set; }
        public string Registro { get;  set; }
    }
}
