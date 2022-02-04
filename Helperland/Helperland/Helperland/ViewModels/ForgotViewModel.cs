using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Please Enter the Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter the Valid Email Address")]
        public string Email { get; set; }
    }
}
