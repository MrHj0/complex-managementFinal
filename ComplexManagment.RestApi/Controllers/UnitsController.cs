using ComplexManagment.DataLayer.Dto.Units;
using ComplexManagment.DataLayer.Entities;
using ComplexManagment.DataLayer.Repositories.Blocks;
using ComplexManagment.DataLayer.Repositories.Units;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Controllers;

[Route("units")]
[ApiController]
public class UnitsController : Controller
{
    private readonly BlockRepository _blockRepo;
    private readonly UnitRepository _unitRepo;
    public UnitsController(UnitRepository unit,
                           BlockRepository block)
    {
        _unitRepo = unit;
        _blockRepo = block;
    }

    [HttpPost]
    public void Add(AddUnitDto dto)
    {
        var isExistBlockId = _blockRepo.IsExistByBlockId
            (dto.BlookId);

        if (!isExistBlockId)
        {
            throw new Exception("block not found");
        }

        var duplicateUnitName = _unitRepo.IsDuplicatedName
            (dto.BlookId,dto.Name);

        if (duplicateUnitName)
        {
            throw new Exception("unit name duplicate");
        }

        var blockUnitCount = _blockRepo.GetTotalUnitCountByBlockId(dto.BlookId);

        var totalUnitInBlock = _unitRepo.GetUnitCountByBlockId(dto.BlookId);

        if (totalUnitInBlock == blockUnitCount)
        {
            throw new Exception("unit count exception");
        }

        var unit = new Unit()
        {
            Name = dto.Name,
            BlookId = dto.BlookId,
            Resident = dto.Resident
        };
        _unitRepo.Add(unit);
    }

    [HttpGet]
    public List<GetAllUnitsDto> GetAll()
    {
        var result = _unitRepo.ShowAllUnits();

        return result;
    }
}