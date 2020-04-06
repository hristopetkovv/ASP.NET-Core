namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrdersService
    {
        Task CreateOrderAsync(string userId, decimal price);

        IEnumerable<T> GetOrders<T>(string userId);
    }
}
