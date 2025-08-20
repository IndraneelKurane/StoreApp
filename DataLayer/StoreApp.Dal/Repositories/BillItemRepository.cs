using StoreApp.Dal.Context;
using StoreApp.Dal.Entities;
using StoreApp.Dal.Repositories.Base;


namespace StoreApp.Dal.Repositories
{
    public class BillItemRepository : RepositoryBase<AppDbContext, BillItemEntity>
    {
        public BillItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}
