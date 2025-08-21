using StoreApp.Dal.Entities;
using StoreApp.Dal.Repositories;
using StoreApp.Models;
using StoreApp.Persister.Base;
using System.Transactions;

namespace StoreApp.Persister;

public class BillPersister : BusinessPersister<Bill>
{
    private readonly BillRepository _billRepository;
    private readonly BillItemPersister _billItemPersister;
    private readonly DeliverySchedulePersister _deliverySchedulePersister;
    public BillPersister(BillRepository billRepository
        , BillItemPersister billItemPersister
        , DeliverySchedulePersister deliverySchedulePersister)
    {
        _billRepository = billRepository;
        _billItemPersister = billItemPersister;
        _deliverySchedulePersister = deliverySchedulePersister;
    }
    public override async Task<IEnumerable<Bill>> GetAllAsync()
    {
        var billEntities = await _billRepository.GetAllAsync();
        if (billEntities == null || !billEntities.Any())
        {
            return Enumerable.Empty<Bill>();
        }
        List<Bill> bills = billEntities
            .Select(b => (Bill)b)
            .ToList();
        return bills;
    }
    public override async Task<Bill?> GetByIdAsync(int id)
    {
        var billEntity = await _billRepository.GetByIdAsync(id);
        if (billEntity == null)
        {
            return null;
        }
        return billEntity;
    }
    protected override async Task InsertAsync(Bill model)
    {
        using (TransactionScope transaction = GetTransaction())
        {
            try
            {
                var billEntity = (BillEntity)model;
                await _billRepository.AddAsync(billEntity);
                model.Id = billEntity.Id;
                transaction.Complete();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    private static TransactionScope GetTransaction()
    {
        return new TransactionScope(
                    TransactionScopeOption.Required, // Can be Required / RequiresNew / Suppress
                    new TransactionOptions
                    {
                        IsolationLevel = IsolationLevel.ReadCommitted, // You can change this
                        Timeout = TimeSpan.FromSeconds(60)
                    },
                    TransactionScopeAsyncFlowOption.Enabled
                    );
    }

    protected override async Task UpdateAsync(Bill model)
    {
        using (TransactionScope transaction = GetTransaction())
        {
            try
            {
                foreach (var billItem in model.BillItems.Where(bi => bi.IsDeleted))
                {
                    foreach (var deliverySchedule in billItem.DeliverySchedules)
                    {
                        deliverySchedule.MarkAsDeleted();
                        await _deliverySchedulePersister.Save(deliverySchedule);
                    }
                    await _billItemPersister.Save(billItem);
                }
                
                model.BillItems = model.BillItems.Where(bi => !bi.IsDeleted).ToList();
                await _billRepository.UpdateAsync(model);
                transaction.Complete();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    protected override async Task DeleteAsync(Bill model)
    {
        using (TransactionScope transaction = GetTransaction())
        {
            try
            {
                foreach (var billItem in model.BillItems)
                {
                    foreach (var deliverySchedule in billItem.DeliverySchedules)
                    {
                        deliverySchedule.MarkAsDeleted();
                        await _deliverySchedulePersister.Save(deliverySchedule);
                    }
                    billItem.MarkAsDeleted();
                    await _billItemPersister.Save(billItem);
                }
                model.MarkAsDeleted();
                model.BillItems = new List<BillItem>();
                await _billRepository.DeleteAsync(model);
                transaction.Complete();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
