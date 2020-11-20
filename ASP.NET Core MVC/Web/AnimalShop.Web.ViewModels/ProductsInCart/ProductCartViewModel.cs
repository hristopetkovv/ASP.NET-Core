namespace AnimalShop.Web.ViewModels.ProductsInCart
{
    using AnimalShop.Data.Models;
    using AnimalShop.Services.Mapping;

    public class ProductCartViewModel : IMapFrom<Cart>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public double? Weight { get; set; }
    }
}
