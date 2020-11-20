namespace AnimalShop.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AnimalShop.Data;
    using AnimalShop.Data.Common.Repositories;
    using AnimalShop.Data.Models;
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Data.Repositories;
    using AnimalShop.Web.ViewModels.Food;
    using Microsoft.EntityFrameworkCore;
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

        [Fact]
        public void GetFoodById()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestFoodDatabase")
                .Options;

            var dbContext = new ApplicationDbContext(options);

            dbContext.Food.AddRange(this.GetFoodData());
            dbContext.SaveChanges();

            var foodRepository = new EfDeletableEntityRepository<Food>(dbContext);
            var cartRepository = new EfDeletableEntityRepository<Cart>(dbContext);

            var service = new FoodService(foodRepository, cartRepository);

            var expFood = service.GetById<FoodViewModel>(1);

            Assert.True(expFood.Name == "test1");
        }
    }
}
