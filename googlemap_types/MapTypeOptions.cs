using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmap.net
{
    public class MapTypeOptions:commonOptions
    {
        public TypeControlsStyle Style { get; set; }

        public List<MapTypes> Maptypes { get; set; }

    }
}
