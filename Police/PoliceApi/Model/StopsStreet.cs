using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliceApi.Model
{
    public class StopsStreet
    {
        public DateTimeOffset DateTime { get; set; }

        public string Gender { get; set; }

        [JsonProperty("age_range")]
        public string AgeRange { get; set; }

        [JsonProperty("object_of_search")]
        public string ObjectOfSearch { get; set; }
    }
}
