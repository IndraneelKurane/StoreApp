
using StoreApp.Dal.Entities;

namespace StoreApp.Dal.DataSeeder;
public static class LocationSeeder
{
    public static List<LocationEntity> GetSeedData()
    {
        return new List<LocationEntity>
        {
            new LocationEntity { Id = 1, Description = "First Floor", LocationRowId = LocationRowSeeder.GetSeedData()[3].Id, RackNo = 1 ,StartedUsingOn = DateTime.Now },
            new LocationEntity { Id = 2, Description = "Second Floor", LocationRowId = LocationRowSeeder.GetSeedData()[2].Id, RackNo = 1 ,StartedUsingOn = DateTime.Now },
            new LocationEntity { Id = 3, Description = "Third Floor", LocationRowId = LocationRowSeeder.GetSeedData()[1].Id, RackNo = 1 ,StartedUsingOn = DateTime.Now },
            new LocationEntity { Id = 4, Description = "Fourth Floor", LocationRowId = LocationRowSeeder.GetSeedData()[4].Id, RackNo = 1 ,StartedUsingOn = DateTime.Now },
            new LocationEntity { Id = 5, Description = "Fifth Floor", LocationRowId = LocationRowSeeder.GetSeedData()[0].Id, RackNo = 1 ,StartedUsingOn = DateTime.Now }
        };
    }
}
