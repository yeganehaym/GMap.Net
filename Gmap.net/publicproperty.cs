using System.Collections.Generic;
using Gmap.net.Enums;
using Gmap.net.Overlays;

namespace Gmap.net
{
    public partial class GoogleMapApi
    {
        //Constructing
        public GoogleMapApi(bool overviewMapControl)
        {
            _overviewMapControl = overviewMapControl;
        }

        public GoogleMapApi(string apiKey, bool overviewMapControl)
        {
            _overviewMapControl = overviewMapControl;
            _apiKey = apiKey;
        }

        public GoogleMapApi(Location geoCoordinate, bool overviewMapControl, int zoom = 0, MapTypes mapType = MapTypes.ROADMAP, string apiKey = "")
        {
            _overviewMapControl = overviewMapControl;
            _apiKey = apiKey;
            _mapType = mapType;
            _zoom = zoom;
            _geoCoordinate = geoCoordinate;
        }

        //public properties

        /// <summary>
        /// If you enable it ,your output js code will be minified
        /// </summary>
        public bool Minified { get; set; }

        public List<Marker> Markers = new List<Marker>();
        public List<Polyline> Polylines = new List<Polyline>();
        public List<Polygon> Polygons = new List<Polygon>();
        public List<CircleMarker> Circles = new List<CircleMarker>();
        public List<Rectangle> Rectangles = new List<Rectangle>();


        public MapTypeOptions MapOptions { get; set; }
        public navigationControlOptions ControlOptions { get; set; }


        public ScaleOptions ScaleOptions { get; set; }

        /// <summary>
        /// set your cursor icon address when your mouse is on map
        /// </summary>
        public string DraggableCustomCursorAddress { get; set; }

        /// <summary>
        /// set your cursor icon address when your mouse is dragging the map
        /// </summary>
        public string DraggingCustomCursorAddress { get; set; }
       
  
    }
}
