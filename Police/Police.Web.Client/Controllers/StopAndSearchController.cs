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
    public class StopAndSearchController : ControllerBase
    {
        private readonly IApiClient ApiClient;
        private readonly ILogger<StopAndSearchController> logger;

        public StopAndSearchController(IApiClient apiClient, ILogger<StopAndSearchController> logger)
        {
            this.ApiClient = apiClient;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<StopAndSearch>> Get(string policeForce, string neighbourhood)
        {
            //Call our PoliceAPI wrapper
            return await this.ApiClient.GetAsync<List<StopAndSearch>>($"stopsearch?policeForce={policeForce}&neighbourhood={neighbourhood}");
        }
    }
}
