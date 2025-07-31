using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusSystem.DAL;
using BusSystem.Entities;

namespace BusSystem.BLL
{
    public class RouteServicesComplete
    {
        private readonly BusDataContext _context;

        internal RouteServicesComplete(BusDataContext context)
        {
            _context = context;
        }

        #region Services

        public List<Route> GetRoutes()
        {
            IEnumerable<Route> records = _context.Routes.OrderBy(route => route.RouteNumber);

            return records.ToList();
        }

        #region CRUD Queries

        public int AddRoute(Route route)
        {
            //Check our input isn't null
            if (route == null)
            {
                throw new ArgumentNullException("Route can not be Null!");
            }

            //Check our input doesn't already exist
            Route? existingRoute = _context.Routes.FirstOrDefault(r => r.RouteNumber.Equals(route.RouteNumber));

            if (existingRoute != null)
            {
                throw new ArgumentException($"Route {route.RouteNumber} exists!");
            }

            //This adds our new route to our local data
            _context.Routes.Add(route);

            //This saves our data to the DB
            _context.SaveChanges();

            return route.RouteID;
        }


        #endregion

        #endregion

    }
}
