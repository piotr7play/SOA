using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LocationsController
    {
        private StoreContext db = new StoreContext();

        public IQueryable<Location> GetLocations()
        {
            return db.Locations;
        }

    }
}