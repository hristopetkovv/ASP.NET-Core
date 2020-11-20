namespace AnimalShop.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AnimalShop.Data.Common.Repositories;
    using AnimalShop.Data.Models;
    using AnimalShop.Services.Data;
    using AnimalShop.Web.ViewModels.Food;
    using AnimalShop.Web.ViewModels.Products;
    using AnimalShop.Web.ViewModels.ProductsInCart;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class DetailsController : Controller
    {
        private readonly IFoodService foodService;
        private readonly IProductsService productsService;
        private readonly UserManager<ApplicationUser> userManager;

        public DetailsController(IFoodService foodService, IProductsService productsService, UserManager<ApplicationUser> userManager)
        {
            this.foodService = foodService;
            this.productsService = productsService;
            this.userManager = userManager;
        }

        public IActionResult Food(int id)
        {
            var viewModel = this.foodService.GetById<FoodViewModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        public IActionResult Product(int id)
        {
            var viewModel = this.productsService.GetById<ProductViewModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> AddFoodToCart(int foodId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.foodService.AddToCartAsync(foodId, user.Id);

            return this.RedirectToAction("SuccessfulMessage");
        }

        [Authorize]
        public async Task<IActionResult> AddProductToCart(int productId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.productsService.AddToCartAsync(productId, user.Id);

            return this.RedirectToAction("SuccessfulMessage");
        }

        public IActionResult SuccessfulMessage()
        {
            return this.View();
        }
    }
}
