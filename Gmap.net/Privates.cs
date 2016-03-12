using Gmap.net.Enums;

namespace Gmap.net
{
    public partial class GoogleMapApi
    {

        //private properties
        private string _apiKey = "";
        private Location _geoCoordinate = new Location(0, 0);
        private int _zoom;
        private MapTypes _mapType = MapTypes.ROADMAP;

        private bool _mapTypeControl;
        private bool _navigationControl;
        private bool _scaleControl;

        private bool _disableDoubleClickZoom;
        private bool _scrollwheel = true;
        private bool draggable = true;
        private bool _streetViewControl;
        private bool _panControl;
        private System.Drawing.Color _backgroundColor = System.Drawing.Color.Gray;
        private bool _disableDefaultUi ;
        private Cursor _draggableCursor = Cursor.Default;
        private Cursor _draggingCursor = Cursor.Default;
        private bool _keyboardShortcuts ;
        private bool _overviewMapControl;
        private bool _zoomControl ;
        private bool _rotateControl ;

    }
}
