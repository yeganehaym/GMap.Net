using System.Collections.Generic;

namespace Gmap.net.Overlays
{
    public class Rectangle:Polygon
    {
        public Rectangle(string id):base(id)
        {
            Points=new List<Location>(4);
        }
    }
}
