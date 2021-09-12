using BusinessLayer.Interface;
using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        private IUserRL _userRL;
        public UserBL(IUserRL userRL)
        {
            this._userRL = userRL;
        }
        public List<UserModel> getAllUsers()
        {
            try
            {
                return this._userRL.getAllUsers();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RegisterUser(UserModel userModel)
        {
            try
            {
                return this._userRL.RegisterUser(userModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UserLogIn(LoginModel loginModel)
        {
            try
            {
                return this._userRL.LoginUser(loginModel);
            }
            catch (Exception)
            {
                throw; 
            }
        }
    }
}
    

