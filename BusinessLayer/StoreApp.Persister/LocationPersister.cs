
using StoreApp.Dal.Entities;
using StoreApp.Dal.Repositories;
using StoreApp.Models;
using StoreApp.Persister.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Persister;
public class LocationPersister : BusinessPersister<Location>
{
    private readonly LocationRepository _locationRepository;

    public LocationPersister(LocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public override async Task<IEnumerable<Location>> GetAllAsync()
    {
        var locationEntities = await _locationRepository.GetAllAsync();
        if (locationEntities == null || !locationEntities.Any())
        {
            return Enumerable.Empty<Location>();
        }
        List<Location> locations = locationEntities
            .Select(l => (Location)l)
            .ToList();
        return locations;
    }

    public override async Task<Location?> GetByIdAsync(int id)
    {
        var locationEntity = await _locationRepository.GetByIdAsync(id);
        if (locationEntity == null)
        {
            return null;
        }
        return locationEntity;
    }
    protected override async Task InsertAsync(Location model)
    {
        LocationEntity locationEntity = (LocationEntity)model;
        await _locationRepository.AddAsync(locationEntity);
        model.Id = locationEntity.Id;
    }

    protected override async Task UpdateAsync(Location model)
    {
        await _locationRepository.UpdateAsync(model);
    }

    protected override async Task DeleteAsync(Location model)
    {
        await _locationRepository.DeleteAsync(model);
    }
}
