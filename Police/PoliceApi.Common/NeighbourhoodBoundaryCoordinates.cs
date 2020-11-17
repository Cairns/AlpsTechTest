using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceApi
{
    /// <summary>
    /// Latitude/Longitude pair that make up part of a neighbourhood boundary
    /// </summary>
    public class NeighbourhoodBoundaryCoordinates : IEquatable<NeighbourhoodBoundaryCoordinates>
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        //Provides a formatted version of this Latitude coordinate to 2 decimal places
        public string FormattedLatitude => FormatCoordinateTwoDecimalPoints(this.Latitude);

        //Provides a formatted version of this Longitude coordinate to 2 decimal places
        public string FormattedLongitude => FormatCoordinateTwoDecimalPoints(this.Longitude);

        //PoliceAPI constraint for stops and searches by area endpoint
        //cannot handle the volume of data supplied if using original latitude and longitude
        //so we shorten to 2 decimal places
        private string FormatCoordinateTwoDecimalPoints(double value)
        {
            return string.Format("{0:f2}", value);
        }

        public bool Equals(NeighbourhoodBoundaryCoordinates other)
        {
                if (ReferenceEquals(this, other))
                    return true;

                return this.FormattedLatitude.Equals(other.FormattedLatitude)
                    && this.FormattedLongitude.Equals(other.FormattedLongitude);
        }

        public override int GetHashCode()
        {
            int hashedLatitude = FormattedLatitude.GetHashCode();
            int hashedLongitude =FormattedLongitude.GetHashCode();

            return hashedLatitude ^ hashedLongitude;
        }

        //Provides a formatted version of this Latitude and Longitude coordinates to 2 decimal places, separated with a comma
        public override string ToString()
        {
            return string.Join(',', FormattedLatitude, FormattedLongitude);
        }
    }
}
