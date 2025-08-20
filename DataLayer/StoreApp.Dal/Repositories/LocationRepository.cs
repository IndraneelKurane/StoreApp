using StoreApp.Dal.Context;
using StoreApp.Dal.Entities;
using StoreApp.Dal.Repositories.Base;

namespace StoreApp.Dal.Repositories;

public class LocationRepository : RepositoryBase<AppDbContext, LocationEntity>
{
    public LocationRepository(AppDbContext context) : base(context)
    {
    }

}
