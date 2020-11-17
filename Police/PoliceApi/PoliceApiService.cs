using Microsoft.Extensions.Logging;
using PoliceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliceApi
{
    public class PoliceApiService : IPoliceApiService
    {
        private readonly IApiClient apiClient;
        private readonly ILogger logger;

        public PoliceApiService(IApiClient apiClient, ILogger<PoliceApiService> logger)
        {
            this.apiClient = apiClient;
            this.logger = logger;
        }

        public async Task<IEnumerable<PoliceForce>> GetPoliceForces()
        {
            var url = ForcesEndpoint.Endpoint.Path;

            var forces = await this.apiClient.GetAsync<List<PoliceForce>>(url);

            return forces?.OrderBy(f => f.Name);
        }

        public async Task<IEnumerable<Neighbourhood>> GetNeighbourhoods(string policeForce)
        {
            var url = NeighbourhoodsEndpoint.Endpoint.Path.Replace("{policeForce}", $"{policeForce}");

            var neighbourhoods = await this.apiClient.GetAsync<List<Neighbourhood>>(url);

            return neighbourhoods?.OrderBy(n => n.Name);
        }

        public async Task<NeighbourhoodBoundary> GetNeighbourhoodBoundary(string policeForce, string neighbourhood)
        {
            var url = NeighbourhoodBoundaryEndpoint.Endpoint.Path.Replace("{policeForce}", $"{ policeForce}").Replace("{neighbourhood}", $"{neighbourhood}");

            NeighbourhoodBoundary neighbourhoodBoundary = new NeighbourhoodBoundary();

            var neighbourhoodBoundaryCoordinates = await this.apiClient.GetAsync<List<NeighbourhoodBoundaryCoordinates>>(url);
            neighbourhoodBoundary.BoundaryCoordinates = neighbourhoodBoundaryCoordinates;

            return neighbourhoodBoundary;
        }

        public async Task<IEnumerable<StopAndSearch>> GetStopAndSearches(string policeForce, string neighbourhood)
        {
            var neighbourhoodBoundary = await this.GetNeighbourhoodBoundary(policeForce, neighbourhood);

            var url = StopAndSearchByAreaEndpoint.Endpoint.Path.Replace("{neighbourhoodBoundaryCoordinates}", $"{neighbourhoodBoundary.GetFormattedBoundaryCoordinates()}");

            var stopsStreets = await this.apiClient.GetAsync<List<StopsStreet>>(url);

            var stopAndSearches = StopAndSearchConverter.ConvertFrom(stopsStreets);

            return stopAndSearches?.OrderBy(s => s.DateTime);
        }
    }
}
