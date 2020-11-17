using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceApi
{
    public interface IApiConfiguration
    {
        string BaseApiUrl { get; }
    }
}
