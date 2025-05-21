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
            set
            {
                //Guard Statement - Causes a function to exit early when there is bad data.
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{value} is invalid. First Name is Required; can not be null, empty, or whitespace.");
                }

                //Always trim your strings.
                _FirstName = value.Trim(); 
            }
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

        public Person(string firstName, string lastName,  ResidentAddress address, List<Employment> positions)
        {

            FirstName = firstName;
            LastName = lastName;
            Address = address;

            if (positions != null)
            {
                EmploymentPositions = positions;
            }
            else
            {
                EmploymentPositions = new List<Employment>();
            }
        }

        #endregion
    }
}
