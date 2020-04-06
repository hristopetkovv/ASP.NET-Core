namespace AnimalShop.Web.Controllers
{
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Data;
    using AnimalShop.Web.ViewModels.Food;
    using AnimalShop.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Mvc;

    public class FishesController : Controller
    {
        private readonly AnimalType animalType = AnimalType.Fish;
        private readonly IFoodService foodService;
        private readonly IProductsService productsService;

        public FishesController(IFoodService foodService, IProductsService productsService)
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

        public IActionResult Aquarium()
        {
            ProductCategory category = ProductCategory.Aquariums;

            var viewModel = new ProductListingViewModel
            {
                Count = this.productsService.GetProductsCount(this.animalType, category),
                Products = this.productsService.GetProducts<ProductViewModel>(this.animalType, category),
            };

            return this.View(viewModel);
        }

        public IActionResult Accessories()
        {
            ProductCategory category = ProductCategory.Accessories;

            var viewModel = new ProductListingViewModel
            {
                Count = this.productsService.GetProductsCount(this.animalType, category),
                Products = this.productsService.GetProducts<ProductViewModel>(this.animalType, category),
            };

            return this.View(viewModel);
        }
    }
}
