using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliceApi
{
    public class NeighbourhoodBoundaryEndpoint : IPoliceApiEndpoint
    {
        public string Path => "{policeForce}/{neighbourhood}/boundary";

        private static readonly NeighbourhoodBoundaryEndpoint instance = new NeighbourhoodBoundaryEndpoint();

        private NeighbourhoodBoundaryEndpoint()
        {
        }

        public static IPoliceApiEndpoint Endpoint => instance;
    }
}
