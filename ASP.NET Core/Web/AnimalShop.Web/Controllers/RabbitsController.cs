namespace AnimalShop.Web.Controllers
{
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Data;
    using AnimalShop.Web.ViewModels.Food;
    using AnimalShop.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Mvc;

    public class RabbitsController : Controller
    {
        private readonly AnimalType animalType = AnimalType.Rabbit;
        private readonly IFoodService foodService;
        private readonly IProductsService productsService;

        public RabbitsController(IFoodService foodService, IProductsService productsService)
        {
            this.foodService = foodService;
            this.productsService = productsService;
        }

        public IActionResult Food()
        {
            var viewModel = new FoodListingViewModel
            {
                Count = this.foodService.GetFoodCount(this.animalType),
                Food = this.foodService.GetFood<FoodViewModel>(this.animalType),
            };

            return this.View(viewModel);
        }

        public IActionResult Toy()
        {
            ProductCategory category = ProductCategory.Toys;

            var viewModel = new ProductListingViewModel
            {
                Count = this.productsService.GetProductsCount(this.animalType, category),
                Products = this.productsService.GetProducts<ProductViewModel>(this.animalType, category),
            };

            return this.View(viewModel);
        }

        public IActionResult House()
        {
            ProductCategory category = ProductCategory.Houses;

            var viewModel = new ProductListingViewModel
            {
                Count = this.productsService.GetProductsCount(this.animalType, category),
                Products = this.productsService.GetProducts<ProductViewModel>(this.animalType, category),
            };

            return this.View(viewModel);
        }

        public IActionResult Bottle()
        {
            ProductCategory category = ProductCategory.Bottles;

            var viewModel = new ProductListingViewModel
            {
                Count = this.productsService.GetProductsCount(this.animalType, category),
                Products = this.productsService.GetProducts<ProductViewModel>(this.animalType, category),
            };

            return this.View(viewModel);
        }
    }
}
