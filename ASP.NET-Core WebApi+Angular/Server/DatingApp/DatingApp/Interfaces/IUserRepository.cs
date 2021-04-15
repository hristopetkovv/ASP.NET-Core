using DatingApp.DTOs;
using DatingApp.Entities;
using DatingApp.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.Interfaces
{
	public interface IUserRepository
	{
		void Update(User user);

		Task<bool> SaveAllAsync();

		Task<IEnumerable<User>> GetUsersAsync();

		Task<User> GetUserByIdAsync(int id);

		Task<User> GetUserByUsernameAsync(string username);

		Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);

		Task<MemberDto> GetMemberAsync(string username);
	}
}
