using ComplexManagment.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Repositories.BlockUsageTypes
{
    public interface BlockUsageTypesRepository
    {
        void Add(BlockUsageType blockUsageType);
        bool DuplicateBlockUsageType(int blockId, int UsageTypeId);
    }
}
