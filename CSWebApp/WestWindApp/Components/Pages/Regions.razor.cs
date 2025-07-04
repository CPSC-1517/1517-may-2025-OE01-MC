using WestWindSystem.Entities;

namespace WestWindApp.Components.Pages
{
    public partial class Regions
    {
        string FeedbackMessage = String.Empty;
        List<string> ErrorMsgs = new();

        int TargetID = 0;
        int SelectionID = 0;

        Region _Region = null;

        List<Region> RegionsList = new();

        void GetByID()
        {

        }

        void GetBySelect()
        {

        }

        void ClearData()
        {

        }
    }
}
