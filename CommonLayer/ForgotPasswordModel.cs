using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
   public class ForgotPasswordModel
    {
    
        [Required]
        [EmailAddress]
        public string Email { get; set; }
   
    }
}
