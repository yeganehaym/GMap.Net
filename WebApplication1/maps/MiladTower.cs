using System.Drawing;
using Gmap.net;
using Gmap.net.Enums;
using Gmap.net.Overlays;
using Rectangle = Gmap.net.Overlays.Rectangle;

namespace WebApplication1.maps
{
    public class MiladTower
    {
        public GoogleMapApi TestMarker()
        {
            var map=new GoogleMapApi(true);
            var location = new Location(35.7448416, 51.3753212);
            map.SetLocation(location);
            map.SetZoom(17);
            map.SetMapType(MapTypes.ROADMAP);
            map.SetBackgroundColor(Color.Aqua);
            map.ZoomControlVisibilty(true);
            map.ZoomOptions = new zoomControlOptions()
            {
                Position = Position.TOP_LEFT,
                ZoomStyle = ZoomStyle.SMALL
            };
            map.ScaleControlVisibility(true);
            map.ScaleOptions = new ScaleOptions()
            {
                Position = Position.BOTTOM_LEFT,
                Style = NavigationStyle.SMALL
            };
            map.NavigationControlVisibility(true);
            map.ControlOptions = new navigationControlOptions()
            {
                Position = Position.TOP_RIGHT,
                Style = NavigationStyle.DEFAULT
            };
            
            Marker marker=new Marker("mymarker1");
            marker.InfoWindow=new InfoWindow("iw1")
            {
                Content = "<b>Milad Tower</b><i>in Tehran</i><br/>Milad Tower is the highest tower in iran,many people and tourists visit it each year, but it's so expensive that i cant afford it as iranian citizen<br/>please see more info at  <a href=\"https://en.wikipedia.org/wiki/Milad_Tower\"><img width='16px' height='16px' src='https://en.wikipedia.org/favicon.ico'/>wikipedia</a>"
            };
            marker.MarkerPoint = location;
            map.Markers.Add(marker);

            var circle=new CircleMarker("mymarker2");
            circle.FillColor = Color.Green;
            circle.FillOpacity = 0.6f;
            circle.StrokeColor = Color.Red;
            circle.StrokeOpacity = 0.8f;
            circle.Point = location;
            circle.Radius = 30;
            circle.Editable = true;
            circle.StrokeWeight = 3;
            map.Circles.Add(circle);

            Rectangle rect=new Rectangle("rect1");
            rect.FillColor = Color.Black;
            rect.FillOpacity = 0.4f;
            rect.Points.Add(new Location(35.74728723483808, 51.37550354003906));
            rect.Points.Add(new Location(35.74668641224311, 51.376715898513794));
            map.Rectangles.Add(rect);

            Polyline polyline=new Polyline("poly1");
            polyline.Points.Add(new Location(35.74457043569041, 51.373915672302246));
            polyline.Points.Add(new Location(35.74470976097927, 51.37359380722046));
            polyline.Points.Add(new Location(35.744378863020074, 51.37337923049927));
            polyline.StrokeColor = Color.Blue;
            polyline.StrokeWeight = 2;
            map.Polylines.Add(polyline);

            Polygon polygon=new Polygon("poly2");
            polygon.Points.Add(new Location(35.746494844665094, 51.374655961990356));
            polygon.Points.Add(new Location(35.74635552250061, 51.37283205986023));
            polygon.Points.Add(new Location(35.74598109297522, 51.372681856155396));
            polygon.Points.Add(new Location(35.7454934611854, 51.37361526489258));
            polygon.FillColor = Color.Black;
            polygon.FillOpacity = 0.5f;
            polygon.StrokeColor = Color.Gray;
            polygon.StrokeWeight = 1;
            map.Polygons.Add(polygon);

            return map;
        }
    }
}