using StoreApp.Dal.Entities.Base;


namespace StoreApp.Dal.Entities;

public class BillEntity : EntityBase
{
    public int BillNumber { get; set; }
    public DateTime BillDate { get; set; }
    public int PartyId { get; set; }
    public decimal ItemTotal { get; set; }
    public decimal Discount { get; set; }
    public decimal NetAmount { get; set; }


    // Navigation properties
    public PartyEntity Party { get; set; } = default!;
    public ICollection<BillItemEntity> BillItems { get; set; } = new List<BillItemEntity>();
}
