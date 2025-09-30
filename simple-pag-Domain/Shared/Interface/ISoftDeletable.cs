using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_pag_Domain.Shared.Interface
{
    public interface ISoftDeletable
    {
        
            bool IsDeleted { get; }
            DateTime? DeletedAt { get; }

            void Delete();
            void Restore();
        
    }
}
