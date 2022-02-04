using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,16}$",
                            ErrorMessage = "You must enter At least one upper case, one lower case, one digit and Minimum six and Maximum 16 in length.")]
        public string NewPassword { get; set; }

        
        [Compare("NewPassword", ErrorMessage = "Password And Confirm password must match")]
        public string NewConfirmPassword { get; set; }
        
        public string Token { get; set; }
    }
}
