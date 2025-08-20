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
    public class PartyRepository : RepositoryBase<AppDbContext, PartyEntity>
    {
        public PartyRepository(AppDbContext context) : base(context)
        {
        }
    }
}

