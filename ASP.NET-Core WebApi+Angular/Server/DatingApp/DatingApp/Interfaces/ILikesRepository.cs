using DatingApp.DTOs;
using DatingApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.Interfaces
{
	public interface ILikesRepository
	{
		Task<UserLike> GetUserLikes(int sourceUserId, int likedUserId);

		Task<User> GetUserWithLikes(int userId);

		Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId);
	}
}
