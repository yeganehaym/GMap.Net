using System.Runtime.Serialization;

namespace Gmap.net
{
    public class Location
    {
        //properties
        public double Longitude { get; set; }

        public double Latitude { get; set; }

        //constructor
         public Location()
        {

        }
         public Location(double latitude, double longitude)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", Latitude, Longitude);
        }
    }
}
