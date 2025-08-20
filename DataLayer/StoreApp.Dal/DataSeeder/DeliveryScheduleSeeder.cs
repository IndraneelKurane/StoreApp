using StoreApp.Dal.Entities;

namespace StoreApp.Dal.DataSeeder;

internal class DeliveryScheduleSeeder
{
    internal static List<DeliveryScheduleEntity> GetSeedData()
    {
        return new List<DeliveryScheduleEntity>
        {
            new DeliveryScheduleEntity { Id = 1, BillItemId = BillItemSeeder.GetSeedData()[0].Id, DeliveryDate = new DateTime(2023, 07, 1), Quantity = 4 },
            new DeliveryScheduleEntity { Id = 2, BillItemId = BillItemSeeder.GetSeedData()[1].Id, DeliveryDate = new DateTime(2023, 07, 15), Quantity = 3 },
            new DeliveryScheduleEntity { Id = 3, BillItemId = BillItemSeeder.GetSeedData()[1].Id, DeliveryDate = new DateTime(2023, 07, 20), Quantity = 2 },
            new DeliveryScheduleEntity { Id = 4, BillItemId = BillItemSeeder.GetSeedData()[2].Id, DeliveryDate = new DateTime(2023, 07, 3), Quantity = 2 },
            new DeliveryScheduleEntity { Id = 5, BillItemId = BillItemSeeder.GetSeedData()[3].Id, DeliveryDate = new DateTime(2023, 07, 4), Quantity = 2 },
            new DeliveryScheduleEntity { Id = 6, BillItemId = BillItemSeeder.GetSeedData()[4].Id, DeliveryDate = new DateTime(2023, 07, 5), Quantity = 2 }
        };
    }
}