using StoreApp.Dal.Repositories;
using StoreApp.Models;
using StoreApp.Persister.Base;

namespace StoreApp.Persister
{
    public class DeliverySchedulePersister : BusinessPersister<DeliverySchedule>
    {
        private readonly DeliveryScheduleRepository _deliveryScheduleRepository;
        public DeliverySchedulePersister(DeliveryScheduleRepository deliveryScheduleRepository)
        {
            _deliveryScheduleRepository = deliveryScheduleRepository;
        }
        public override async Task<IEnumerable<DeliverySchedule>> GetAllAsync()
        {
            var billScheduleEntities = await _deliveryScheduleRepository.GetAllAsync();
            if (billScheduleEntities == null || !billScheduleEntities.Any())
            {
                return Enumerable.Empty<DeliverySchedule>();
            }
            List<DeliverySchedule> billSchedules = billScheduleEntities
                .Select(b => (DeliverySchedule)b)
                .ToList();
            return billSchedules;
        }
        public override async Task<DeliverySchedule?> GetByIdAsync(int id)
        {
            var deliveryScheduleEntity = await _deliveryScheduleRepository.GetByIdAsync(id);
            if (deliveryScheduleEntity == null)
            {
                return null;
            }
            return deliveryScheduleEntity;
        }
        protected override async Task InsertAsync(DeliverySchedule model)
        {
            var deliveryScheduleEntity = (Dal.Entities.DeliveryScheduleEntity)model;
            await _deliveryScheduleRepository.AddAsync(deliveryScheduleEntity);
            model.Id = deliveryScheduleEntity.Id;
        }
        protected override async Task UpdateAsync(DeliverySchedule model)
        {
            //_deliveryScheduleRepository.DetachAllEntities();
            await _deliveryScheduleRepository.UpdateAsync(model);
        }
        protected override async Task DeleteAsync(DeliverySchedule model)
        {
            await _deliveryScheduleRepository.DeleteAsync(model);
        }
    }
}
