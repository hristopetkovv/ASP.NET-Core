﻿using DatingApp.DTOs;
using DatingApp.Entities;
using DatingApp.Extensions;
using DatingApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Data
{
	public class LikesRepository : ILikesRepository
	{
		private readonly DataContext context;

		public LikesRepository(DataContext context)
		{
			this.context = context;
		}

		public async Task<UserLike> GetUserLikes(int sourceUserId, int likedUserId)
		{
			return await this.context.Likes.FindAsync(sourceUserId, likedUserId);
		}

		public async Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId)
		{
			var users = this.context.Users.OrderBy(u => u.UserName).AsQueryable();

			var likes = this.context.Likes.AsQueryable();

			if (predicate == "liked")
			{
				likes = likes.Where(like => like.SourceUserId == userId);
				users = likes.Select(like => like.LikedUser);
			}

			if (predicate == "likedBy")
			{
				likes = likes.Where(like => like.LikedUserId == userId);
				users = likes.Select(like => like.SourceUser);
			}

			return await users.Select(user => new LikeDto 
			{
				Username = user.UserName,
				KnownAs = user.KnownAs,
				Age = user.DateOfBirth.CalculateAge(),
				PhotoUrl = user.Photos.FirstOrDefault(p => p.IsMain).Url,
				City = user.City,
				Id = user.UserId
			}).ToListAsync();
		}

		public async Task<User> GetUserWithLikes(int userId)
		{
			return await this.context.Users
				.Include(x => x.LikedUsers)
				.FirstOrDefaultAsync(x => x.UserId == userId);
		}
	}
}
