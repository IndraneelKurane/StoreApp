using StoreApp.Dal.Context;
using StoreApp.Dal.Entities;
using StoreApp.Dal.Repositories.Base;

namespace StoreApp.Dal.Repositories;

public class LocationRowRepository : RepositoryBase<AppDbContext, LocationRowEntity>
{
    public LocationRowRepository(AppDbContext context) : base(context)
    {
    }

}
