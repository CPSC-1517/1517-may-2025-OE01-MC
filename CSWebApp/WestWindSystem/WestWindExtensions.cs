using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.BLL;


//Usings for our WestWindSystem
using WestWindSystem.DAL;

namespace WestWindSystem
{
    /// <summary>
    /// Public so it's accessable from WestWindApp.
    /// Static as it's purely datatypes.
    /// All of our services will be assigned and linked here.
    /// </summary>
    public static class WestWindExtensions
    {
        /// <summary>
        /// This method is going to hook up all of our services for use by our WebApp.
        /// </summary>
        /// <param name="services">The collection of services to add our services to.</param>
        /// <param name="options">Database connection string.</param>
        public static void WestWindExtensionServices(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<WestWindContext>(options);

            //All our services go in here
            #region Services

            //We'll replace "Something" with the name of our service.
            services.AddTransient<BuildVersionServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<WestWindContext>();

                return new BuildVersionServices(context);
            });

            #endregion
        }
    }
}
