using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartilhar.Enums
{
    public class Enums
    {
        public enum modalidadePagamento
        {
            AVISTA = 1,
            PARCELADO = 2
        }
        public enum PagamentoStatus
        {

            Pendente,//0

            Confirmado,//1

            Cancelado//2
        }

    }
}
