using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
   public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$",
             ErrorMessage = "Passwords should contain atleast 8 characters and should contain these: upper case (A-Z), lower case (a-z), number (0-9) and special character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        public string ConfirmPassword { get; set; }

   }
}
