using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsApi;

namespace Gmap.net.locator
{
    public class ComponentFiltering
    {
        private int administrative_area = 0;
        public string Route { get; set; }
        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string Locality { get; set; }
        public int AdministrativeAreaLevel
        {
            get { return administrative_area; }
            set { if (value > 0 && value < 6) administrative_area = value; }
        }

        public override string ToString()
        {
            QueryStringParametersList filterList = new QueryStringParametersList("|");

            if (Route.Trim().Length > 0) filterList.Add("route", Route);
            if (Locality.Trim().Length > 0) filterList.Add("locality ", Locality);
            if (administrative_area > 0) filterList.Add("administrative_area", "administrative_area_level" + AdministrativeAreaLevel);
            if (PostalCode.Trim().Length > 0) filterList.Add("postal_code", PostalCode);
            if (Country.Trim().Length > 0) filterList.Add("country", Country);

            if (filterList.Size > 0)
                return filterList.GetQueryStringPostfix();

                return string.Empty;
        }
    }
}
