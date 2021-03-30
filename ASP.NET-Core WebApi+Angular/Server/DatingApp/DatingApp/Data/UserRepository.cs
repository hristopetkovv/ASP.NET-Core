using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingApp.DTOs;
using DatingApp.Entities;
using DatingApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Data
{
	public class UserRepository : IUserRepository
	{
		private readonly DataContext context;
		private readonly IMapper mapper;

		public UserRepository(DataContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<User>> GetUsersAsync()
		{
			return await this.context
				.Users
				.Include(p => p.Photos)
				.ToListAsync();
		}

		public async Task<User> GetUserByIdAsync(int id)
		{
			return await this.context.Users.FindAsync(id);
		}

		public async Task<User> GetUserByUsernameAsync(string username)
		{
			return await this.context
				.Users
				.Include(p => p.Photos)
				.SingleOrDefaultAsync(u => u.UserName == username);
		}

		public async Task<bool> SaveAllAsync()
		{
			return await this.context.SaveChangesAsync() > 0;
		}

		public void Update(User user)
		{
			this.context.Entry(user).State = EntityState.Modified;
		}

		public async Task<IEnumerable<MemberDto>> GetMembersAsync()
		{
			return await this.context
				.Users
				.ProjectTo<MemberDto>(this.mapper.ConfigurationProvider)
				.ToListAsync();
		}

		public async Task<MemberDto> GetMemberAsync(string username)
		{
			return await this.context
				.Users
				.Where(x => x.UserName == username)
				.ProjectTo<MemberDto>(this.mapper.ConfigurationProvider)
				.SingleOrDefaultAsync();
		}
	}
}
