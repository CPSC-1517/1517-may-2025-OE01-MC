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

        public SupervisoryLevel Level { get { return _Level; } set { _Level = value; } }
        public DateTime StartDate { get; set; }
        public string Title { get { return _Title; } set { _Title = value; } }
        public double Years { get { return _Years; } set { _Years = value; } }

        #endregion

        //Almost always public or internal; generally match the class
        #region Constructors

        /// <summary>
        /// Our default constructor.
        /// </summary>
        public Employment()
        {

        }

        #endregion

        //Depends on usage, though generally public
        #region Methods

        #endregion
    }
}
