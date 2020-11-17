using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliceApi
{
    public class StopAndSearchByAreaEndpoint : IPoliceApiEndpoint
    {
        public string Path => "stops-street?poly={neighbourhoodBoundaryCoordinates}";

        private static readonly StopAndSearchByAreaEndpoint instance = new StopAndSearchByAreaEndpoint();

        private StopAndSearchByAreaEndpoint()
        {
        }

        public static IPoliceApiEndpoint Endpoint => instance;
    }
}
