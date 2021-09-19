using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Entity;
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

        public User UserLogIn(LoginModel loginModel)
        {
            try
            {
                return _userRL.LoginUser(loginModel);
            }
            catch (Exception)
            {
                throw; 
             }
        }
       

        public User ForgotPassword(ForgotPasswordModel forgotpasswordModel)
        {
            try
            {
                return _userRL.ForgotPassword(forgotpasswordModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User ResetPassword(ResetPasswordModel resetpasswordModel,long UserId)
        {
            try
            {
                return _userRL.ResetPassword(resetpasswordModel,UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
    

