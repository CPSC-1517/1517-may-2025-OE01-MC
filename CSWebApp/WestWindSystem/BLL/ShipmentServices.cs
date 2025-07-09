using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class ShipmentServices
    {
        private readonly WestWindContext _Context;

        internal ShipmentServices( WestWindContext context)
        {
            _Context = context;
        }

        #region Services


        /// <summary>
        /// Return any Shipment records from the given year and month.
        /// </summary>
        /// <param name="year">The year to search.</param>
        /// <param name="month">The month to search.</param>
        /// <returns></returns>
        public List<Shipment> GetShipmentsByYearAndMonth(int year, int month)
        {
            /*
             * Equivalent to:
             * Select * from Shipment
             * Where Year is year
             * and Month is month
             * OrderBy ShippedDate
             */
            //V1
            //IEnumerable<Shipment> records = _Context.Shipments
            //                                .Where(shipment => shipment.ShippedDate.Year == year &&
            //                                                   shipment.ShippedDate.Month == month)
            //                                .OrderBy(shipment => shipment.ShippedDate);

            //V2
            //Any time we want to access a property in our entities via a foreign key, we need to use an Include statement.
            //We could do this manually by querying both tables and combining them, but Include is safer, faster, and more reliabe for basic joins.
            IEnumerable<Shipment> records = _Context.Shipments
                                            .Include(shipment => shipment.ShipViaNavigation) //Functionally the same as Join in SQL
                                            .Where(shipment => shipment.ShippedDate.Year == year &&
                                                               shipment.ShippedDate.Month == month)
                                            .OrderBy(shipment => shipment.ShippedDate);

            return records.ToList();
        }

        #endregion
    }
}
