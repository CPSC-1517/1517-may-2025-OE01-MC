using BusSystem.BLL;
using BusSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BusSystem
{
    public static class BusExtensions
    {
        public static void BusExtensionsServices(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            //Adds our Database context to our service list with the connection string.
            services.AddDbContext<BusDataContext>(options);

            //Add every service we will be using with .AddTransient<T>
            #region Transient Services

            services.AddTransient<RouteServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<BusDataContext>();

                return new RouteServices(context);
            });

            //Only here for demonstration of complete version
            services.AddTransient<RouteServicesComplete>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<BusDataContext>();

                return new RouteServicesComplete(context);
            });
            #endregion
        }
    }
}
