using StoreApp.Models.Base;


namespace StoreApp.Models
{
    public class DeliverySchedule : BusinessModel<DeliverySchedule>
    {
        private int _billItemId;
        private DateTime _date = DateTime.Now;
        private decimal _quantity;

        public int BillItemId
        {
            get => _billItemId;
            set => SetProperty(ref _billItemId, value);
        }

        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        public decimal Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }
        public static implicit operator DeliverySchedule(Dal.Entities.DeliveryScheduleEntity entity)
        {
            if (entity == null) return null!;
            return new DeliverySchedule
            {
                Id = entity.Id,
                BillItemId = entity.BillItemId,
                Date = entity.DeliveryDate,
                Quantity = entity.Quantity
            };
        }
        public static implicit operator Dal.Entities.DeliveryScheduleEntity(DeliverySchedule billSchedule)
        {
            if (billSchedule == null) return null!;
            return new Dal.Entities.DeliveryScheduleEntity
            {
                Id = billSchedule.Id,
                BillItemId = billSchedule.BillItemId,
                Quantity = billSchedule.Quantity,
                DeliveryDate = billSchedule.Date
            };
        }
    }
}
