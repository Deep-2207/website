using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class BookService
    {
        [Required(ErrorMessage = "Please Enter The Postal Code")]
       // [RegularExpression(@"(^[0-9]$)", ErrorMessage = "Please Enter the Valid Postal Code")]
        [Remote(action: "IsPostalCodeValid", controller: "Home")]
        public string CheckPostalCode { get; set; }
    }
}
