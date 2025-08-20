using StoreApp.Dal.Entities;
using StoreApp.Dal.Repositories;
using StoreApp.Models;
using StoreApp.Persister.Base;


namespace StoreApp.Persister;
public class UnitPersister : BusinessPersister<Unit>
{
    private readonly UnitRepository _unitRepository;

    public UnitPersister(UnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public override async Task<IEnumerable<Unit>> GetAllAsync()
    {
        var unitEntitys = await _unitRepository.GetAllAsync();
        if (unitEntitys == null || !unitEntitys.Any())
        {
            return Enumerable.Empty<Unit>();
        }
        List<Unit> units = unitEntitys
            .Select(u => (Unit)u)
            .ToList();
        return units;
    }

    public override async Task<Unit?> GetByIdAsync(int id)
    {
        var unitEntitys = await _unitRepository.GetByIdAsync(id);
        if (unitEntitys == null)
        {
            return null;
        }
        return unitEntitys;
    }
    protected override async Task InsertAsync(Unit model)
    {
        UnitEntity unitEntity = model;
        await _unitRepository.AddAsync(unitEntity);
        model.Id = unitEntity.Id;
    }

    protected override async Task UpdateAsync(Unit model)
    {
        await _unitRepository.UpdateAsync(model);
    }

    protected override async Task DeleteAsync(Unit model)
    {
        await _unitRepository.DeleteAsync(model);
    }
}
