using System.Drawing;


namespace Gmap.net.Overlays
{
    public class Polygon:Polyline,IFillProperties
    {
        public Polygon(string id):base(id)
        {
            
        }
       
        public Color FillColor { get; set; }
        public float FillOpacity { get; set; }
    }
}
