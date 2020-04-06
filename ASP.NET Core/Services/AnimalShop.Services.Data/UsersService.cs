namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AnimalShop.Data.Common.Repositories;
    using AnimalShop.Data.Models;
    using AnimalShop.Services.Mapping;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<Cart> cartRepository;
        private readonly IDeletableEntityRepository<Food> foodRepository;
        private readonly IDeletableEntityRepository<Product> productRepository;

        public UsersService(IDeletableEntityRepository<Cart> cartRepository, IDeletableEntityRepository<Food> foodRepository, IDeletableEntityRepository<Product> productRepository)
        {
            this.cartRepository = cartRepository;
            this.foodRepository = foodRepository;
            this.productRepository = productRepository;
        }

        public IEnumerable<T> GetProducts<T>(string userId)
        {
            IQueryable<Cart> products = this.cartRepository
                .All()
                .Where(x => x.UserId == userId);

            return products.To<T>().ToList();
        }

        public int GetProductsCount(string userId)
        {
            var count = this.cartRepository
               .All()
               .Where(x => x.UserId == userId)
               .Count();

            return count;
        }

        public async Task RemoveProduct(int productId)
        {
            var productToRemove = this.cartRepository
                .All()
                .FirstOrDefault(x => x.Id == productId);

            if (productToRemove.Weight != null)
            {
                var food = this.foodRepository.All().FirstOrDefault(x => x.Name == productToRemove.Name);
                food.Stock++;
            }
            else
            {
                var product = this.productRepository.All().FirstOrDefault(x => x.Name == productToRemove.Name);
                product.Stock++;
            }

            this.cartRepository.HardDelete(productToRemove);
            await this.foodRepository.SaveChangesAsync();
            await this.productRepository.SaveChangesAsync();
            await this.cartRepository.SaveChangesAsync();
        }

        public decimal SumProductsPrice(string userId)
        {
            var price = this.cartRepository
                .All()
                .Where(x => x.UserId == userId)
                .Sum(x => x.Price);

            return price;
        }
    }
}
