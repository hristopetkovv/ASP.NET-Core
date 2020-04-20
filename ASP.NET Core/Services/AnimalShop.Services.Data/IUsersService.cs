namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AnimalShop.Web.ViewModels.Administration.Administration;

    public interface IUsersService
    {
        IEnumerable<T> GetProducts<T>(string userId);

        int GetProductsCount(string userId);

        decimal SumProductsPrice(string userId);

        Task ClearCartAsync(string userId);

        Task RemoveProductAsync(int productId);

        Task CreateFoodAsync(FoodInputViewModel model);

        Task CreateProductAsync(ProductInputViewModel model);
    }
}
