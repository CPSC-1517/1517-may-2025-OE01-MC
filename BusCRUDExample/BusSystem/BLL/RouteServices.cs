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
    public class RouteServices
    {
        private readonly BusDataContext _context;

        internal RouteServices(BusDataContext context)
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
            //TODO:
            // Check parameters are valid
            // Check RouteNumber does not already exist
            // Add Route if the data is good


            //Replace the return with your new RouteID.
            return 0;
        }


        #endregion

        #endregion

    }
}
