namespace AnimalShop.Web.ViewModels.Products
{
    using AnimalShop.Data.Models;
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Mapping;

    public class ProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public AnimalType AnimalType { get; set; }

        public ProductCategory Category { get; set; }

        public int Stock { get; set; }

        public string Image { get; set; }
    }
}
