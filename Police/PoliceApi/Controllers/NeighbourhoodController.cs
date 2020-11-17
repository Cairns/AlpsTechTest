using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoliceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NeighbourhoodController : ControllerBase
    {
        private readonly IPoliceApiService policeApiService;
        private readonly ILogger<NeighbourhoodController> logger;

        public NeighbourhoodController(IPoliceApiService policeApiService, ILogger<NeighbourhoodController> logger)
        {
            this.policeApiService = policeApiService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Neighbourhood>> Get(string policeForce)
        {
            return await this.policeApiService.GetNeighbourhoods(policeForce);
        }
    }
}
