using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Blocks;

public class EFBlockRepository : BlockRepository
{
    private readonly EFDataContext _context;
    private readonly UnitOfWork _unitOfWork;

    public EFBlockRepository(EFDataContext context, UnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public bool IsDuplicateNameByComplexId(string name,int complexId)
    {
        return _context.Blooks.Any(_ => 
            _.ComplexId == complexId &&
            _.Name == name);
    }

    public int GetTotalUnitCountByComplexId(int complexId)
    {
        return _context.Blooks
            .Where(_ => _.ComplexId == complexId)
            .Select(_ => _.UnitCount)
            .Sum();
    }

    public int GetTotalUnitCountByComplexIdWithOutThisBlockId(
        int id,
        int complexId)
    {
        return _context.Blooks.Where(_ =>
                _.ComplexId == complexId &&
                _.Id != id)
            .Select(_ => _.UnitCount)
            .Sum();
    }

    public void Add(Blook blook)
    {
        _context.Blooks.Add(blook);
        _unitOfWork.Save();
    }

    public Blook? FindById(int id)
    {
        return _context.Blooks
            .FirstOrDefault(_ => _.Id == id);
    }

    public bool IsDuplicateNameByComplexId(
        int id,
        string name,
        int complexId)
    {
        return _context.Blooks
            .Any(_ => _.Name == name &&
                      _.ComplexId == complexId &&
                      _.Id != id);
    }

    public void Update(Blook blook)
    {
        _context.Blooks.Update(blook);
        _unitOfWork.Save();
    }

    public bool IsExistByBlockId(int id)
    {
        var isExsits = _context.Blooks.Any(_ => _.Id == id);
        if(isExsits)
        {
            return true;
        }
        return false;
    }

    public int GetTotalUnitCountByBlockId(int blockId)
    {
        var totalUnitCount = _context.Blooks
            .Where(_ => _.Id == blockId)
            .Select(_ => _.UnitCount)
            .First();

        return totalUnitCount;
    }

    public List<Blook> GetBlocksByComplexId(int complexId)
    {
        var blocks = _context.Blooks
            .Where(_ => _.ComplexId == complexId)
            .ToList();

        return blocks;
    }

    public void UpdateBlockUnitCounts(List<Blook> blocks)
    {
        _context.UpdateRange(blocks);
        _unitOfWork.Save();
    }
}