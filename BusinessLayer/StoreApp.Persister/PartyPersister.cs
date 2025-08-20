using StoreApp.Dal.Repositories;
using StoreApp.Models;
using StoreApp.Persister.Base;


namespace StoreApp.Persister;

public class PartyPersister : BusinessPersister<Party>
{
    private readonly PartyRepository _partyRepository;

    public PartyPersister(PartyRepository partyRepository)
    {
        _partyRepository = partyRepository;
    }
    public override async Task<IEnumerable<Party>> GetAllAsync()
    {
        var partyEntities = await _partyRepository.GetAllAsync();
        if (partyEntities == null || !partyEntities.Any())
        {
            return Enumerable.Empty<Party>();
        }
        List<Party> parties = partyEntities
            .Select(p => (Party)p)
            .ToList();
        return parties;
    }
    public override async Task<Party?> GetByIdAsync(int id)
    {
        var partyEntity = await _partyRepository.GetByIdAsync(id);
        if (partyEntity == null)
        {
            return null;
        }
        return partyEntity;
    }
    protected override async Task InsertAsync(Party model)
    {
        var partyEntity = (Dal.Entities.PartyEntity)model;
        await _partyRepository.AddAsync(partyEntity);
        model.Id = partyEntity.Id;
    }
    protected override async Task UpdateAsync(Party model)
    {
        await _partyRepository.UpdateAsync(model);
    }
    protected override async Task DeleteAsync(Party model)
    {
        await _partyRepository.DeleteAsync(model);
    }
}