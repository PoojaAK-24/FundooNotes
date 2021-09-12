﻿using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBL _userBL;
        public UserController(IUserBL userBL)
        {
            this._userBL = userBL;
        }

        [HttpGet]
        public IActionResult userData()
        {
            var useList = this._userBL.getAllUsers();
            return this.Ok(new { Success = true, message = "Get User Data SuccessFully.", Data = useList });
        }

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

        [HttpPost("login")]
        public IActionResult UserLogin(LoginModel loginModel)
        {
            try
            {
                bool result = _userBL.UserLogIn(loginModel);

                if (result == true)
                {
                    return this.Ok(new { Success = true, Message = "Log In Successful!" });
                }
                else
                {
                    return this.Ok(new { Success = this.NotFound(), Message = "Log In Failed!" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message, stackTrace = e.StackTrace });
            }
        }

    }


}