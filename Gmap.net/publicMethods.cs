using Gmap.net.Enums;

namespace Gmap.net
{
    public partial class GoogleMapApi
    {
        //Methods
        /// <summary>
        /// set geo coordinate,center of map will be on this coordinate
        /// </summary>
        /// <param name="geoCoordinate"></param>
        public void SetLocation(Location geoCoordinate)
        {
            _geoCoordinate = geoCoordinate;
        }

        /// <summary>
        /// specify map appreace
        /// </summary>
        /// <param name="mapType"></param>
        public void SetMapType(MapTypes mapType)
        {
            _mapType = mapType;
        }

        /// <summary>
        /// set zoom on map center,i think 15 to 17 is normal for a natural map
        /// </summary>
        /// <param name="zoom">enter int</param>
        public void SetZoom(int zoom)
        {
            _zoom = zoom;
        }

        /// <summary>
        /// if you have apikey from google
        /// </summary>
        /// <param name="apikey"></param>
        public void SetApiKey(string apikey)
        {
            _apiKey = apikey;
        }

        /// <summary>
        /// show map controls
        /// </summary>
        /// <param name="visibility"></param>
        public void MapTypeControlVisibility(bool visibility)
        {
            _mapTypeControl = visibility;
        }

        /// <summary>
        /// show navigation tools on map
        /// </summary>
        /// <param name="visibility"></param>
        public void NavigationControlVisibility(bool visibility)
        {
            _navigationControl = visibility;
        }

        /// <summary>
        /// show scale control
        /// </summary>
        /// <param name="visibility"></param>
        public void ScaleControlVisibility(bool visibility)
        {
            _scaleControl = visibility;
        }


        public void DisableDoubleClickZoom(bool state)
        {
            _disableDoubleClickZoom = state;
        }

        public void SetScrollWheel(bool enable)
        {
            _scrollwheel = enable;
        }

        public void Draggable(bool enable)
        {
            _scrollwheel = enable;
        }

        public void StreetViewControl(bool visibility)
        {
            _streetViewControl = visibility;
        }

        public void PanControl(bool enable)
        {
            _panControl = enable;
        }

        public void KeyboardShortcuts(bool enable)
        {
            _keyboardShortcuts = enable;
        }
        public void SetDraggingCursor(Cursor cur)
        {
            _draggingCursor = cur;
        }
        public void SetDraggableCursor(Cursor cur)
        {
            _draggableCursor = cur;
        }

        public void SetBackgroundColor(System.Drawing.Color color)
        {
            _backgroundColor = color;
        }

        public void UiControlsState(bool enable)
        {
            _disableDefaultUi = enable;
        }

        public void ZoomControlVisibilty(bool enable)
        {
            _zoomControl = enable;
        }

        public void RotationControlVisibility(bool visibility)
        {
            _rotateControl = visibility;
        }

        public OverviewMapControlOptions OverviewOptions { get; set; }

        public zoomControlOptions ZoomOptions { get; set; }

        public rotateControlOptions RotateControlsOptions { get; set; }

    }
}
