using AutoMapper;
using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.EntityManager
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration _configuration;

        private User? _user;

        public AuthenticationManager(UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
        {
            this.userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSiginCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }



        public async Task<IdentityResult> RegisterUser(UserForRegisterDTO userForRegisterDTO)
        {
            var user = _mapper.Map<User>(userForRegisterDTO);
            var result = await userManager.CreateAsync(user, userForRegisterDTO.Password);

            if (result.Succeeded)
                await userManager.AddToRolesAsync(user, userForRegisterDTO.Roles);
            return result;
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDTO userForAuthenticationDTO)
        {
            _user = await userManager.FindByNameAsync(userForAuthenticationDTO.UserName);
            var result = (_user != null && await userManager.CheckPasswordAsync(_user, userForAuthenticationDTO.Password));
            if (!result) throw new EntityNotFoundException<User>(0);
            return result;
        }

        private SigningCredentials GetSiginCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            // Kullanıcı bilgilerini al
            var userId = _user.Id.ToString();

            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, _user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, userId)
                };

            var roles = await userManager
                .GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }


        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials,
            List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken(
                    issuer: jwtSettings["validIssuer"],
                    audience: jwtSettings["validAudience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                    signingCredentials: signinCredentials);
            return tokenOptions;
        }

    }
}
