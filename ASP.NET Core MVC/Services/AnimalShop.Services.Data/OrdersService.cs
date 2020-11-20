namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AnimalShop.Data.Common.Repositories;
    using AnimalShop.Data.Models;
    using AnimalShop.Services.Mapping;

    public class OrdersService : IOrdersService
    {
        private readonly IDeletableEntityRepository<Order> orderRepository;

        public OrdersService(IDeletableEntityRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task CreateOrderAsync(string userId, decimal price)
        {
            var order = new Order
            {
                UserId = userId,
                Status = OrderStatus.Proccessed,
                Price = price,
            };

            await this.orderRepository.AddAsync(order);
            await this.orderRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetOrders<T>(string userId)
        {
            IQueryable<Order> orders = this.orderRepository.All().Where(x => x.UserId == userId);

            return orders.To<T>().ToList();
        }
    }
}
