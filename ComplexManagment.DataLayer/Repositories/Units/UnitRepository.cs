using ComplexManagment.DataLayer.Dto.Units;
using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Units;

public interface UnitRepository
{
    int GetUnitCountByBlockId(int blockId);
    bool IsExistsByBlockId(int blockId);
    void Add(Unit unit);
    bool IsDuplicatedName(int blockId,string name);
    bool ComplexHasUnitByComplexId(int complexId);
    List<GetAllUnitsDto> ShowAllUnits();
}