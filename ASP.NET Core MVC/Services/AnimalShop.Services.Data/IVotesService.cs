namespace AnimalShop.Services.Data
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task VoteAsync(int foodId, string userId, bool isUpVote);

        int GetFoodVotes(int foodId);
    }
}
