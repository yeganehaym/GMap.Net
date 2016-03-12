using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gmap.net.locator.geocoding_classes
{
    [DataContract]
    public class Geometry
    {
        [DataMember(Name = "location")]
        public Location Location { get; set; }
        [DataMember(Name = "location_type")]
        public string LocationType { get; set; }
        [DataMember(Name = "viewport")]
        public ViewPort ViewPort { get; set; }
      
    }
}
