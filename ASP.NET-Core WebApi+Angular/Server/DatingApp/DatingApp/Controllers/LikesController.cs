using DatingApp.DTOs;
using DatingApp.Entities;
using DatingApp.Extensions;
using DatingApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
	[Authorize]
	public class LikesController : BaseApiController
	{
		private readonly IUserRepository userRepository;
		private readonly ILikesRepository likesRepository;

		public LikesController(IUserRepository userRepository, ILikesRepository likesRepository)
		{
			this.userRepository = userRepository;
			this.likesRepository = likesRepository;
		}

		[HttpPost("{username}")]
		public async Task<ActionResult> AddLike([FromRoute] string username)
		{
			var sourceUserId = User.GetUserId();
			var likedUser = await this.userRepository.GetUserByUsernameAsync(username);
			var sourceUser = await this.likesRepository.GetUserWithLikes(sourceUserId);

			if (likedUser == null)
			{
				return NotFound();
			}

			if (sourceUser.UserName == username)
			{
				return BadRequest("You cannot like yourself.");
			}

			var userLike = await this.likesRepository.GetUserLikes(sourceUserId, likedUser.UserId);

			if (userLike != null)
			{
				return BadRequest("You already like this user");
			}

			userLike = new UserLike 
			{
				SourceUserId = sourceUserId,
				LikedUserId = likedUser.UserId
			};

			sourceUser.LikedUsers.Add(userLike);

			if (await this.userRepository.SaveAllAsync())
			{
				return Ok();
			}

			return BadRequest("Failed");
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<LikeDto>>> GetUserLikes(string predicate)
		{
			var users = await this.likesRepository.GetUserLikes(predicate, User.GetUserId());

			return Ok(users);
		}
	}
}
