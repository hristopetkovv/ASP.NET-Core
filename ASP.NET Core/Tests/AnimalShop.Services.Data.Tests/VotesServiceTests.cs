namespace AnimalShop.Services.Data.Tests
{
    using System.Threading.Tasks;

    using AnimalShop.Data;
    using AnimalShop.Data.Models;
    using AnimalShop.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class VotesServiceTests
    {
        [Fact]
        public async Task TwoDownVotesShouldReturnCountOne()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("ExampleDb");

            var repository = new EfRepository<Vote>(new ApplicationDbContext(options.Options));
            var service = new VotesService(repository);

            await service.VoteAsync(1, "1", false);
            await service.VoteAsync(1, "1", false);
            var votes = service.GetFoodVotes(1);

            Assert.Equal(-1, votes);
        }
    }
}
