using StoreApp.Dal.Entities;

namespace StoreApp.Dal.DataSeeder;

internal class BillItemSeeder
{
    internal static List<BillItemEntity> GetSeedData()
    {
        return new List<BillItemEntity> 
        {
            new BillItemEntity { Id = 1, BillId = BillSeeder.GetSeedData()[1].Id, ItemId = ItemSeeder.GetSeedData()[0].Id, Quantity = 4, Price = 10.0m, Amount = 40m },
            new BillItemEntity { Id = 2, BillId = BillSeeder.GetSeedData()[1].Id, ItemId = ItemSeeder.GetSeedData()[1].Id, Quantity = 5, Price = 20.0m, Amount = 100m },
            new BillItemEntity { Id = 3, BillId = BillSeeder.GetSeedData()[0].Id, ItemId = ItemSeeder.GetSeedData()[2].Id, Quantity = 2, Price = 30.0m, Amount = 60m },
            new BillItemEntity { Id = 4, BillId = BillSeeder.GetSeedData()[2].Id, ItemId = ItemSeeder.GetSeedData()[3].Id, Quantity = 2, Price = 40.0m, Amount = 80m },
            new BillItemEntity { Id = 5, BillId = BillSeeder.GetSeedData()[2].Id, ItemId = ItemSeeder.GetSeedData()[4].Id, Quantity = 2, Price = 50.0m, Amount = 100m },
        };
    }
}