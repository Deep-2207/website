using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class AdminEditAndRescheduleViewModel
    {
        [JsonPropertyName("ServicerequestID")]
        public int servicerequestid { get; set; }
        [JsonPropertyName("StartDate")]
        public string startDate { get; set; }
        [JsonPropertyName("StartTime")]
        public string StartTime { get; set; }
        [JsonPropertyName("Streetname")]
        public string Streetname { get; set; }
        [JsonPropertyName("HouseNumber")]
        public string HouseNumber { get; set; }
        [JsonPropertyName("PostalCode")]
        public string postalcode { get; set; }
        [JsonPropertyName("City")]
        public string city { get; set; }
        [JsonPropertyName("Comment")]
        public string comment { get; set; }

    }
}
