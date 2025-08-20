using StoreApp.Dal.Context;
using StoreApp.Dal.Entities;
using StoreApp.Dal.Repositories.Base;

namespace StoreApp.Dal.Repositories;
public class UnitRepository : RepositoryBase<AppDbContext, UnitEntity>
{
    public UnitRepository(AppDbContext context) : base(context)
    {
    }
}
