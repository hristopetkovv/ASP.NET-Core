namespace AnimalShop.Web.ViewModels.ProductsInCart
{
    using System.Collections.Generic;

    public class ProductCartListingViewModel
    {
        public decimal SumOfProducts { get; set; }

        public int Count { get; set; }

        public IEnumerable<ProductCartViewModel> Products { get; set; }
    }
}
