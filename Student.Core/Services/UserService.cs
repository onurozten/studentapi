using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Student.Core.Models;
using Student.Core.Models.User;
using Student.Data.Entities;

namespace Student.Core.Services
{
    public class UserService  :IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(AppSettings appSettings, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _appSettings = appSettings;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<object> CreateTestUser()
        {
            var user = new User()
            {
                UserName = "onur",
                Firstname = "Onur",
                Lastname = "ÖZTEN",
                Email = "onur301@gmail.com",
            };

            var u = await _userManager.CreateAsync(user, "123456");
            return u;
        }


        public async Task<UserInfoModel> AuthenticateAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return null;

            var signinResult = await _signInManager.PasswordSignInAsync(username, password, false, false);
            if (signinResult.Succeeded)
            {
                //var us = userManager.FindByNameAsync(username).Result;
                var model = new UserInfoModel();

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var signingKey = new SymmetricSecurityKey(key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Firstname),
                        new Claim(ClaimTypes.Surname, user.Lastname),
                    }),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                model.Token = tokenHandler.WriteToken(token);
                return model;
            }
            
            return null;
        }

        
    }
}
