using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliceApi
{
    public class ForcesEndpoint : IPoliceApiEndpoint
    {
        public string Path => "forces";

        private static readonly ForcesEndpoint instance = new ForcesEndpoint();

        private ForcesEndpoint()
        {
        }

        public static IPoliceApiEndpoint Endpoint => instance;
    }
}
