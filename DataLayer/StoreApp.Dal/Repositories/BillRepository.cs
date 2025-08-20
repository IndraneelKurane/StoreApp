using StoreApp.Dal.Context;
using StoreApp.Dal.Entities;
using StoreApp.Dal.Repositories.Base;


namespace StoreApp.Dal.Repositories
{
    public class BillRepository : RepositoryBase<AppDbContext, BillEntity>
    {
        public BillRepository(AppDbContext context) : base(context)
        {
        }
    }
}
