using StoreApp.Dal.Context;
using StoreApp.Dal.Entities;
using StoreApp.Dal.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Dal.Repositories
{
    public class DeliveryScheduleRepository : RepositoryBase<AppDbContext, DeliveryScheduleEntity>
{
    public DeliveryScheduleRepository(AppDbContext context) : base(context)
    {
    }
}
}
