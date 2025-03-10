using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_pag_Domain.Interface
{
    public interface IUnityOffWork
    {
        void BeginTransaction();
        void CommitTransaction();
        void Rollback();

    }
}
