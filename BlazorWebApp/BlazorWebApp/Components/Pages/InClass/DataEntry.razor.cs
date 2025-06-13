using OOPsReview;
using Microsoft.AspNetCore.Components;

namespace BlazorWebApp.Components.Pages.InClass
{
    public partial class DataEntry
    {
        string FeedbackMsg = String.Empty;
        Dictionary<string, string> ErrorMsgs = new();//same as new Dictionary<string, string>();

        string EmploymentTitle = String.Empty;
        double EmploymentYears = 0.0;
        DateTime EmploymentStart = DateTime.Today;
        SupervisoryLevel EmploymentLevel = SupervisoryLevel.Entry;

        Employment EmploymentData;

        //Dependency Injection

        //Gives access to our Web Host (Browser) to determine where our application is running
        [Inject]
        IWebHostEnvironment WebHostEnvironment { get; set; }

        /// <summary>
        /// Checks all of our fields for errors.
        /// </summary>
        private void Submit()
        {
            //Set up a clean slate for communicating with our users
            FeedbackMsg = String.Empty;
            ErrorMsgs.Clear();

            if (String.IsNullOrWhiteSpace(EmploymentTitle))
            {
                ErrorMsgs.Add("Title", "Title can not be empty.");
            }

            if (EmploymentYears < 0)
            {
                ErrorMsgs.Add("Year", "Years can not be negative.");
            }

            if (EmploymentStart >= DateTime.Today.AddDays(1))
            {
                ErrorMsgs.Add("Start", "Start Date can not be in the future.");
            }

            //Do not need to check EmploymentLevel as there is no functional way to pass in bad data

            if (ErrorMsgs.Count == 0)
            {
                FeedbackMsg = $"Success: {EmploymentTitle}, {EmploymentYears}, {EmploymentStart}, {EmploymentLevel}";
            }
        }

        /// <summary>
        /// Resets all of our fields to default values.
        /// </summary>
        private void Clear()
        {
            FeedbackMsg = String.Empty;
            ErrorMsgs.Clear();

            EmploymentTitle = String.Empty;
            EmploymentYears = 0.0;
            EmploymentStart = DateTime.Today;
            EmploymentLevel = SupervisoryLevel.Entry;
        }

        //End of 3.4
    }
}
