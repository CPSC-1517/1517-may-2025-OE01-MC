namespace OOPsReview
{
    public class Employment
    {
        //Generally private unless stated otherwise.
        #region Attributes

        private SupervisoryLevel _Level;
        private string _Title;
        private double _Years; //Years of Employment.

        #endregion

        //If we have a property that's name matches an Attribute, that is a Fully-Implemented Property.

        //If we have a property that does not have a matching attribute, that is an auto-implemented property.

        //Generally public unless stated otherwise.
        #region Properties

        public SupervisoryLevel Level
        {
            get { return _Level; }

            private set
            {
                if(!Enum.IsDefined(typeof(SupervisoryLevel), value))
                {
                    throw new ArgumentException($"Supervisory Level {value} is invalid.");
                }

                _Level = value;
            }
        }

        public DateTime StartDate { get; set; }

        public string Title
        {
            get { return _Title; }
            set 
            {
                //IsNullOrWhiteSpace checks for any purely whitespace strings.
                //Is better than IsNullOrEmpty
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is Required.");
                }
                _Title = value;
            }
        }
        public double Years
        {
            get { return _Years; }
            set 
            {
                if(value < 0)
                {
                    throw new ArgumentException($"Year value {value} is invalid. Must be non-negative.");
                }
                _Years = value;
            }
        }

        #endregion

        //Almost always public or internal; generally match the class
        #region Constructors

        /// <summary>
        /// Our default constructor.
        /// </summary>
        public Employment()
        {
            //Can not be null or whitespace
            Title = "Unknown";

            //Years defaults to 0, so no need to implement it here.
            Level = SupervisoryLevel.Entry;

            StartDate = DateTime.Now;
        }

        /// <summary>
        /// Our greedy contructor.
        /// 
        /// StartDate can not be in the future.
        /// Years will calculate if not provided.
        /// </summary>
        /// <param name="title"> Position Title </param>
        /// <param name="level"> SupervisoryLevel of position </param>
        /// <param name="startDate"> Position start date </param>
        /// <param name="years">Years of employment; default 0.0 </param>
        /// 
        /* years has a default value, so I can leave it out when calling the contructor if needed. This gives me 2 constructors from 1 definition.
         * 
         * Parameters with default values must be declared after those without defaults. I can have as many default parameters as I wish.
         * */
        public Employment(string title, SupervisoryLevel level, DateTime startDate, double years = 0.0)
        {
            Title= title;
            Level = level;

            //StartDate can not be in the future
            //This will check if startDate is tomorrow or later.
            if(startDate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startDate} is in the future.");
            }
            
            //Else not necessary as the throw will exit my constructor.
            StartDate = startDate;

            if (years > 0.0)
            {
                Years = years;
            }
            else
            {
                TimeSpan span = DateTime.Now - startDate;
                Years = Math.Round((span.Days / 365.25), 1); //365.25 accounts for leap years
            }
        }
        #endregion

        //Depends on usage, though generally public
        #region Methods

        public void SetEmploymentResponsibilityLevel(SupervisoryLevel level)
        {
            Level = level;
        }

        /// <summary>
        /// Override ToString. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

        }

        #endregion
    }
}
