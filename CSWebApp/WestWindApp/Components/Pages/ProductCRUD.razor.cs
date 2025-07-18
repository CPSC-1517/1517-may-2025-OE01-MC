using Microsoft.AspNetCore.Components;
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

        private List<Category> Categories = new();
        private List<Supplier> Suppliers = new();

        private int SelectedCategoryId;


        [Inject]
        protected NavigationManager NavManager { get; set; }

        protected override void OnInitialized()
        {
            //Categories = _CategoryServices.Categories_Get();
            //Suppliers = _SupplierServices.Supplier_GetList();

            base.OnInitialized();
        }

        private void Clear()
        {
            FeedbackMessage = String.Empty;
        }

        private Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }
    }
}
