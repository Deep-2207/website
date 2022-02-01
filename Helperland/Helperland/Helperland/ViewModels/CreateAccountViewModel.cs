using Helperland.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    
    public class CreateAccountViewModel
    {
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Phone Number is not Valid")]
        public string mobileno { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email is not Valid")]
        public string email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,16}$", 
                            ErrorMessage = "You must enter At least one upper case, one lower case, one digit and Minimum six and Maximum 16 in length.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [Compare("Password", ErrorMessage = "Password And Confirm password must match")]
        public string ConfirmPassword { get; set; }

     
    }
}
