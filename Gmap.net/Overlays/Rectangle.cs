using System.Collections.Generic;

namespace Gmap.net.Overlays
{
    /// <summary>
    /// if you have a conflict with System.Drawing.Rectangle , you should use Gmap.net.Overlays.Rect (Rect is subclass of Rectangle)
    /// </summary>
    public class Rectangle:Polygon
    {
        public Rectangle(string id):base(id)
        {
            Points=new List<Location>(4);
        }
    }
}
