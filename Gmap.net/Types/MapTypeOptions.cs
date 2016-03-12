using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmap.net.Enums;

namespace Gmap.net
{
    public class MapTypeOptions:CommonOptions
    {
        public TypeControlsStyle Style { get; set; }

        public List<MapTypes> Maptypes { get; set; }

    }
}
