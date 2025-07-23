using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestWindApp.Components.Pages
{
    public partial class ProductCRUD
    {
        [Parameter]
        public int? ProductID { get; set; }

        private string? FeedbackMessage = String.Empty;

        [Inject]
        private ProductServices _ProductServices { get; set; }

        [Inject]
        private CategoryServices _CategoryServices { get; set; }

        [Inject]
        private SupplierServices _SupplierServices { get; set; }

        private Product CurrentProduct = new();

        //EditContext tracks changes to a linked object and updates accordingly
        private EditContext _EditContext;
        //Stores any error messages when validing our context. Replaces ErrorMsgs in previous examples.
        private ValidationMessageStore _ValidationMessageStore;

        private List<Category> Categories = new();
        private List<Supplier> Suppliers = new();

        private int SelectedCategoryId;


        [Inject]
        protected NavigationManager NavManager { get; set; }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        protected override void OnInitialized()
        {
            Categories = _CategoryServices.GetAllCategories();
            Suppliers = _SupplierServices.GetAllSuppliers();

            _EditContext = new EditContext(CurrentProduct);
            //Shorthand new operator with parameter.
            _ValidationMessageStore = new(_EditContext);

            base.OnInitialized();
        }

        private void Clear()
        {
            FeedbackMessage = String.Empty;
            _ValidationMessageStore.Clear();
        }

        private async Task OnClear()
        {
            if(await JSRuntime.InvokeAsync<bool>("confirm", "Are you sure you want to clear the page?"))
            {
                Clear();

                CurrentProduct = new();

                //Update our EditContext as they are specific to the instance assigned to them
                //Critical to do this or your form WILL stop working
                _EditContext = new EditContext(CurrentProduct);

                //Also important to update our ValidationMessageStore
                _ValidationMessageStore = new ValidationMessageStore(_EditContext);
            }
        }

        private async Task GoToSearch()
        {

        }

        #region CRUD Methods

        private void OnCreate()
        {
            try
            {
                if (_EditContext.Validate())
                {
                    FeedbackMessage = "Data is Valid!";
                }
            }

            catch (Exception ex)
            {
                FeedbackMessage = $"System Error: {GetInnerException(ex).Message}";
            }
        }

        private void OnUpdate()
        {

        }

        private void OnDiscontinue()
        {

        }

        #endregion

        private Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }
    }
}
