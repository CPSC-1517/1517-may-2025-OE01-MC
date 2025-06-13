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
                //File IO goes here
                try
                {
                    EmploymentData = new Employment(EmploymentTitle, EmploymentLevel, EmploymentStart, EmploymentYears);

                    //File IO needs a path

                    //Absolute path to my wwwroot folder
                    string appPathName = WebHostEnvironment.ContentRootPath;

                    //Absolute path to my file
                    //The folder needs to exist but the file doesn't
                    //The @ symbol allows me to treat / as a / instead of as a special character
                    string filePath = $@"{appPathName}/Data/Employment.csv";

                    //I could use string line = my content to write. Good if you have lots of data.

                    //Write data to file
                    System.IO.File.AppendAllText(filePath, EmploymentData.ToString() + "\n");
                }
                //From EmploymentData or File path
                catch (ArgumentNullException ex)
                {
                    ErrorMsgs.Add($"Missing Data", GetInnerException(ex).Message);
                }
                //From EmploymentData
                catch (ArgumentException ex)
                {
                    ErrorMsgs.Add($"Bad Data", GetInnerException(ex).Message);
                }
                //Everything else, most will end up being File IO issues
                catch (Exception ex)
                {
                    ErrorMsgs.Add($"System Error", GetInnerException(ex).Message);
                }

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

        /// <summary>
        /// Returns the deepest nested exception.
        /// </summary>
        /// <param name="ex">The exception to check.</param>
        /// <returns></returns>
        private Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            return ex;
        }

        //End of 3.4
    }
}
