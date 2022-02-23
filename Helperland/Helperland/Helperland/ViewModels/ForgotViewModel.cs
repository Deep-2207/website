using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class ForgotViewModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
