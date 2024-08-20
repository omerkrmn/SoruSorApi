using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EntityManager
{
    public class UserManager : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserManager(IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ICollection<UserDto>> SearchUserAsync(string nickName)
        {
            nickName.Trim();
            nickName.ToLower();
            var users = await _userManager.Users
                .Where(u => u.NickName
                .ToLower()
                .Trim()
                .Contains(nickName)) // kısmi eşleşme için Contains kullanıldı
                .ToListAsync();

            var userDtos = _mapper.Map<ICollection<UserDto>>(users);
            return userDtos.Any() ? userDtos : new List<UserDto>();
        }

    }
}