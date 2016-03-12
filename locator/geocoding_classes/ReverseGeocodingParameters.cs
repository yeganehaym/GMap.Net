using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmap.net.locator.geocoding_classes
{
    public class ReverseGeocodingParameters
    {

        public ReverseGeocodingParameters()
        {
            this.LocationType = LocationType.None;
            this.ResultType = ResultType.None;
            Lanuage = "";
        }
        public LocationType LocationType { get; set; }
        public ResultType ResultType { get; set; }

        public string Lanuage { get; set; }

    }
}
