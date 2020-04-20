namespace AnimalShop.Web.Controllers
{
    using System;

    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Data;
    using AnimalShop.Web.ViewModels.Food;
    using AnimalShop.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Mvc;

    public class FishesController : Controller
    {
        private const int ItemsPerPage = 9;

        private readonly AnimalType animalType = AnimalType.Fish;
        private readonly IFoodService foodService;
        private readonly IProductsService productsService;

        public FishesController(IFoodService foodService, IProductsService productsService)
        {
            this.foodService = foodService;
            this.productsService = productsService;
        }

        public IActionResult Food(int page = 1)
        {
            var count = this.foodService.GetFoodCount(this.animalType);

            var viewModel = new FoodListingViewModel
            {
                Count = count,
                Food = this.foodService.GetFood<FoodViewModel>(this.animalType, ItemsPerPage, (page - 1) * ItemsPerPage),
            };

            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        public IActionResult Aquarium(int page = 1)
        {
            ProductCategory category = ProductCategory.Aquariums;

            var count = this.productsService.GetProductsCount(this.animalType, category);

            var viewModel = new ProductListingViewModel
            {
                Count = count,
                Products = this.productsService.GetProducts<ProductViewModel>(this.animalType, category, ItemsPerPage, (page - 1) * ItemsPerPage),
            };

            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        public IActionResult Accessories(int page = 1)
        {
            ProductCategory category = ProductCategory.Accessories;

            var count = this.productsService.GetProductsCount(this.animalType, category);

            var viewModel = new ProductListingViewModel
            {
                Count = count,
                Products = this.productsService.GetProducts<ProductViewModel>(this.animalType, category, ItemsPerPage, (page - 1) * ItemsPerPage),
            };

            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }
    }
}
