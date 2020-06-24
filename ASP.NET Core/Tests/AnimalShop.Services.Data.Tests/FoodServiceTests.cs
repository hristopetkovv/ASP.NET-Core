namespace AnimalShop.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using AnimalShop.Data.Common.Repositories;
    using AnimalShop.Data.Models;
    using AnimalShop.Data.Models.Enums;
    using Moq;
    using Xunit;

    public class FoodServiceTests
    {
        public List<Food> GetFoodData()
        {
            return new List<Food>
            {
                new Food
                {
                    Name = "test1",
                    Weight = 5.5,
                    Price = 4,
                    ExpirationDate = System.DateTime.UtcNow,
                    Stock = 3,
                    AnimalType = AnimalType.Dog,
                    Description = "test123",
                    Image = "test1234",
                },
                new Food
                {
                    Name = "test2",
                    Weight = 5.5,
                    Price = 4,
                    ExpirationDate = System.DateTime.UtcNow,
                    Stock = 3,
                    AnimalType = AnimalType.Dog,
                    Description = "test123",
                    Image = "test1234",
                },
            };
        }

        [Fact]
        public void GetFoodCountShouldReturnCorrectNumber()
        {
            var cartRepository = new Mock<IDeletableEntityRepository<Cart>>();
            var foodRepository = new Mock<IDeletableEntityRepository<Food>>();
            foodRepository.Setup(
                r => r.All()).Returns(this.GetFoodData().AsQueryable);

            var service = new FoodService(foodRepository.Object, cartRepository.Object);

            Assert.Equal(2, service.GetFoodCount(AnimalType.Dog));
        }
    }
}
