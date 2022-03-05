using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class UserAddressViewModel
    {
       
        [JsonPropertyName("StreetName")]
        public string StreetName { get; set; }
       
        [JsonPropertyName("Housenumber")]
        public string HouseNumber { get; set; }
        [JsonPropertyName("City")]
        public string City { get; set; }
        [JsonPropertyName("PostalCode")]
        public string PostalCode { get; set; }
        
        [JsonPropertyName("MobileNumber")]
        public string MobileNumber { get; set; }

        [JsonPropertyName("userid")]
        public string UserID { get; set; }

        [JsonPropertyName("addressid")]
        public string Addressid { get; set; }
    }
}
