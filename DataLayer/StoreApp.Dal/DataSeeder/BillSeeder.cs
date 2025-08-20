using StoreApp.Dal.Entities;

namespace StoreApp.Dal.DataSeeder;

internal class BillSeeder
{
    internal static List<BillEntity> GetSeedData()
    {
        return new List<BillEntity>
        {
            new BillEntity { Id = 1, BillNumber = 111, PartyId = PartySeeder.GetSeedData()[2].Id, BillDate = new DateTime(2023, 07, 01), ItemTotal = 60.0m, Discount = 0.0m, NetAmount = 60.0m },
            new BillEntity { Id = 2, BillNumber = 222, PartyId = PartySeeder.GetSeedData()[1].Id, BillDate = new DateTime(2023, 07, 02), ItemTotal = 30.0m, Discount = 10.0m, NetAmount = 130.0m },
            new BillEntity { Id = 3, BillNumber = 333, PartyId = PartySeeder.GetSeedData()[0].Id, BillDate = new DateTime(2023, 07, 03), ItemTotal = 180.0m, Discount = 20.0m, NetAmount = 160.0m }
        };
    }
}