using ComplexManagment.DataLayer.Dto.Complexs;
using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Complexs;

public class EFComplexRepository : ComplexRepository
{
    private readonly EFDataContext _context;
    private readonly UnitOfWork _unitOfWork;

    public EFComplexRepository(EFDataContext context
                             , UnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public void Add(Complex complex)
    {
        _context.Complexs.Add(complex);
        _unitOfWork.Save();
    }

    public List<GetAllComplexDto> GetAll(string? searchName)
    {
        var result = _context.Complexs
            .Select(_ => new GetAllComplexDto
            {
                Id = _.Id,
                Name = _.Name,
                RegisteredUnits = _.Blooks.SelectMany(_ => _.Units).Count(),
                RemainingUnits =
                _.UnitCount - _.Blooks
                .SelectMany(_ => _.Units)
                .Count()
            });

        if (!string.IsNullOrWhiteSpace(searchName))
        {
            result = result.Where(_ => _.Name.Contains(searchName));
        }

        return result.ToList();
    }

    public bool IsExistsById(int id)
    {
        return _context.Complexs.Any(_ => _.Id == id);
    }

    public int GetUnitCountById(int id)
    {
        return _context.Complexs
            .Where(_ => _.Id == id)
            .Select(_ => _.UnitCount)
            .FirstOrDefault();
    }

    public List<GetAllUsageTypesByComplexIdDto> GetAllUsageTypes(int complexId)
    {
        var result =
            (from usage in _context.UsageTypes
             join compUsagesTypes in _context.ComplexUsageTypes
             on usage.Id equals compUsagesTypes.UsageTypeId
             where compUsagesTypes.ComplexId == complexId
             select new GetAllUsageTypesByComplexIdDto
             {
                 UsageTypeId = usage.Id,
                 UsageTypeName = usage.Title
             });

        return result.ToList();
    }

    public Complex GetComplexById(int complexId)
    {
        var compelx = _context.Complexs
            .FirstOrDefault(_ => _.Id == complexId);

        return compelx;
    }

    public void UpdateComplexUnitCount(Complex complex)
    {
        _context.Update(complex);
        _unitOfWork.Save();
    }

    public GetComplexWithBlockCountDto GetComplexWithBlockCount(int complexId)
    {
        var complex = _context.Complexs
            .Where(_ => _.Id == complexId)
            .Select(com => new GetComplexWithBlockCountDto
            {
                Id = com.Id,
                Name = com.Name,
                RegisteredUnits = com.Blooks.SelectMany(_ => _.Units).Count(),
                RemainingUnits = com.UnitCount
                                    - com.Blooks.SelectMany(_ => _.Units).Count(),
                BlocksCount = com.Blooks.Count()
            }).FirstOrDefault();

        return complex;
    }
}