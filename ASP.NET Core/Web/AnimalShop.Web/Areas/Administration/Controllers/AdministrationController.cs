namespace AnimalShop.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AnimalShop.Common;
    using AnimalShop.Services.Data;
    using AnimalShop.Web.Controllers;
    using AnimalShop.Web.ViewModels.Administration.Administration;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
        private readonly IUsersService usersService;

        public AdministrationController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult CreateFood()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFood(FoodInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.usersService.CreateFoodAsync(input);

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult CreateProduct()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.usersService.CreateProductAsync(input);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
