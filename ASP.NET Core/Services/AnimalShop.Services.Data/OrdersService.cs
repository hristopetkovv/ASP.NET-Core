namespace AnimalShop.Services.Data
{
    using System.Threading.Tasks;

    using AnimalShop.Data.Common.Repositories;
    using AnimalShop.Data.Models;

    public class OrdersService : IOrdersService
    {
        private readonly IDeletableEntityRepository<Order> orderRepository;

        public OrdersService(IDeletableEntityRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<int> CreateOrderAsync(string userId)
        {
            var order = new Order
            {
                UserId = userId,
                Status = OrderStatus.Proccessed,
            };

            await this.orderRepository.AddAsync(order);
            await this.orderRepository.SaveChangesAsync();

            return order.Id;
        }
    }
}
