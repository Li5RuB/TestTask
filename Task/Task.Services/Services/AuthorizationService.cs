using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using TestTask.Services.Hasher;
using TestTask.Services.Mappers;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthorizationService(IPasswordHasher passwordHasher, 
            IUserService userService, 
            IRoleService roleService)
        {
            _passwordHasher = passwordHasher;
            _userService = userService;
            _roleService = roleService;
        }

        public async Task<UserModel> LoginUser(LoginModel model)
        {
            var user = await _userService.GetUserByEmail(model.Email);
            if (user != null && _passwordHasher.VerifyHashedPassword(user.Password, model.Password))
            {
                user.LastLogin = DateTime.Now;
                await _userService.UpdateUser(user);
                return user;
            }
            return null;
        }
        
        public async Task RegisterUser(RegisterModel model)
        {
            model.Password = (_passwordHasher.Hash(model.Password));
            await _userService.CreateUser(UserMapper.MapRegisterModelToModel(model));
        }
        
        public async Task<ClaimsIdentity> GetClaimsIdentity(UserModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, (await _roleService.GetById(user.RoleId)).Name), 
            };
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            return claimsIdentity;
        }
    }
}