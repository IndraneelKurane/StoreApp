
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
public class LocationRowPersister : BusinessPersister<LocationRow>
{
    private readonly LocationRowRepository _locationRowRepository;

    public LocationRowPersister(LocationRowRepository locationRowRepository)
    {
        _locationRowRepository = locationRowRepository;
    }

    public override async Task<IEnumerable<LocationRow>> GetAllAsync()
    {
        var locationRowEntities = await _locationRowRepository.GetAllAsync();
        if (locationRowEntities == null || !locationRowEntities.Any())
        {
            return Enumerable.Empty<LocationRow>();
        }
        List<LocationRow> locationRows = locationRowEntities
            .Select(lr => (LocationRow)lr)
            .ToList();
        return locationRows;
    }

    public override async Task<LocationRow?> GetByIdAsync(int id)
    {
        var locationRowEntity = await _locationRowRepository.GetByIdAsync(id);
        if (locationRowEntity == null)
        {
            return null;
        }
        return locationRowEntity;
    }
    protected override async Task InsertAsync(LocationRow model)
    {
        LocationRowEntity locationRowEntity = (LocationRowEntity)model;
        await _locationRowRepository.AddAsync(locationRowEntity);
        model.Id = locationRowEntity.Id;
    }

    protected override async Task UpdateAsync(LocationRow model)
    {
        await _locationRowRepository.UpdateAsync(model);
    }

    protected override async Task DeleteAsync(LocationRow model)
    {
        await _locationRowRepository.DeleteAsync(model);
    }
}
