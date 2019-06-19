using StudioCraft.Web.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace StudioCraft.Web.Repository
{
    public class CustomRepository
    {
        public static StudioCraftEntities GetDbContext()
        {
            StudioCraftEntities context = new StudioCraftEntities();
            context.Configuration.ProxyCreationEnabled = false;
            ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
            objectContext.CommandTimeout = int.MaxValue;
            return context;
        }
    }
}