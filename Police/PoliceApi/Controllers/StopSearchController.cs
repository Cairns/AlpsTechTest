using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoliceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StopSearchController : ControllerBase
    {
        private readonly IPoliceApiService policeApiService;
        private readonly ILogger<StopSearchController> logger;

        public StopSearchController(IPoliceApiService policeApiService, ILogger<StopSearchController> logger)
        {
            this.policeApiService = policeApiService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<StopAndSearch>> Get(string policeForce, string neighbourhood)
        {
            return await this.policeApiService.GetStopAndSearches(policeForce, neighbourhood);
        }
    }
}
