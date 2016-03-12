namespace Gmap.net
{
    public partial class GoogleMapApi
    {
        //const
        //== js file
        const string JsFileAddress = "<script src=\"http://maps.googleapis.com/maps/api/js\"></script>";
        const string JsFileAddresswithKey = "<script src=\"http://maps.googleapis.com/maps/api/js?key={0}\"></script>";


        //== common
        const string Csetgeo = "new google.maps.LatLng({0},{1})";

        //=====options
        const string COptions = "var myOptions = {{\r\n{0}\r\n}};";

        const string CGeoPoint = "center: new google.maps.LatLng({0}, {1}),\r\n";

        const string CZoomOption = "zoom:{0},";

        const string CMapTypeId = " mapTypeId: google.maps.MapTypeId.{0},\r\n";

        const string CMapTypeOptions=" mapTypeControlOptions:{{style: google.maps.MapTypeControlStyle.{0},\r\n" +
                    "poistion: google.maps.ControlPosition.{1},\r\n mapTypeIds: [{2}] }},";

        const string CNavigationOptions= " navigationControlOptions:{{style: google.maps.NavigationControlStyle.{0},\r\n" +
                    "poistion: google.maps.ControlPosition.{1} }},";

        const string CScaleOptions = " scaleControlOptions:{{style: google.maps.ScaleControlStyle.{0},\r\n" +
                    "poistion: google.maps.ControlPosition.{1} }},";



        //==functions
        const string CDivControl = "var map=new google.maps.Map(document.getElementById(\"{0}\"),myOptions);";
        const string CInitialFunc = "function initialize() {{\r\n{0}\r\n}}\r\ngoogle.maps.event.addDomListener(window, 'load', initialize);";


        //==marker
        const string CmarkerOptions = "var {0}=new google.maps.Marker({{\r\n{1}\r\n}});\r\n{0}.setMap(map);";
        const string CMarkerPoisition = "position:new google.maps.LatLng({0}, {1})";
        const string CMarkerTitle = "title:'{0}',";
        const string CMarkerIcon = "icon:'{0}',";
        const string CMarkerAnim = "animation:google.maps.Animation.{0},";


        //==polyline & polygon
        const string CPolylineOptions = "var {0} = new google.maps.Polyline({{\r\n{1}\r\n}});\r\n {0}.setMap(map);";
        const string CStrokeColor = "strokeColor:\"{0}\",\r\n";
        const string CStrokeOpacity = "strokeOpacity:{0},\r\n";
        const string CEditable = "editable:{0},\r\n";
        const string CStrokeWeight = "strokeWeight:{0},\r\n";
        const string CMakepath = "var mypath{0} = {1};";
        const string CPath = "path:mypath{0}";


        //==polygon
        const string CFillcolor = "fillColor:\"{0}\",\r\n";
        const string CFillOpacity = "fillOpacity:{0},\r\n";
        const string CPolygonOptions = "var {0} = new google.maps.Polygon({{\r\n{1}\r\n}});\r\n {0}.setMap(map);";
        const string CMakepolygon = "var mypolygon{0} = {1};";
        const string CPolygon = "path:mypolygon{0}";


        //circle
        const string CRadius = "radius:{0},";
        const string CCircleOptions = "var {0} = new google.maps.Circle({{\r\n{1}\r\n}});\r\n {0}.setMap(map);";



        //InfoWindow window
        const string CInfoWindow = "var {0} = new google.maps.InfoWindow({{{1}}});\r\n {0}.open(map,{2});";
        const string CInfoContent = "content:\"{0}\"";


        //rectangle
        const string CBound = " bounds: new google.maps.LatLngBounds(\r\n{0}),\r\n";
        const string CRect = "var rectangle{0} = new google.maps.Rectangle({{\r\n {1} \r\n map:map}});";


        //zoom control
        const string CZoomOptions = "zoomControlOptions:{{style: google.maps.ZoomControlStyle.{0},\r\n" +
                    "position: google.maps.ControlPosition.{1} }},";


        //Rotate control
        const string CRotateOptions = "rotateControlOptions:{{\r\n" +
                    "position: google.maps.ControlPosition.{0} }},";

    }
}
