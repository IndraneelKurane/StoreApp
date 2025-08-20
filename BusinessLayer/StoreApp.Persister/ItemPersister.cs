using StoreApp.Dal.Entities;
using StoreApp.Dal.Repositories;
using StoreApp.Models;
using StoreApp.Persister.Base;

namespace StoreApp.Persister;
public class ItemPersister : BusinessPersister<Item>
{
    public readonly ItemRepository _itemReporsitory;

    public ItemPersister(ItemRepository itemReporsitory)
    {
        _itemReporsitory = itemReporsitory;
    }

    public override async Task<IEnumerable<Item>> GetAllAsync()
    {
        var itemEntities = await _itemReporsitory.GetAllAsync();
        if (itemEntities == null || !itemEntities.Any())
        {
            return Enumerable.Empty<Item>();
        }
        List<Item> items = itemEntities
            .Select(i => (Item)i)
            .ToList();
        return items;
    }

    public override async Task<Item?> GetByIdAsync(int id)
    {
        var itemEntity = await _itemReporsitory.GetByIdAsync(id);
        if (itemEntity == null)
        {
            return null;
        }
        return itemEntity;
    }

    protected override async Task InsertAsync(Item model)
    {
        ItemEntity itemEntity = (ItemEntity)model;
        await _itemReporsitory.AddAsync(itemEntity);
        model.Id = itemEntity.Id; 
    }

    protected override async Task UpdateAsync(Item model)
    {
        await _itemReporsitory.UpdateAsync(model);
    }
    protected override async Task DeleteAsync(Item model)
    {
        await _itemReporsitory.DeleteAsync(model);
    }

    
}
