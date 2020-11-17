using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceApi
{
    public class StopAndSearch
    {
        public DateTimeOffset DateTime { get; set; }

        public string Gender { get; set; }

        public string AgeRange { get; set; }

        public string ObjectOfSearch { get; set; }

        //Included for React table unique key requirement - Ideally would have moved into a different class to facilitate this functionality
        public Guid ID => Guid.NewGuid();
    }
}
