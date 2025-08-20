using StoreApp.Models.Base;

namespace StoreApp.Models;

public class BillItem : BusinessModel<BillItem>
{
    private int _billId;
    private int _itemId;
    private decimal _quantity;
    private decimal _price;
    private decimal _amount;
    private List<DeliverySchedule> _deliverySchedules = new List<DeliverySchedule>();

    public int BillId
    {
        get => _billId;
        set => SetProperty(ref _billId, value);
    }

    public int ItemId
    {
        get => _itemId;
        set => SetProperty(ref _itemId, value);
    }

    public decimal Quantity
    {
        get => _quantity;
        set => SetProperty(ref _quantity, value);
    }

    public decimal Price
    {
        get => _price;
        set => SetProperty(ref _price, value);
    }

    public decimal Amount
    {
        get => _amount;
        set => SetProperty(ref _amount, value);
    }

    public List<DeliverySchedule> DeliverySchedules
    {
        get => _deliverySchedules;
        set => SetProperty(ref _deliverySchedules, value);
    }

    public static implicit operator BillItem(Dal.Entities.BillItemEntity entity)
    {
        if (entity == null) return null!;
        var billItem = new BillItem
        {
            Id = entity.Id,
            BillId = entity.BillId,
            ItemId = entity.ItemId,
            Quantity = entity.Quantity,
            Price = entity.Price,
            Amount = entity.Amount
        };
        foreach (var deliverySchedule in entity.DeliverySchedules)
        {
            billItem.DeliverySchedules.Add(deliverySchedule);
        }
        return billItem;
    }
    public static implicit operator Dal.Entities.BillItemEntity(BillItem billItem)
    {
        if (billItem == null) return null!;
        var billItemEntity = new Dal.Entities.BillItemEntity
        {
            Id = billItem.Id,
            BillId = billItem.BillId,
            ItemId = billItem.ItemId,
            Quantity = billItem.Quantity,
            Price = billItem.Price,
            Amount = billItem.Amount
        };
        foreach (var deliverySchedule in billItem.DeliverySchedules)
        {
            billItemEntity.DeliverySchedules.Add(deliverySchedule);
        }
        return billItemEntity;
    }

}