using StoreApp.Dal.Entities;

namespace StoreApp.Dal.DataSeeder;
public static class ItemSeeder
{
    public static List<ItemEntity> GetSeedData()
    {
        return new List<ItemEntity>
        {
            new ItemEntity { Id = 1, Name = "Apple", Price = 0.5m, UnitId  = UnitSeeder.GetSeedData()[2].Id, LocationId = LocationSeeder.GetSeedData()[4].Id },
            new ItemEntity { Id = 2, Name = "Banana", Price = 0.3m, UnitId = UnitSeeder.GetSeedData()[4].Id, LocationId = LocationSeeder.GetSeedData()[2].Id },
            new ItemEntity { Id = 3, Name = "Orange Juice", Price = 1.5m, UnitId = UnitSeeder.GetSeedData()[3].Id, LocationId = LocationSeeder.GetSeedData()[1].Id },
            new ItemEntity { Id = 4, Name = "Milk", Price = 0.8m, UnitId   = UnitSeeder.GetSeedData()[0].Id, LocationId = LocationSeeder.GetSeedData()[0].Id },
            new ItemEntity { Id = 5, Name = "Bread", Price = 1.0m, UnitId  = UnitSeeder.GetSeedData()[1].Id, LocationId = LocationSeeder.GetSeedData()[3].Id }
        };
    }
}
