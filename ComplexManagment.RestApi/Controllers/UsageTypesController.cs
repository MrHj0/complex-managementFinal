using Microsoft.AspNetCore.Mvc;
using ComplexManagment.DataLayer.Repositories.UsageTypes;
using ComplexManagment.DataLayer.Dto.UsageTypes;

namespace ComplexManagment.Controllers
{
    [Route("usage-types")]
    [ApiController]
    public class UsageTypesController : Controller
    {
        private readonly UsageTypeRepository _usageTypeRepo;

        public UsageTypesController(UsageTypeRepository usageTypeRepo)
        {
            _usageTypeRepo = usageTypeRepo;
        }

        [HttpPost]
        public void Add([FromBody]AddUsageTypeDto dto)
        {
            _usageTypeRepo.Add(new DataLayer.Entities.UsageType
            {
                Title = dto.Title,
            });
        }

        [HttpGet]
        public List<GetAllUsageTypesDto> GetAll()
        {
            var result = _usageTypeRepo.GetAll();

            return result;
        }
    }
}
