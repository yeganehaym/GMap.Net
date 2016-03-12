using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsApi;

namespace Gmap.net.locator
{
    public class PlaceQueryParams
    {

        public PlaceQueryParams()
        {
            RankBy = Ranks.Prominence;
            PlaceTypesList=new QueryStringParametersList("|");
        }
        public double? radius ;
        public Location Location { get; set; }

        public double? Radius
        {
            get { return radius; }
            set
            {
                if (value < 1)
                    radius = 1;
                else if (value > 50000)
                    radius = 50000;
                else
                {
                    radius = value;
                }
            }
        }

        public string Keyword { get; set; }
        public string Language { get; set; }

        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

        public string Name { get; set; }

        public string PageToken { get; set; }

        public Ranks RankBy { get; set; }

        public bool Zagatselected { get; set; }
        public QueryStringParametersList PlaceTypesList { get; set; }

    }
}
