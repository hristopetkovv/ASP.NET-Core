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

    public class ProductsService : IProductsService
    {
        private readonly IDeletableEntityRepository<Product> productRepository;
        private readonly IDeletableEntityRepository<Cart> cartRepository;

        public ProductsService(IDeletableEntityRepository<Product> productRepository, IDeletableEntityRepository<Cart> cartRepository)
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
        }

        public int GetProductsCount(AnimalType animalType, ProductCategory product)
        {
            var count = this.productRepository
                .All()
                .Where(x => x.AnimalType == animalType && x.Category == product)
                .Count();

            return count;
        }

        public IEnumerable<T> GetProducts<T>(AnimalType animalType, ProductCategory product)
        {
            IQueryable<Product> toys = this.productRepository
                .All()
                .Where(x => x.AnimalType == animalType && x.Category == product);

            return toys.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var product = this.productRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return product;
        }

        public async Task AddToCartAsync(int productId, string userId)
        {
            var product = this.productRepository
                .All()
                .FirstOrDefault(x => x.Id == productId);

            product.Stock--;

            var productToCart = this.GetById<ProductCartInputModel>(productId);

            var cartProduct = new Cart
            {
                UserId = userId,
                Name = productToCart.Name,
                Image = productToCart.Image,
                Price = productToCart.Price,
            };

            await this.cartRepository.AddAsync(cartProduct);
            await this.cartRepository.SaveChangesAsync();
        }
    }
}
