using ComplexManagment.DataLayer.Dto.UsageTypes;
using ComplexManagment.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Repositories.UsageTypes
{
    public class EFUsageTypeRepository : UsageTypeRepository
    {
        private readonly EFDataContext _context;
        private readonly UnitOfWork _unitOfWork;

        public EFUsageTypeRepository(EFDataContext context
                                    , UnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public void Add(UsageType usageType)
        {
            _context.UsageTypes.Add(usageType);
            _unitOfWork.Save();
        }

        public List<GetAllUsageTypesDto> GetAll()
        {
            var result = _context.UsageTypes
                .Select(_ => new GetAllUsageTypesDto
                {
                    Id = _.Id,
                    Title = _.Title
                });

            return result.ToList();
        }
    }
}
