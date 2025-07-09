using Microsoft.AspNetCore.Components;
using WestWindSystem.BLL;
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

        [Inject]
        RegionServices regionServices { get; set; }

        protected override void OnInitialized()
        {
            RegionsList = regionServices.GetAllRegions();

            base.OnInitialized();
        }

        void GetByID()
        {
            ClearData();

            if(TargetID <= 0)
            {
                ErrorMsgs.Add($"Your region ID value {TargetID} is invalid.");
            }

            if(ErrorMsgs.Count == 0)
            {
                _Region = regionServices.GetRegionByID(TargetID);

                if( _Region == null )
                {
                    FeedbackMessage = "No region found!";
                }
            }
        }

        void GetBySelect()
        {
            ClearData();

            if (SelectionID == 0)
            {
                ErrorMsgs.Add($"Please select a region.");
            }

            if (ErrorMsgs.Count == 0)
            {
                _Region = regionServices.GetRegionByID(SelectionID);

                if (_Region == null)
                {
                    FeedbackMessage = "No region found!";
                }
            }
        }

        void ClearData()
        {
            FeedbackMessage = String.Empty;
            ErrorMsgs.Clear();

            _Region = null;
        }
    }
}
