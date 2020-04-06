namespace AnimalShop.Web.ViewModels.Products
{
    using System.Collections.Generic;

    public class ProductListingViewModel
    {
        public int Count { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
