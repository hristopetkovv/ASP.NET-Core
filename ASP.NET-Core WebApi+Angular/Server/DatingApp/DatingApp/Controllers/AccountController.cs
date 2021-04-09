﻿using AutoMapper;
using DatingApp.Data;
using DatingApp.DTOs;
using DatingApp.Entities;
using DatingApp.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
	public class AccountController : BaseApiController
	{
		private readonly DataContext context;
		private readonly ITokenService tokenService;
		private readonly IMapper mapper;

		public AccountController(DataContext context, ITokenService tokenService, IMapper mapper)
		{
			this.context = context;
			this.tokenService = tokenService;
			this.mapper = mapper;
		}

		[HttpPost("register")]
		public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
		{
			if (await this.UserExists(registerDto.Username))
			{
				return BadRequest("Username is taken");
			}

			var user = this.mapper.Map<User>(registerDto);

			using var hmac = new HMACSHA512();

			user.UserName = registerDto.Username.ToLower();
			user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
			user.PasswordSalt = hmac.Key;

			context.Users.Add(user);
			await context.SaveChangesAsync();

			return new UserDto {
				Username = user.UserName,
				Token = this.tokenService.CreateToken(user),
				KnownAs = user.KnownAs
			};
		}

		[HttpPost("login")]
		public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
		{
			var user = await this.context
				.Users
				.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

			if (user == null)
			{
				return Unauthorized("Invalid username");
			}

			using var hmac = new HMACSHA512(user.PasswordSalt);

			var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

			for (int i = 0; i < computedHash.Length; i++)
			{
				if (computedHash[i] != user.PasswordHash[i])
				{
					return Unauthorized("Invalid password");
				}
			}

			return new UserDto {
				Username = user.UserName,
				Token = this.tokenService.CreateToken(user),
				KnownAs = user.KnownAs
			};
		}

		private async Task<bool> UserExists(string username)
		{
			return await this.context.Users.AnyAsync(u => u.UserName == username.ToLower());
		}
	}
}
