
using ComplexManagment.DataLayer.Dto.Complexs;
using ComplexManagment.DataLayer.Entities;

namespace ComplexManagment.DataLayer.Repositories.Complexs;

public interface ComplexRepository
{
    void UpdateComplexUnitCount(Complex complex);
    void Add(Complex complex);
    bool IsExistsById(int id);
    int GetUnitCountById(int id);
    Complex GetComplexById(int complexId);
    GetComplexWithBlockCountDto GetComplexWithBlockCount(int complexId);
    List<GetAllUsageTypesByComplexIdDto> GetAllUsageTypes(int complexId);
    List<GetAllComplexDto> GetAll(string? searchName);
}