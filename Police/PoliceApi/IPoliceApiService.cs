using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliceApi
{
    public interface IPoliceApiService
    {
        Task<IEnumerable<PoliceForce>> GetPoliceForces();
        Task<IEnumerable<Neighbourhood>> GetNeighbourhoods(string policeForce);
        Task<NeighbourhoodBoundary> GetNeighbourhoodBoundary(string policeForce, string neighbourhood);
        Task<IEnumerable<StopAndSearch>> GetStopAndSearches(string policeForce, string neighbourhood);
    }
}
