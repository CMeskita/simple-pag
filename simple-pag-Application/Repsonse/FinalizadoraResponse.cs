using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int QtdParcelas { get;  set; }
        public string Modalidade { get;  set; }
        public string Vencimento { get;  set; }
        public string FormaPagamento { get;  set; }
    }
}
