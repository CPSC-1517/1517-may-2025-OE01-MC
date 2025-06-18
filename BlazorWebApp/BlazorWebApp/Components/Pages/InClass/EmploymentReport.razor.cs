using OOPsReview;

namespace BlazorWebApp.Components.Pages.InClass
{
    public partial class EmploymentReport
    {
        string FeedbackMsg = String.Empty;
        List<string> ErrorMsgs = new(); //Creats a new version of the variable type on the left. Same as new List<string>();

        List<Employment> Employments = new();
    }
}
