using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Blocks;

public interface BlockRepository
{
    int GetTotalUnitCountByComplexId(int complexId);
    int GetTotalUnitCountByComplexIdWithOutThisBlockId(int id,int complexId);
    int GetTotalUnitCountByBlockId(int blockId);
    List<Blook> GetBlocksByComplexId(int complexId);
    void Add(Blook blook);
    Blook? FindById(int id);
    bool IsDuplicateNameByComplexId(int id, string name, int complexId);
    void Update(Blook blook);
    bool IsExistByBlockId(int id);
    bool IsDuplicateNameByComplexId(string name,int complexId);
    void UpdateBlockUnitCounts(List<Blook> blocks);
}