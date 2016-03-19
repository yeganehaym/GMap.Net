# GMap.Net
a .Net libraray for creating responsive google map on web app

![GMap.Net](http://uupload.ir/files/zbme_gmaps.png "this is the result")


GMap.Net is a library for creating responsive google map on web app specially mvc

you dont need write so much js code and waste your time with it. js is sensitive and doesn't have good intellisense, so you should take care of what you really write and knows google api as well

but here you can do some tasks by csharp code for example

please look at blew code and see how much it is easy


```C#
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
```

and then in your view

```C#
@section javascript
{
    @{
        var map = new MiladTower().TestMarker();
        @map.ShowMapForMvc("mapdiv")

    }
   
}
<br/><br/>
<div id="mapdiv" style="width:600px;height:600px;"></div>
```

and it wil be what you see

![GMap.Net](http://uupload.ir/files/g92g_untitled.png "this is the result")

and this is js code produced

```javascript
    
<script src="http://maps.googleapis.com/maps/api/js"></script>
<script>function initialize() {
var myOptions = {
center: new google.maps.LatLng(35.7448416, 51.3753212),

zoom:17,
 mapTypeId: google.maps.MapTypeId.ROADMAP,

 navigationControl: true,

 navigationControlOptions:{style: google.maps.NavigationControlStyle.DEFAULT,
poistion: google.maps.ControlPosition.TOP_RIGHT }, scaleControl: true,

 scaleControlOptions:{style: google.maps.ScaleControlStyle.SMALL,
poistion: google.maps.ControlPosition.BOTTOM_LEFT },
draggableCursor:'default',

draggingCursor:'default',

overviewMapControl:true,



disableDoubleClickZoom:false,

scrollwheel:true,

draggable:true,

pancontrol:false,

backgroundColor:"#00FFFF",
zoomControl:true,

zoomControlOptions:{style: google.maps.ZoomControlStyle.SMALL,
position: google.maps.ControlPosition.TOP_LEFT },

disableDefaultUI:false,

keyboardShortcuts:false,

rotateControl:false,

streetViewControl:false

};var map=new google.maps.Map(document.getElementById("mapdiv"),myOptions);
var mymarker1=new google.maps.Marker({
position:new google.maps.LatLng(35.7448416, 51.3753212)
});
mymarker1.setMap(map);
var iw1 = new google.maps.InfoWindow({content:"<b>Milad Tower</b><i>in Tehran</i><br/>Milad Tower is the highest tower in iran,many people and tourists visit it each year, but it's so expensive that i cant afford it as iranian citizen<br/>please see more info at  <a href='https://en.wikipedia.org/wiki/Milad_Tower'><img width='16px' height='16px' src='https://en.wikipedia.org/favicon.ico'/>wikipedia</a>"});
 iw1.open(map,mymarker1);


var mypath1 = [new google.maps.LatLng(35.7445704356904,51.3739156723022),new google.maps.LatLng(35.7447097609793,51.3735938072205),new google.maps.LatLng(35.7443788630201,51.3733792304993)];
var poly1 = new google.maps.Polyline({
editable:false,
strokeWeight:2,
strokeOpacity:1,
strokeColor:"#0000FF",
path:mypath1
});
 poly1.setMap(map);


var mypolygon1 = [new google.maps.LatLng(35.7464948446651,51.3746559619904),new google.maps.LatLng(35.7463555225006,51.3728320598602),new google.maps.LatLng(35.7459810929752,51.3726818561554),new google.maps.LatLng(35.7454934611854,51.3736152648926),new google.maps.LatLng(35.7464948446651,51.3746559619904)];
var poly2 = new google.maps.Polygon({
editable:false,
strokeWeight:1,
strokeOpacity:1,
strokeColor:"#808080",
fillColor:"#000000",
fillOpacity:0.5,
path:mypolygon1
});
 poly2.setMap(map);
var mymarker2 = new google.maps.Circle({
center: new google.maps.LatLng(35.7448416, 51.3753212),
radius:30,editable:true,
strokeWeight:3,
strokeOpacity:0.8,
strokeColor:"#FF0000",
fillColor:"#008000",
fillOpacity:0.6,

});
 mymarker2.setMap(map);

var rectanglerect1 = new google.maps.Rectangle({
 editable:false,
strokeWeight:0,
strokeOpacity:1,
strokeColor:"#000000",
fillColor:"#000000",
 bounds: new google.maps.LatLngBounds(
new google.maps.LatLng(35.7472872348381,51.3755035400391),new google.maps.LatLng(35.7466864122431,51.3767158985138)),
fillOpacity:0.4,
 
 map:map});

}
google.maps.event.addDomListener(window, 'load', initialize);</script>
```
**are you looking for a way to minify js code?**

minified property is exist. set it to **true**

**do you think an external js file is better?**

use calljs() method in view to call googl api and use GiveJustJs() method in an action method and return your action method as text/javascript content and at last put action method link in view after CallJs()

**are you using webform?**

we have a method is called showmap() for webform but you shold know webform is obselete
