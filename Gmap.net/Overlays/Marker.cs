using Gmap.net.Enums;

namespace Gmap.net.Overlays
{
    public class Marker:Common
    {
        public Marker(string id):base(id)
        {
            Icon = "";
            Title = "";
            Animation = MarkerAnimation.None;
        }

        public Marker(string id, Location point, string title = "", string icon = "", MarkerAnimation animation = MarkerAnimation.None):base(id)
        {
            Title = title;
            Icon = icon;
            MarkerPoint = point;
            Animation =animation;
        }


        public string Title { get; set; }
        public string Icon { get; set; }

        /// <summary>
        /// Geo Location 
        /// </summary>
        public Location MarkerPoint { get; set; }
        public MarkerAnimation Animation { get; set; }
        public InfoWindow InfoWindow { get; set; }

      
    }
}
