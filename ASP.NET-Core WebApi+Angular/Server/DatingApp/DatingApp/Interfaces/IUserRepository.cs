﻿using DatingApp.DTOs;
using DatingApp.Entities;
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

		Task<IEnumerable<MemberDto>> GetMembersAsync();

		Task<MemberDto> GetMemberAsync(string username);
	}
}
