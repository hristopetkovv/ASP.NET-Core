﻿using AutoMapper;
using DatingApp.DTOs;
using DatingApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
		private readonly IUserRepository userRepository;
		private readonly IMapper mapper;

		public UsersController(IUserRepository userRepository, IMapper mapper)
        {
			this.userRepository = userRepository;
			this.mapper = mapper;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await this.userRepository.GetMembersAsync();

            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await this.userRepository.GetMemberAsync(username);
        }
    }
}
