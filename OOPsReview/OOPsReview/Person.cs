using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        private string _FirstName;
        private string _LastName;

        #region Attributes

        public ResidentAddress Address { get; set; }
        public List<Employment> EmploymentPositions { get; set; }

        public string FirstName
        { 
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; } 
        }

        #endregion

        #region Constructors

        public Person()
        {
            FirstName = "Unknown";
            LastName = "Unknown";

            EmploymentPositions = new List<Employment>();
        }



        #endregion
    }
}
