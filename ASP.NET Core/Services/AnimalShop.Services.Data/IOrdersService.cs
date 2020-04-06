namespace AnimalShop.Services.Data
{
    using System.Threading.Tasks;

    public interface IOrdersService
    {
        Task<int> CreateOrderAsync(string userId);
    }
}
