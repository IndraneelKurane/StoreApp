using StoreApp.Dal.Entities.Base;


namespace StoreApp.Dal.Entities
{
    public class PartyEntity : EntityBase
    {
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;

        // Navigation properties
        public ICollection<BillEntity> Bills { get; set; } = new List<BillEntity>();
    }
}
