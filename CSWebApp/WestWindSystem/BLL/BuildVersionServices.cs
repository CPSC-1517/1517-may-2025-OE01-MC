using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;

namespace WestWindSystem.BLL
{
    //Services need to be public so they can be used in our front end app.
    public class BuildVersionServices
    {
        //readonly means we can only set this variable in our constructor.
        private readonly WestWindContext _Context;

        /// <summary>
        /// Constructor. Internal so it can only be accessed by our WestWindSystem.
        /// </summary>
        /// <param name="context"></param>
        internal BuildVersionServices(WestWindContext context)
        {
            _Context = context;
        }

        //This is where the service actually does stuff with our Database
        #region Services



        #endregion
    }
}
