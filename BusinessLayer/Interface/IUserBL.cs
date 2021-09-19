using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        List<UserModel> getAllUsers();
        bool RegisterUser(UserModel userModel);
        User UserLogIn(LoginModel loginModel);
        User ForgotPassword(ForgotPasswordModel forgotpasswordModel);
        User ResetPassword(ResetPasswordModel resetpasswordModel,long UserId);
     }
}
