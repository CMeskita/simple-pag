using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_pag_Domain.Notificacao
{
    public class Notify
    {

        private readonly List<BrokenRules> listerrors;

        public bool HasNotifications => listerrors.Count > 0;

        public Notify()
        {
            listerrors = new();
        }
        public void Add(string message)
        {
            listerrors.Add(new BrokenRules(message));
        }
        public void AddRange(List<BrokenRules> messages)
        {
            listerrors.AddRange(messages);
        }

        public List<BrokenRules> NotificationList => listerrors;

        public override string ToString()
        {
            List<string> _erros;
            if (listerrors.Count == 0)
            {
                return "";
            }
            else
            {
                _erros = new List<string>();
                _erros = listerrors.Select(e => e.Message).ToList();

                return string.Join(";", _erros);
            }
        }
    }
}
