using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceApi
{
    public class ApiConfiguration : IApiConfiguration
    {
        public string BaseApiUrl { get; set; }
    }
}
