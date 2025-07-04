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

        public BuildVersion? GetBuildVersion() //BuildVersionGet -or- BuildVersion_Get are also common naming schemes.
        {
            //IEnumerable is one of the base classes (interfaces) that list derives from
            //We use it here to prevet a database query. Once we turn this into a list it will query our database.
            IEnumerable<BuildVersion> records = _Context.BuildVersions;

            return records.FirstOrDefault();
        }

        #endregion
    }
}
