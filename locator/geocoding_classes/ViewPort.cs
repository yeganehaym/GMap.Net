using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gmap.net.locator.geocoding_classes
{
    [DataContract]
    public class ViewPort
    {
        [DataMember(Name = "northeast")]
        public Location NorthEast { get; set; }
        [DataMember(Name = "southwest")]
        public Location SouthWest { get; set; }
    }
}
