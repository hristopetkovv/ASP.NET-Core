using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities;
using Ordering.Infrastucture.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastucture.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        protected readonly OrderContext dbContext;

        public OrderRepository(OrderContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await dbContext.Orders
                .Where(o => o.UserName == userName)
                .ToListAsync();

            return orderList;
        }
    }
}
