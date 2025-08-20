using StoreApp.Dal.Entities;

namespace StoreApp.Dal.DataSeeder;
public static class UnitSeeder
{
    public static List<UnitEntity> GetSeedData()
    {
        return new List<UnitEntity>
        {
            new UnitEntity { Id = 1, Name = "Kilogram" },
            new UnitEntity { Id = 2, Name = "Gram" },
            new UnitEntity { Id = 3, Name = "Liter" },
            new UnitEntity { Id = 4, Name = "Milliliter" },
            new UnitEntity { Id = 5, Name = "Piece" }
        };
    }
}
