using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoliceApi
{
    public class NeighbourhoodBoundary
    {
        public IEnumerable<NeighbourhoodBoundaryCoordinates> BoundaryCoordinates { get; set; }

        public string GetFormattedBoundaryCoordinates()
        {
            var formattedBoundaryCoordinates = BoundaryCoordinates.Distinct();
            return string.Join(":", formattedBoundaryCoordinates);
        }
    }
}
