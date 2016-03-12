using System.Drawing;

namespace Gmap.net.Overlays
{
    public class CircleMarker:Overlay,IFillProperties
    {
        public CircleMarker(string id):base(id)
        {

        }

        public Location Point { get; set; }
        public int Radius { get; set; }
        public Color FillColor { get; set; }
        public float FillOpacity { get; set; }
    }
}
