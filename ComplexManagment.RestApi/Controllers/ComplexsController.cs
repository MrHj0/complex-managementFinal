using ComplexManagment.DataLayer.Dto.Complexs;
using ComplexManagment.DataLayer.Entities;
using ComplexManagment.DataLayer.Repositories.Blocks;
using ComplexManagment.DataLayer.Repositories.Complexs;
using ComplexManagment.DataLayer.Repositories.Units;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Controllers
{
    [Route("complexs")]
    [ApiController]
    public class ComplexsController : ControllerBase
    {

        private readonly ComplexRepository _complexRepository;
        private readonly UnitRepository _unitRepository;
        private readonly BlockRepository _blockRepository;
        public ComplexsController(ComplexRepository complexRepository,
                                  UnitRepository unitRepository,
                                  BlockRepository blockRepository)
        {
            _complexRepository = complexRepository;
            _unitRepository = unitRepository;
            _blockRepository = blockRepository;
        }

        [HttpPost]
        public void Add([FromBody] AddComplexDto dto)
        {
            var complex = new Complex()
            {
                Name = dto.Name,
                UnitCount = dto.UnitCount,
            };

            _complexRepository.Add(complex);
        }

        [HttpGet]
        public List<GetAllComplexDto> GetAll([FromQuery] string? name)
        {
            return _complexRepository.GetAll(name);
        }

        [HttpPatch]
        [Route("{id}/edit-unitcounts")]
        public void EditUnitCount([FromRoute] int id, [FromBody] int unitCount)
        {
            if (unitCount > 1000 || unitCount < 4)
            {
                throw new Exception("unit count must be between 1000_4");
            }

            var complexIsExsits = _complexRepository
                .IsExistsById(id);
            if (!complexIsExsits)
            {
                throw new Exception("Complex does not exsists");
            }

            var hasUnit = _unitRepository
                .ComplexHasUnitByComplexId(id);
            if (hasUnit)
            {
                throw new Exception("the complex has registered units");
            }

            var complex = _complexRepository.GetComplexById(id);
            List<Blook> blocks = new List<Blook>();

            if (complex.UnitCount > unitCount)
            {
                blocks = _blockRepository.GetBlocksByComplexId(id);
                foreach (var item in blocks)
                {
                    item.UnitCount = 0;
                }

                complex.UnitCount = unitCount;
            }

            else
            {
                complex.UnitCount = unitCount;
            }
            _complexRepository.UpdateComplexUnitCount(complex);
            _blockRepository.UpdateBlockUnitCounts(blocks);

        }

        [HttpGet]
        [Route("{id}/usage-types")]
        public List<GetAllUsageTypesByComplexIdDto> GetAllUsageTypes([FromRoute] int id)
        {
            var result = _complexRepository.GetAllUsageTypes(id);

            return result;
        }

        [HttpGet]
        [Route("{id}/with-block-count")]
        public GetComplexWithBlockCountDto GetAllWithBlocks([FromRoute]int id)
        {
            var complexIsExists = _complexRepository
                .IsExistsById(id);
            if (!complexIsExists)
            {
                throw new Exception("Complex not found");
            }

            var complex = _complexRepository
                .GetComplexWithBlockCount(id);

            return complex;
        }

    }
}