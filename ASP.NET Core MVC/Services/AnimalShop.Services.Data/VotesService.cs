namespace AnimalShop.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using AnimalShop.Data.Common.Repositories;
    using AnimalShop.Data.Models;
    using AnimalShop.Data.Models.Enums;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public async Task VoteAsync(int foodId, string userId, bool isUpVote)
        {
            var vote = this.votesRepository
                .All()
                .FirstOrDefault(x => x.FoodId == foodId && x.UserId == userId);

            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    FoodId = foodId,
                    UserId = userId,
                    Type = isUpVote ? VoteType.UpVote : VoteType.DownVote,
                };

                await this.votesRepository.AddAsync(vote);
            }

            await this.votesRepository.SaveChangesAsync();
        }

        public int GetFoodVotes(int foodId)
        {
            var votes = this.votesRepository
                 .All()
                 .Where(x => x.FoodId == foodId)
                 .Sum(x => (int)x.Type);

            return votes;
        }
    }
}
