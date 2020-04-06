namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        IEnumerable<T> GetProducts<T>(string userId);

        int GetProductsCount(string userId);

        decimal SumProductsPrice(string userId);

        Task RemoveProduct(int productId);
    }
}
