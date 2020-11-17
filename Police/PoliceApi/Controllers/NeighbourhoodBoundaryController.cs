using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PoliceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NeighbourhoodBoundaryController : ControllerBase
    {
        private readonly IPoliceApiService policeApiService;
        private readonly ILogger<NeighbourhoodBoundaryController> logger;

        public NeighbourhoodBoundaryController(IPoliceApiService policeApiService, ILogger<NeighbourhoodBoundaryController> logger)
        {
            this.policeApiService = policeApiService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<NeighbourhoodBoundary> Get(string policeForce, string neighbourhood)
        {
            return await this.policeApiService.GetNeighbourhoodBoundary(policeForce, neighbourhood);
        }
    }
}
