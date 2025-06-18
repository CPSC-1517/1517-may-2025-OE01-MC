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
            FeedbackMsg = String.Empty;
            ErrorMsgs.Clear();

            //File setup
            string FolderName = @"./Data/"; //Relative path to the root of our application
            string FileName = "Employment.csv";

            string FilePath = FolderName + FileName;

            List<string> Lines = new();

            //File Reading
            try
            {
                if (File.Exists(FilePath))
                {
                    Lines = File.ReadAllLines(FilePath).ToList();

                    Employments = new();

                    foreach (string line in Lines)
                    {
                        Employments.Add(Employment.Parse(line));
                    }
                }
                else
                {
                    throw new Exception($"File: {FilePath} does not exist.");
                }
            }
            catch (Exception ex)
            {
                ErrorMsgs.Add($"System Error: {GetInnerException(ex).Message}");
            }

            FeedbackMsg = $"Date parsed from {FilePath} successfully!";

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
