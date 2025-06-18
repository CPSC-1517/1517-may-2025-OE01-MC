using OOPsReview;

namespace BlazorWebApp.Components.Pages.InClass
{
    public partial class EmploymentReport
    {
        string FeedbackMsg = String.Empty;
        List<string> ErrorMsgs = new(); //Creats a new version of the variable type on the left. Same as new List<string>();

        List<Employment> Employments = new();

        protected override void OnInitialized()
        {
            ReadAndParseCSV();

            base.OnInitialized();
        }

        /// <summary>
        /// Reads and Parses our CSV file to import into our table
        /// </summary>
        private void ReadAndParseCSV()
        {

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
    }
}
