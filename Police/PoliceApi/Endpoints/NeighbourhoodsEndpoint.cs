using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace PoliceApi
{
    public class NeighbourhoodsEndpoint : IPoliceApiEndpoint
    {
        public string Path => "{policeForce}/neighbourhoods";

        private static readonly NeighbourhoodsEndpoint instance = new NeighbourhoodsEndpoint();

        private NeighbourhoodsEndpoint()
        {
        }

        public static IPoliceApiEndpoint Endpoint => instance;
    }
}
