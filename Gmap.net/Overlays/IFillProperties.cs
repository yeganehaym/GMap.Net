using System.Drawing;

namespace Gmap.net.Overlays
{
    public interface IFillProperties
    {
        Color FillColor { get; set; }
        float FillOpacity { get; set; }
    }
}
