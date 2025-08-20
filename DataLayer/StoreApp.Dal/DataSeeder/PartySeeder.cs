using StoreApp.Dal.Entities;

namespace StoreApp.Dal.DataSeeder;
public static class PartySeeder
{
    public static List<PartyEntity> GetSeedData()
    {
        return new List<PartyEntity>
        {
            new PartyEntity { Id = 1, Name = "John Doe", Address = "123 Elm St", PhoneNumber = "123-456-7890", Email = "john@gamil.com" },
            new PartyEntity { Id = 2, Name = "Jane Smith", Address = "456 Oak St", PhoneNumber = "987-654-3210", Email = "jane@gmail.com" },
            new PartyEntity { Id = 3, Name = "Acme Corp", Address = "789 Pine St", PhoneNumber = "555-123-4567", Email = "acme@hmail.com" },
            new PartyEntity { Id = 4, Name = "Global Industries", Address = "321 Maple St", PhoneNumber = "444-987-6543", Email = "global@gmail.com" },
        };
    }
}
