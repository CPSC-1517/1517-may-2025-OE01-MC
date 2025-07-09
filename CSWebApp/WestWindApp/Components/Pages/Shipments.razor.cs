using Microsoft.AspNetCore.Components;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestWindApp.Components.Pages
{
    public partial class Shipments
    {
        string FeedbackMsg = String.Empty;

        List<string> ErrorMsgs = new List<string>();

        int Year = 1950;
        int Month = 1;

        List<Shipment> ShipmentList = null;

        [Inject]
        ShipmentServices _ShipmentServices { get; set; }

        void GetShipments()
        {
            ClearData();

            if(Year < 1950 || Year > DateTime.Today.Year)
            {
                ErrorMsgs.Add($"Year value {Year} is invalid. Must be between 1950 and Current year.");
            }

            if(Month < 1 || Month > 12)
            {
                ErrorMsgs.Add($"Month value {Month} is invalid. Must be between 1 and 12.");
            }

            if(Year == DateTime.Today.Year && Month > DateTime.Today.Month)
            {
                ErrorMsgs.Add($"Month value {Month} is invalid. Must not be in the future.");
            }

            if(ErrorMsgs.Count == 0)
            {
                try
                {
                    ShipmentList = _ShipmentServices.GetShipmentsByYearAndMonth(Year, Month);
                }
                catch (Exception ex)
                {
                    ErrorMsgs.Add($"System Error: {ex.Message}");
                }
            }
        }

        private void ClearData()
        {
            FeedbackMsg = String.Empty;
            ErrorMsgs.Clear();
            ShipmentList = null;
        }
    }
}
