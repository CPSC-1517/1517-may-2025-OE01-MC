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
    public class ProductServices
    {
        //this makes a copy of our context usable only by this class.
        //readonly means it can only be set in our constructor.
        private readonly WestWindContext _context;

        internal ProductServices(WestWindContext context)
        {
            _context = context;
        }

        #region Services

        public List<Product> GetProductsByCategoryID(int categoryID)
        {
            return _context.Products.Where(product => product.CategoryID == categoryID)
                                    .OrderBy(product => product.ProductName)
                                    .ToList();
        }

        /// <summary>
        /// Adds a Product to our database after performing further error checking.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The ID of the added product.</returns>
        public int AddProduct(Product product)
        {
            //Validate we actually have data.

            if (product == null)
            {
                throw new ArgumentNullException("Product Information Required!");
            }

            //Validate and business rules/logic
            //BL is that no 2 products can have the same SupplierID, ProductName, and QuantityPerUnit

            bool exists = false;

            exists = _context.Products.Any( x => x.SupplierID == product.SupplierID &&
                                                 x.ProductName == product.ProductName &&
                                                 x.QuantityPerUnit == product.QuantityPerUnit);

            //Throw an error if there's a duplicate
            if(exists)
            {
                throw new ArgumentException("Product already exists!");
            }

            //Could test that values are in acceptable ranges here

            //Assume our data is good at this point

            //Step 1: Staging our Data
            //Our data is only in local memory at this point
            //Any final changes happen here ie. default values, data type changes, date formatting, etc

            _context.Products.Add(product);

            //Step 2: Commit
            //This pushes our data to our DB
            //Entity Annotation Validation will happen before it's passed to the database

            _context.SaveChanges(); //This automatically sets our PKey ID

            return product.ProductID;
        }

        #endregion


    }
}
