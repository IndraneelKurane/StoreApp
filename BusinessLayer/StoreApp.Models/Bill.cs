using StoreApp.Models.Base;
using System.ComponentModel;

namespace StoreApp.Models
{
    public class Bill : BusinessModel<Bill>
    {
        private int _billNumber;
        private DateTime _billDate = DateTime.Now;
        private int _partyId;
        private decimal _itemTotal;
        private decimal _discount;
        private decimal _netAmount;
        private List<BillItem> _billItems = new List<BillItem>();

        [DisplayName("Bill No.")]
        public int BillNumber
        {
            get => _billNumber;
            set => SetProperty(ref _billNumber, value);
        }

        public DateTime BillDate
        {
            get => _billDate;
            set => SetProperty(ref _billDate, value);
        }

        public int PartyId
        {
            get => _partyId;
            set => SetProperty(ref _partyId, value);
        }

        public decimal ItemTotal
        {
            get => _itemTotal;
            set => SetProperty(ref _itemTotal, value);
        }

        public decimal Discount
        {
            get => _discount;
            set => SetProperty(ref _discount, value);
        }

        public decimal NetAmount
        {
            get => _netAmount;
            set => SetProperty(ref _netAmount, value);
        }

        // Navigation properties
        public List<BillItem> BillItems
        {
            get => _billItems;
            set => SetProperty(ref _billItems, value);
        }

        public static implicit operator Bill(Dal.Entities.BillEntity entity)
        {
            if (entity == null) return null!;
            var bill = new Bill
            {
                Id = entity.Id,
                BillNumber = entity.BillNumber,
                BillDate = entity.BillDate,
                PartyId = entity.PartyId,
                ItemTotal = entity.ItemTotal,
                Discount = entity.Discount,
                NetAmount = entity.NetAmount
            };
            foreach (var billItemEntity in entity.BillItems)
            {
                bill.BillItems.Add(billItemEntity);
            }
            return bill;
        }
        public static implicit operator Dal.Entities.BillEntity(Bill bill)
        {
            if (bill == null) return null!;
            var billEntity = new Dal.Entities.BillEntity
            {
                Id = bill.Id,
                BillNumber = bill.BillNumber,
                BillDate = bill.BillDate,
                PartyId = bill.PartyId,
                ItemTotal = bill.ItemTotal,
                Discount = bill.Discount,
                NetAmount = bill.NetAmount
            };
            foreach (var billItem in bill.BillItems)
            {
                billEntity.BillItems.Add(billItem);
            }
            return billEntity;
        }
    }
}
