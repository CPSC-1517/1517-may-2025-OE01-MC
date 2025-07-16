using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class SupplierServices
    {
        //this makes a copy of our context usable only by this class.
        //readonly means it can only be set in our constructor.
        private readonly WestWindContext _context;

        internal SupplierServices(WestWindContext context)
        {
            _context = context;
        }

        #region Services

        public List<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.OrderBy(supplier => supplier.CompanyName).ToList();
        }

        #endregion
    }
}
