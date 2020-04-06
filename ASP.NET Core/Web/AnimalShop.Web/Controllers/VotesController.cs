namespace AnimalShop.Web.Controllers
{
    using System.Threading.Tasks;

    using AnimalShop.Data.Models;
    using AnimalShop.Services.Data;
    using AnimalShop.Web.ViewModels.Votes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[Controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVotesService votesService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(IVotesService votesService, UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.votesService.VoteAsync(input.FoodId, userId, input.IsUpVote);

            var votes = this.votesService.GetFoodVotes(input.FoodId);

            return new VoteResponseModel { VotesCount = votes };
        }
    }
}
