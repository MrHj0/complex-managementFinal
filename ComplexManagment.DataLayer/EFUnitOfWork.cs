using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer
{
    public class EFUnitOfWork : UnitOfWork
    {
        private readonly EFDataContext _context;
        public EFUnitOfWork(EFDataContext context)
        {
            _context = context;
        }

        public void Begin()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void CommitPartial()
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
