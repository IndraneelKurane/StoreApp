
using StoreApp.Dal.Entities;

namespace StoreApp.Dal.DataSeeder;
public static class LocationRowSeeder
{
    public static List<LocationRowEntity> GetSeedData()
    {
        return new List<LocationRowEntity>
        {
            new LocationRowEntity { Id = 1, Name = "First", InUse = true },
            new LocationRowEntity { Id = 2, Name = "Second", InUse = false },
            new LocationRowEntity { Id = 3, Name = "Third", InUse = false },
            new LocationRowEntity { Id = 4, Name = "Fourth", InUse = false },
            new LocationRowEntity { Id = 5, Name = "Fifth", InUse = false }
        };
    }
}