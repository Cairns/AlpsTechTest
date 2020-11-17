using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoliceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForcesController : ControllerBase
    {
        private readonly IPoliceApiService policeApiService;
        private readonly ILogger<ForcesController> logger;

        public ForcesController(IPoliceApiService policeApiService, ILogger<ForcesController> logger)
        {
            this.policeApiService = policeApiService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<PoliceForce>> Get()
        {
            return await this.policeApiService.GetPoliceForces();
        }
    }
}
