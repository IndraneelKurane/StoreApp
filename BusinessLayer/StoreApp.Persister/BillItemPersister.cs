using StoreApp.Dal.Entities;
using StoreApp.Dal.Repositories;
using StoreApp.Models;
using StoreApp.Persister.Base;

namespace StoreApp.Persister;

public class BillItemPersister : BusinessPersister<BillItem>
{
    public readonly BillItemRepository _billItemReporsitory;

    public BillItemPersister(BillItemRepository billItemReporsitory)
    {
        _billItemReporsitory = billItemReporsitory;
    }

    public override async Task<IEnumerable<BillItem>> GetAllAsync()
    {
        var billLineEntities = await _billItemReporsitory.GetAllAsync();
        if (billLineEntities == null || !billLineEntities.Any())
        {
            return Enumerable.Empty<BillItem>();
        }
        List<BillItem> billLines = billLineEntities
            .Select(i => (BillItem)i)
            .ToList();
        return billLines;
    }

    public override async Task<BillItem?> GetByIdAsync(int id)
    {
        var billItemEntity = await _billItemReporsitory.GetByIdAsync(id);
        if (billItemEntity == null)
        {
            return null;
        }
        return billItemEntity;
    }

    protected override async Task InsertAsync(BillItem model)
    {
        BillItemEntity billLineEntity = (BillItemEntity)model;
        await _billItemReporsitory.AddAsync(billLineEntity);
        model.Id = billLineEntity.Id;
    }

    protected override async Task UpdateAsync(BillItem model)
    {
        //_billItemReporsitory.DetachAllEntities();
        await _billItemReporsitory.UpdateAsync(model);
    }
    protected override async Task DeleteAsync(BillItem model)
    {
        await _billItemReporsitory.DeleteAsync(model);
    }

}