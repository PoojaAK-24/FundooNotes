using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserRL
    {
        List<UserModel> getAllUsers();
        bool RegisterUser(UserModel userModel);
        User LoginUser(LoginModel loginModel);
        User ForgotPassword(ForgotPasswordModel forgotpasswordModel);
        User ResetPassword(ResetPasswordModel resetpasswordModel, long UserId);


    }
}
