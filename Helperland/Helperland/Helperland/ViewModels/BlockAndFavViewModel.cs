using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class BlockAndFavViewModel
    {
        [JsonProperty("spid")]
        public int ServiceProviderid { get; set; }
        [JsonProperty("isfav")]
        public bool isfav { get; set; }
        [JsonProperty("isblock")]
        public bool isblock { get; set; }
        

    }
}
