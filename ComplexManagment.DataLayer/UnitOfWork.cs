using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer
{
    public interface UnitOfWork
    {
        void Save();
        void Begin();
        void Commit();
        void CommitPartial();
        void RollBack();
    }
}
