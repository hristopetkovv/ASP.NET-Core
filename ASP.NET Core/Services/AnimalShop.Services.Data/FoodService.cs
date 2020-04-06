namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AnimalShop.Data.Common.Repositories;
    using AnimalShop.Data.Models;
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Mapping;
    using AnimalShop.Web.ViewModels.ProductsInCart;

    public class FoodService : IFoodService
    {
        private readonly IDeletableEntityRepository<Food> foodRepository;
        private readonly IDeletableEntityRepository<FoodOrder> foodOrderRepository;
        private readonly IDeletableEntityRepository<Cart> cartRepository;

        public FoodService(IDeletableEntityRepository<Food> foodRepository, IDeletableEntityRepository<FoodOrder> foodOrderRepository, IDeletableEntityRepository<Cart> cartRepository)
        {
            this.foodRepository = foodRepository;
            this.foodOrderRepository = foodOrderRepository;
            this.cartRepository = cartRepository;
        }

        public async Task AddToCartAsync(int foodId, string userId)
        {
            var food = this.foodRepository
                .All()
                .FirstOrDefault(x => x.Id == foodId);

            food.Stock--;

            var foodToCart = this.GetById<FoodCartInputModel>(foodId);

            var cartProduct = new Cart
            {
                UserId = userId,
                Name = foodToCart.Name,
                Image = foodToCart.Image,
                Price = foodToCart.Price,
                Weight = foodToCart.Weight,
            };

            await this.cartRepository.AddAsync(cartProduct);
            await this.cartRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var food = this.foodRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return food;
        }

        public IEnumerable<T> GetFood<T>(AnimalType animalType)
        {
            IQueryable<Food> food = this.foodRepository.All().Where(x => x.AnimalType == animalType);

            return food.To<T>().ToList();
        }

        public int GetFoodCount(AnimalType animalType)
        {
            var count = this.foodRepository.All().Where(x => x.AnimalType == animalType).Count();

            return count;
        }
    }
}
