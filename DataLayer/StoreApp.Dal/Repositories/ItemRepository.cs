using StoreApp.Dal.Context;
using StoreApp.Dal.Entities;
using StoreApp.Dal.Repositories.Base;

namespace StoreApp.Dal.Repositories;
public class ItemRepository : RepositoryBase<AppDbContext, ItemEntity>
{
    public ItemRepository(AppDbContext context) : base(context)
    {
    }
}
