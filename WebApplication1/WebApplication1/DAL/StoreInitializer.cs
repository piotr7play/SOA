using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseAlways<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            List<Location> defaultLocations = new List<Location>();
            defaultLocations.Add(new Location() { ID = 1, Where = "Location1"});
            foreach (Location b in defaultLocations)
                context.Locations.Add(b);
            context.SaveChanges();
        }
    }
}