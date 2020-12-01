using AutoMapper;
using GroupManagement.Contracts;
using GroupManagement.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GroupManagement.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config; 
        public UserService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IMapper mapper, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _config = config;
        }
        public async Task<UserLoggedInDTO> LogIn(UserDTO loginInfo)
        {
            var result = new UserLoggedInDTO();
            var check = await _signInManager.PasswordSignInAsync(loginInfo.EmailAddress, loginInfo.Password, false, false);
            if (check.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginInfo.EmailAddress);
                result = _mapper.Map<UserLoggedInDTO>(user);
                result.LoggedIn = true;
                result.Token = await GenerateJsonWebToken(user);
            }
            return result;
        }

        public async Task<UserRegistrationResultDTO> Register(UserDTO userInfo)
        {
            
            var newUser = new IdentityUser { Email = userInfo.EmailAddress, UserName = userInfo.EmailAddress };
            var result = await _userManager.CreateAsync(newUser, userInfo.Password);
            var user = new UserRegistrationResultDTO();
            if (!result.Succeeded)
            {
                user.RegistrationErrors = new List<string>();
                foreach (var error in result.Errors)
                {
                    user.RegistrationErrors.Add($"{error.Code} - {error.Description}");
                }
                return user;
            }
            var created = await _userManager.FindByNameAsync(userInfo.EmailAddress);
            user = _mapper.Map<UserRegistrationResultDTO>(created);
            return user;
        }

        private async Task<string> GenerateJsonWebToken(IdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim(ClaimsIdentity.DefaultRoleClaimType, r)));

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                null,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
                );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
