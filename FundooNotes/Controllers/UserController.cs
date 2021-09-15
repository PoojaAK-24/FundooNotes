using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Authorize]
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly private IUserBL _userBL;
        readonly private IConfiguration _config;
        public UserController(IUserBL userBL, IConfiguration config)
        {
            this._userBL = userBL;
            this._config = config;
        }
        
        [HttpGet]
        public IActionResult getAllUsers()
        {
            var useList = this._userBL.getAllUsers();
            return this.Ok(new { Success = true, message = "Get User Data SuccessFully.", Data = useList });
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RegisterUser(UserModel userModel)
        {
            try
            {
                bool result = this._userBL.RegisterUser(userModel);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Registered User SuccessFully." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "User registration failed." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult UserLogin([FromBody] LoginModel loginModel)
        {
            try
            {
                IActionResult response = Unauthorized();
                User user = _userBL.UserLogIn(loginModel);
                //bool result = true;
                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(user.Id, user.Email);
                    var userData = new { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, CreatedAt = user.CreatedAt, ModifiedAt = user.ModifiedAt };

                    response = Ok(new { Success = true, Message = "Log In Successful!!", token = tokenString, Data = userData });
                }

                return response;
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message, stackTrace = e.StackTrace });
            }
        }
        private string GenerateJSONWebToken(long Id, String email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Claims = new[]
           {
                new Claim("Id",Id.ToString()),
                new Claim(ClaimTypes.Email,email)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
             Claims,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
         }
    }
}