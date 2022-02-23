using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class LoginViewModel
    {
        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Password")]
        public string Password { get; set; }

        [JsonPropertyName("IsRemember")]
        public bool IsRemember { get; set; }
    }
}
