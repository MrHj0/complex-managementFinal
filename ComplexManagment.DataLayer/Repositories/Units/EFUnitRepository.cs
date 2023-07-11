using ComplexManagment.DataLayer.Dto.Units;
using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Units;

public class EFUnitRepository : UnitRepository
{
    private readonly EFDataContext _context;
    private readonly UnitOfWork _unitOfWork;
    public EFUnitRepository(EFDataContext context
                          , UnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public void Add(Unit unit)
    {
        _context.Units.Add(unit);
        _unitOfWork.Save();
    }

    public bool ComplexHasUnitByComplexId(int complexId)
    {
        var hasUnit = _context.Units.Any(_=>_.Block.ComplexId == complexId);

        return hasUnit;
    }

    public int GetUnitCountByBlockId(int blockId)
    {
        var totalUnitsInBlock = _context.Units.
            Count(_=>_.BlookId == blockId);

        return totalUnitsInBlock;
    }

    public bool IsDuplicatedName(int blockId,string name)
    {
        var isDuplicatedName = _context.Units.Any
            (_ => _.Name == name && _.BlookId == blockId);

        if (isDuplicatedName)
        {
            return true;
        }
        return false;
    }

    public bool IsExistsByBlockId(int blockId)
    {
        return _context.Units.Any(_ => _.BlookId == blockId);
    }

    public List<GetAllUnitsDto> ShowAllUnits()
    {
        var result = _context.Units.Select(_ => new GetAllUnitsDto
        {
            Id = _.Id,
            Name = _.Name,
            BlockId = _.BlookId,
            BlockName = _.Block.Name,
            ComplexId = _.Block.ComplexId,
            ComplexName = _.Block.Complex.Name
        }).OrderBy(_=>_.BlockId);
        return result.ToList();
    }
}