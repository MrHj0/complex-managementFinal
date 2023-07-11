using ComplexManagment.DataLayer;
using ComplexManagment.DataLayer.Dto.ComplexUsageTypes;
using ComplexManagment.DataLayer.Repositories.ComplexUsageTypes;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Controllers
{
    [Route("complex-usage-types")]
    [ApiController]
    public class ComplexUsageTypesController : Controller
    {
        private readonly ComplexUsageTypesRepository _complexUsageTypesRepository;
        private readonly UnitOfWork _unitOfWork;                                                                                        
        public ComplexUsageTypesController
            (ComplexUsageTypesRepository complexUsageTypesRepository,
             UnitOfWork unitOfWork)
        {
            _complexUsageTypesRepository = complexUsageTypesRepository;
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public void Add([FromBody]AddComplexUsageTypeDto dto)
        {
            var isDuplicated = _complexUsageTypesRepository
                .DuplicateComplexUsageType
                (dto.ComplexId,dto.UsageTypeId);

            if(isDuplicated)
            {
                throw new Exception("Duplicated Complex UsageType");
            }

            _complexUsageTypesRepository.Add(new DataLayer.Entities.ComplexUsageType
            {
                UsageTypeId = dto.UsageTypeId,
                ComplexId = dto.ComplexId
            });
            _unitOfWork.Save();
        }
    }
}
