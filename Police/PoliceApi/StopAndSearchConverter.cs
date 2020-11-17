using PoliceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliceApi
{
    public class StopAndSearchConverter
    {
        public static IEnumerable<StopAndSearch> ConvertFrom(IEnumerable<StopsStreet> stopsStreets)
        {
            var stopAndSearches = new List<StopAndSearch>();

            foreach (var stopStreet in stopsStreets)
            {
                var stopAndSearch = ConvertFrom(stopStreet);
                stopAndSearches.Add(stopAndSearch);
            }

            return stopAndSearches;
        }

        public static StopAndSearch ConvertFrom(StopsStreet stopStreet)
        {
            var stopAndSearch = new StopAndSearch
            {
                DateTime = stopStreet.DateTime,
                Gender = stopStreet.Gender,
                AgeRange = stopStreet.AgeRange,
                ObjectOfSearch = stopStreet.ObjectOfSearch
            };

            return stopAndSearch;
        }
    }
}
