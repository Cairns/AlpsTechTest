using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliceApi
{
    public interface IPoliceApiEndpoint
    {
        string Path { get; }
    }
}
