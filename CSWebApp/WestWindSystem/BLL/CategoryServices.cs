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
    public class CategoryServices
    {
        //this makes a copy of our context usable only by this class.
        //readonly means it can only be set in our constructor.
        private readonly WestWindContext _context;

        internal CategoryServices(WestWindContext context)
        {
            _context = context;
        }

        #region Services

        public List<Category> GetAllCategories()
        {
            //get the data from the Regions sql table
            IEnumerable<Category> records = _context.Categories;

            return records.OrderBy(record => record.CategoryName).ToList();
        }

        #endregion
    }
}

