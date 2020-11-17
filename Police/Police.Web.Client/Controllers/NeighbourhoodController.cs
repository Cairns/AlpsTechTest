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
    public class NeighbourhoodController : ControllerBase
    {
        private readonly IApiClient ApiClient;
        private readonly ILogger<NeighbourhoodController> logger;

        public NeighbourhoodController(IApiClient apiClient, ILogger<NeighbourhoodController> logger)
        {
            this.ApiClient = apiClient;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Neighbourhood>> Get(string policeForce)
        {
            //Call our PoliceAPI wrapper
            return await this.ApiClient.GetAsync<List<Neighbourhood>>($"neighbourhood?policeForce={policeForce}");
        }
    }
}
