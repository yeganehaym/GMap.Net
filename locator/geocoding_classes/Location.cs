using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gmap.net
{
    [DataContract]
    public class Location
    {
        //properties
        [DataMember(Name = "lng")]
        public double Longitude { get; set; }

        [DataMember(Name = "lat")]
        public double Latitude { get; set; }

        //constructor
         public Location()
        {

        }
         public Location(double Latitude, double Longitude)
        {
            this.Longitude = Longitude;
            this.Latitude = Latitude;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", Latitude, Longitude);
        }
    }
}
