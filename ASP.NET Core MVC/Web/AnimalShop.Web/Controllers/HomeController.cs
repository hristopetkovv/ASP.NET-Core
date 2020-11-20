namespace AnimalShop.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using AnimalShop.Data.Models;
    using AnimalShop.Services.Data;
    using AnimalShop.Web.ViewModels;
    using AnimalShop.Web.ViewModels.Orders;
    using AnimalShop.Web.ViewModels.ProductsInCart;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IUsersService usersService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IOrdersService ordersService;

        public HomeController(IUsersService usersService, UserManager<ApplicationUser> userManager, IOrdersService ordersService)
        {
            this.usersService = usersService;
            this.userManager = userManager;
            this.ordersService = ordersService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<ActionResult> MyCart()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var productsSum = this.usersService.SumProductsPrice(user.Id);

            var viewModel = new ProductCartListingViewModel
            {
                SumOfProducts = productsSum,
                Count = this.usersService.GetProductsCount(user.Id),
                Products = this.usersService.GetProducts<ProductCartViewModel>(user.Id),
            };

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> RemoveProduct(int productId)
        {
            await this.usersService.RemoveProductAsync(productId);

            return this.RedirectToAction("MyCart");
        }

        [Authorize]
        public async Task<IActionResult> CompletedOrder()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var productsSum = this.usersService.SumProductsPrice(user.Id);

            await this.ordersService.CreateOrderAsync(user.Id, productsSum);

            await this.usersService.ClearCartAsync(user.Id);

            var viewModel = new OrderListingViewModel()
            {
                Orders = this.ordersService.GetOrders<OrderViewModel>(user.Id),
            };

            return this.View(viewModel);
        }
    }
}
