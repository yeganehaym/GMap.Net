using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmap.net.Overlays
{
    /// <summary>
    /// Rect is subclass of Rectangle to avoid conflicts of System.Drawing.Rectangle with Gmap.net.Overlays.rectangle
    /// </summary>
    public class Rect:Rectangle
    {
        public Rect(string id) : base(id)
        {
        }
    }
}
