using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoliceApi;

namespace Police.Web.Client.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PoliceForceController : ControllerBase
    {
        private readonly IApiClient ApiClient;
        private readonly ILogger<PoliceForceController> logger;

        public PoliceForceController(IApiClient apiClient, ILogger<PoliceForceController> logger)
        {
            this.ApiClient = apiClient;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<PoliceForce>> Get()
        {
            //Call our PoliceAPI wrapper
            return await this.ApiClient.GetAsync<List<PoliceForce>>("forces");
        }
    }
}
