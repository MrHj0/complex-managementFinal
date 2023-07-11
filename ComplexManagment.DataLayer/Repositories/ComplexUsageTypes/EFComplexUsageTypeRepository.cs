using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexManagment.DataLayer.Entities;
using ComplexManagment.DataLayer.Repositories.ComplexUsageTypes;

namespace ComplexManagment.DataLayer.Repositories.ComplexUsageTypes
{
    public class EFComplexUsageTypeRepository : ComplexUsageTypesRepository
    {
        private EFDataContext _context;
        private readonly UnitOfWork _unitOfWork;
        public EFComplexUsageTypeRepository(EFDataContext context,
                                            UnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public void Add(ComplexUsageType complexUsageType)
        {
            _context.ComplexUsageTypes.Add(complexUsageType);
            _unitOfWork.Save();
        }

        public bool DuplicateComplexUsageType(int complexId, int usageTypeId)
        {
            var isDuplicated = _context.ComplexUsageTypes
                .Any(_=>_.UsageTypeId == usageTypeId &&
                _.ComplexId == complexId);

            return isDuplicated;
        }
    }
}
