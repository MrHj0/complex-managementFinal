using ComplexManagment.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Repositories.BlockUsageTypes
{
    internal class EFBlockUsageTypesRepository : BlockUsageTypesRepository
    {
        private EFDataContext _context;
        public EFBlockUsageTypesRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(BlockUsageType blockUsageType)
        {
            _context.BlockUsageTypes.Add(blockUsageType);
        }

        public bool DuplicateBlockUsageType(int blockId, int usageTypeId)
        {
            var isDuplicated = _context.BlockUsageTypes
                .Any(_ => _.BlockId == blockId &&
                _.UsagetypeId == usageTypeId);

            return isDuplicated;
        }
    }
}
