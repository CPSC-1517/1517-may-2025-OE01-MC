using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class ShipperServices
    {
        private readonly WestWindContext _context;

        internal ShipperServices(WestWindContext context)
        {
            _context = context;
        }

        #region Services

        public List<Shipper> GetAllShippers()
        {
            return _context.Shippers.ToList();
        }

        #endregion
    }
}
