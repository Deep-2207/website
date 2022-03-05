using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class ServiceRequestViewModel
    {
        [JsonPropertyName("ServiceRequestID")]
        public int ServiceRequestID { get; set; }
        [JsonPropertyName("userid")]
        public string UserId { get; set; }

        [JsonPropertyName("zipcode")]
        public string ZipCode { get; set; }

      
        [JsonPropertyName("serviceStartDate")]
        public string ServiceStartDate { get; set; }
        [JsonPropertyName("serviceStarttime")]
        public string ServiceStarttime { get; set; }

        [JsonPropertyName("servicehourlyRate")]
        public Decimal ServiceHourlyRate { get; set; }

        [JsonPropertyName("serviceHours")]
        public Decimal ServiceHours { get; set; }

        [JsonPropertyName("extraHours")]
        public Decimal ExtraHours { get; set; }

        [JsonPropertyName("extraservicesName")]
        public string[] ExtraservicesName { get; set; }


        [JsonPropertyName("subtotal")]
        public Decimal SubTotal { get; set; }

        [JsonPropertyName("totalcost")]
        public Decimal TotalCost { get; set; }

        [JsonPropertyName("comments")]
        public string Comments { get; set; }

       

      

        [JsonPropertyName("haspets")]
        public bool HasPets { get; set; }

        //JsonPropertyName("serviceDate")]
        //public int? Status { get; set; }
        //public string CreatedDate { get; set; }

        //[JsonPropertyName("serviceDate")]
        //public string ModifiedDate { get; set; }

        //[JsonPropertyName("userid")]
        //public int ModifiedBy { get; set; }

        //[JsonPropertyName("StreetName")]
        //public int Distance { get; set; }

        [JsonPropertyName("userAddressID")]
        public string UserAddressID { get; set; }

        [JsonPropertyName("paymentdone")]
        public bool PaymentDone { get; set; }
     


        //public virtual User ServiceProvider { get; set; }
        //public virtual User User { get; set; }
        //public virtual ICollection<Rating> Ratings { get; set; }
        //public virtual ICollection<ServiceRequestAddress
    }
}
