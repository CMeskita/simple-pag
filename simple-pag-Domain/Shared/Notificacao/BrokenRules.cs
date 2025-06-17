using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_pag_Domain.Shared.Notificacao
{
    public class BrokenRules
    {
        public BrokenRules(string message)
        {
            Message = message;
        }
        public string Message { get; protected set; }
    }
}
