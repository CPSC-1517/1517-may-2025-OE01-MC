using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Link to our WestWindSystem
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    //Services need to be public so they can be used in our front end app.
    public class RegionServices
    {
        //readonly means we can only set this variable in our constructor.
        private readonly WestWindContext _Context;

        /// <summary>
        /// Constructor. Internal so it can only be accessed by our WestWindSystem.
        /// </summary>
        /// <param name="context"></param>
        internal RegionServices(WestWindContext context)
        {
            _Context = context;
        }

        //This is where the service actually does stuff with our Database
        #region Services

        /// <summary>
        /// Return all records from the Region table.
        /// 
        /// This is a dangerous service. It will cause problems if your table has a large number of records (>1000).
        /// </summary>
        /// <returns>All records or an empty list.</returns>
        public List<Region> GetAllRegions()
        {
            IEnumerable<Region> records = _Context.Regions;

            return records.ToList();
        }

        public Region? GetRegionByID(int id)
        {
            Region? region = null;

            /*Equivalent to:
                Select * From Regions
                Where RegionID is id
            */
            region = _Context.Regions.FirstOrDefault(
                x => x.RegionID == id
            );
            /*
                ForEach(var region in Regions)
                {
                    if(region.RegionID == id)
                        return region;
                }
            */

            return region;
        }
        #endregion
    }
}
