using System.Collections.Generic;

namespace Gmap.net.Overlays
{
    public class Polyline:Overlay
    {
        public Polyline(string id):base(id)
        {
            Points=new List<Location>();
        }

        public List<Location> Points;



    }
}
