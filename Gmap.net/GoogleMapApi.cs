using System;
using System.Web.Mvc;
using Gmap.net.Enums;
using Gmap.net.Overlays;
using Microsoft.Ajax.Utilities;

namespace Gmap.net
{

    public partial class GoogleMapApi
    {

        // constructor are in public methods class file


        private string Jsfile()
        {
            string code;
            //define js file Address(a constant)
            if (_apiKey.Trim() != "")
            {
                code = string.Format(JsFileAddresswithKey, _apiKey);
            }
            else
                code = JsFileAddress;
            return code;
        }

        /// <summary>
        /// this is a good method if you are using asp.net webform yet, if you are using mvc please use ShowMapForMVC method because of html encoded
        /// </summary>
        /// <param name="divname">give it a div tag to draw map on it</param>
        /// <returns>javascript code</returns>
        public string ShowMap(string divname)
        {
            string code= Jsfile();

            code += Environment.NewLine;
            code += $"<script>{CreateMap(divname)}</script>";
            return code;
        }

        /// <summary>
        /// if you using mvc tech use this method , html encoded will be auto handle
        /// </summary>
        /// <param name="divname">give it a div tag to draw map on it</param>
        /// <returns>javascript code</returns>
        public MvcHtmlString ShowMapForMvc(string divname)
        {
            return MvcHtmlString.Create(ShowMap(divname));
        }

        public MvcHtmlString CallJs()
        {
            
            return MvcHtmlString.Create(Jsfile());
        }

        public MvcHtmlString GiveJustJs(string divName)
        {
            return MvcHtmlString.Create(CreateMap(divName));
        }

        /// <summary>
        /// define level of user abilities to control map by controls
        /// like what map types is avaible to user can chnage to them
        /// </summary>
        /// <returns></returns>
        private string GetmapTypeControls()
        {
            if (MapOptions == null)
                return "";
            string controls = "";

            controls += " mapTypeControl: " + _mapTypeControl.ToString().ToLower() + ",\r\n";

            if (_mapTypeControl && MapOptions != null)
            {
                string maptypes;
                if (MapOptions.Maptypes == null || MapOptions.Maptypes.Count == 0)
                    return controls;

                    maptypes = "[";
                    int i = 0;
                    foreach (MapTypes item in MapOptions.Maptypes)
                    {
                        if (i > 0)
                            maptypes += ",";
                        i++;
                        maptypes += item.ToString();
                    }
                    maptypes = "]";

               
                controls += Environment.NewLine + string.Format(CMapTypeOptions, MapOptions.Style, MapOptions.Position, maptypes);

            }
            return controls;
        }

        /// <summary>
        /// define controls to user can navigate on map,
        /// </summary>
        /// <returns></returns>
        private string GetnavigationControls()
        {
            if (ControlOptions == null)
                return "";
            string controls = "";
            controls += " navigationControl: " + _navigationControl.ToString().ToLower() + ",\r\n";
            if (!_navigationControl && ControlOptions == null)
                return controls;

            controls += Environment.NewLine + string.Format(CNavigationOptions, ControlOptions.Style, ControlOptions.Position);
            return controls;
        }
        
        /// <summary>
        /// you can show scale bar on map, set its options
        /// </summary>
        /// <returns></returns>
        private string GetScaleControls()
        {
            if (ScaleOptions == null)
                return "";

            string controls = "";
            controls += " scaleControl: " + _scaleControl.ToString().ToLower() + ",\r\n";
            if (!_navigationControl && ControlOptions == null)
                return controls;

            controls += Environment.NewLine + string.Format(CScaleOptions, ScaleOptions.Style, ScaleOptions.Position);
            return controls;
        }

        /// <summary>
        /// how will be cursor icon when it is dragging on map
        /// </summary>
        /// <returns></returns>
        private string GetDragging()
        {
            return GetCusror("draggableCursor", _draggingCursor.ToString(), DraggingCustomCursorAddress);
        }

        /// <summary>
        /// how will be cursor icon when it is on map
        /// </summary>
        /// <returns></returns>

        private string GetDraggable()
        {
            return GetCusror("draggingCursor", _draggableCursor.ToString(), DraggableCustomCursorAddress);
        }

        /// <summary>
        /// a repetive code when set a cursor icon
        /// </summary>
        /// <param name="propertyName">cursor icon property</param>
        /// <param name="cursorName">cursor user set</param>
        /// <param name="customCursor">custom Cursor</param>
        /// <returns></returns>
        private string GetCusror(string propertyName,string cursorName,string customCursor)
        {
            string cursor = "'{0}'";
            if (_draggingCursor == Cursor.Default)
            {
                cursor = string.Format(cursor, cursorName.ToLower());
            }
            else if (_draggingCursor == Cursor.Custom)
            {
                cursor = "'url({0}),auto;'";
                cursor = string.Format(cursor,customCursor );
            }
            else
            {
                cursor = string.Format(cursor, cursorName.Replace("_", "-"));
            }

            return Environment.NewLine + propertyName+":" + cursor + "," + Environment.NewLine;
        }

        private string GetOverviewMap()
        {
            string options = "overviewMapControlOptions: {{\r\n {0} \r\n}},";
            if (!_overviewMapControl || OverviewOptions == null)
            return "";

                string opened = "opened:{0},";
                //string position = "position:google.maps.ControlPosition.{0}";
                opened = string.Format(opened, OverviewOptions.Opened);
                // position = string.Format(position, OverviewOptions.position);

                options = string.Format(options, opened);
         

            return options;
        }

        /// <summary>
        /// null validating must perform before call this func
        /// </summary>
        /// <returns></returns>
        private string GetZoomOptions()
        {
            if (ZoomOptions == null)
                return "";

            return string.Format(CZoomOptions, ZoomOptions.ZoomStyle, ZoomOptions.Position);
        }

        /// <summary>
        /// null validating must perform before call this func
        /// </summary>
        /// <returns></returns>
        private string GetRotationOptions()
        {
            if (RotateControlsOptions == null)
                return "";

            return string.Format(CRotateOptions, RotateControlsOptions.Position);
        }


        /// <summary>
        /// define map options and what and how to controls show
        /// </summary>
        /// <returns></returns>
        private string SetControlsAndOptions()
        {
            string controls;
            controls = GetmapTypeControls();
            controls += GetnavigationControls();
            controls += GetScaleControls();
            controls += GetDragging();
            controls += GetDraggable();

            controls += Environment.NewLine + "overviewMapControl:" + _overviewMapControl.ToString().ToLower() + "," + Environment.NewLine;
            controls += Environment.NewLine + GetOverviewMap() + Environment.NewLine;

            controls += Environment.NewLine + "disableDoubleClickZoom:" + _disableDoubleClickZoom.ToString().ToLower() + "," + Environment.NewLine;
            controls += Environment.NewLine + "scrollwheel:" + _scrollwheel.ToString().ToLower() + "," + Environment.NewLine;
            controls += Environment.NewLine + "draggable:" + draggable.ToString().ToLower() + "," + Environment.NewLine;

            controls += Environment.NewLine + "pancontrol:" + _panControl.ToString().ToLower() + "," + Environment.NewLine;
            controls += Environment.NewLine + "backgroundColor:\"" + HexConverter(_backgroundColor) + "\",";


            controls += Environment.NewLine + "zoomControl:" + _zoomControl.ToString().ToLower() + "," + Environment.NewLine;

            if (_zoomControl && ZoomOptions != null)
                controls += Environment.NewLine + GetZoomOptions() + Environment.NewLine;



            controls += Environment.NewLine + "disableDefaultUI:" + _disableDefaultUi.ToString().ToLower() + "," + Environment.NewLine;
            controls += Environment.NewLine + "keyboardShortcuts:" + _keyboardShortcuts.ToString().ToLower() + "," + Environment.NewLine;

            controls += Environment.NewLine + "rotateControl:" + _rotateControl.ToString().ToLower() + "," + Environment.NewLine;

            if (_rotateControl && RotateControlsOptions != null)
                controls += Environment.NewLine + GetRotationOptions() + Environment.NewLine;




            controls += Environment.NewLine + "streetViewControl:" + _streetViewControl.ToString().ToLower() + Environment.NewLine;

            return controls;

        }


        private string SetMarkers()
        {
            if (Markers.Count == 0)
                return "";

            string markers = Environment.NewLine;
            foreach (Marker marker in Markers)
            {
               if(marker.MarkerPoint==null)
                    throw  new Exception("one of your marker has not any point");

                string markerpoint = string.Format(CMarkerPoisition, marker.MarkerPoint.Latitude, marker.MarkerPoint.Longitude);
                string markertitle = string.Format(CMarkerTitle, marker.Title);
                string markericon = string.Format(CMarkerIcon, marker.Icon);
                string markeranim = string.Format(CMarkerAnim, marker.Animation);

                string sum = "";

                if (marker.Title.Trim() != "")
                    sum += markertitle + Environment.NewLine;
                if (marker.Icon.Trim() != "")
                    sum += markericon + Environment.NewLine;

                if (marker.Animation != MarkerAnimation.None)
                    sum += markeranim + Environment.NewLine;

                sum += markerpoint;
                string markerOptions = string.Format(CmarkerOptions, marker.Id, sum);
                markers +=  markerOptions + Environment.NewLine;

                if (marker.InfoWindow != null)
                {
                    string message = string.Format(CInfoContent, marker.InfoWindow.Content.Replace("\"","'"));
                    string window = string.Format(CInfoWindow, marker.InfoWindow.Id, message, marker.Id);
                    markers += window + Environment.NewLine;
                }
            }
            return markers;
        }

        private string SetPolylines()
        {
            if (Polylines.Count == 0)
                return "";

            string polylines = Environment.NewLine;
            int i = 0;

            foreach (Polyline poly in Polylines)
            {
                //set locations
                i++;
                string locations = "[";
                if (poly.Points == null || poly.Points.Count == 0)
                    throw new Exception($"Polylines[{i}]:Points Property Property must not be empty or null");

                for (int j = 0; j < poly.Points.Count; j++)
                {
                    if (j > 0)
                    {
                        locations += ",";
                    }
                    locations += string.Format(Csetgeo, poly.Points[j].Latitude, poly.Points[j].Longitude);
                }
                    
                locations += "]";
                string varpath = string.Format(CMakepath, i, locations);
                string path = string.Format(CPath, i);

                //set options
                string strokweight = string.Format(CStrokeWeight, poly.StrokeWeight);
                string strokopacity = string.Format(CStrokeOpacity, poly.StrokeOpacity.ToString("R"));
                string strokcolor = string.Format(CStrokeColor, HexConverter(poly.StrokeColor));
                string editable = string.Format(CEditable, poly.Editable.ToString().ToLower());


                string polyoptions = string.Format(CPolylineOptions, poly.Id, editable + strokweight + strokopacity + strokcolor + path);
                polylines += Environment.NewLine + varpath + Environment.NewLine + polyoptions + Environment.NewLine;
            }
            return polylines;
        }

        private string SetPolygons()
        {
            if (Polygons.Count== 0)
                return "";

                string polygons = Environment.NewLine;
                int i = 0;
                foreach (Polygon poly in Polygons)
                {
                    i++;
                    string locations = "[";
                    if (poly.Points == null || poly.Points.Count == 0)
                        throw new Exception($"Polygon[{i}]:Points Property Property must not be empty or null");

                        for (var j = 0; j < poly.Points.Count; j++)
                        {
                            if (j > 0)
                            {
                                locations += ",";
                            }
                            locations += string.Format(Csetgeo, poly.Points[j].Latitude, poly.Points[j].Longitude);
                        }
                //insert first point here to close polygon
                locations += "," + string.Format(Csetgeo, poly.Points[0].Latitude, poly.Points[0].Longitude);
                locations += "]";

                string varpath = string.Format(CMakepolygon, i, locations);
                string path = string.Format(CPolygon, i);

                //set options
                string strokweight = string.Format(CStrokeWeight, poly.StrokeWeight);
                    string strokopacity = string.Format(CStrokeOpacity, poly.StrokeOpacity.ToString("R"));
                    string strokcolor = string.Format(CStrokeColor, HexConverter(poly.StrokeColor));

                    string editable = string.Format(CEditable, poly.Editable.ToString().ToLower());
                    string fillopacity = string.Format(CFillOpacity, poly.FillOpacity.ToString("R"));
                    string fillcolor = string.Format(CFillcolor, HexConverter(poly.FillColor));

                    string polyoptions = string.Format(CPolygonOptions, poly.Id, editable + strokweight + strokopacity + strokcolor + fillcolor + fillopacity + path);
                    polygons += Environment.NewLine + varpath + Environment.NewLine + polyoptions + Environment.NewLine;
                }
            return polygons;
        }

        private string SetCircles()
        {
            if (Circles.Count == 0)
                return "";

            string circles = Environment.NewLine;
            foreach (CircleMarker circle in Circles)
            {
                if (circle.Point == null)
                    throw new Exception("CircleMarkers:Point Property Property must not be null");

                //location
                string centerpoint = string.Format(CGeoPoint, circle.Point.Latitude, circle.Point.Longitude);
                string radius = string.Format(CRadius, circle.Radius);


                //options
                string strokweight = string.Format(CStrokeWeight, circle.StrokeWeight);
                string strokopacity = string.Format(CStrokeOpacity, circle.StrokeOpacity.ToString("R"));
                string strokcolor = string.Format(CStrokeColor, HexConverter(circle.StrokeColor));

                string fillopacity = string.Format(CFillOpacity, circle.FillOpacity.ToString("R"));
                string fillcolor = string.Format(CFillcolor, HexConverter(circle.FillColor));
                string editable = string.Format(CEditable, circle.Editable.ToString().ToLower());



                circles = string.Format(CCircleOptions, circle.Id ,
                    centerpoint + radius + editable + strokweight + strokopacity + strokcolor + fillcolor + fillopacity);
                circles +=  Environment.NewLine;

            }
            return circles;
        }

        private string SetRects()
        {
            if (Rectangles == null || Rectangles.Count == 0)
                return "";

                string rects = Environment.NewLine;
                foreach (Rectangle rec in Rectangles)
                {
                    //locations
                    string point1 = string.Format(Csetgeo, rec.Points[0].Latitude, rec.Points[0].Longitude);
                    string point2 = string.Format(Csetgeo, rec.Points[1].Latitude, rec.Points[1].Longitude);
                    string bounds = string.Format(CBound, point1 + "," + point2);

                    //options
                    string strokweight = string.Format(CStrokeWeight, rec.StrokeWeight);
                    string strokopacity = string.Format(CStrokeOpacity, rec.StrokeOpacity.ToString("R"));
                    string strokcolor = string.Format(CStrokeColor, HexConverter(rec.StrokeColor));

                    string editable = string.Format(CEditable, rec.Editable.ToString().ToLower());
                    string fillopacity = string.Format(CFillOpacity, rec.FillOpacity.ToString("R"));
                    string fillcolor = string.Format(CFillcolor, HexConverter(rec.FillColor));

                    string rectoptions = string.Format(CRect, rec.Id, editable + strokweight + strokopacity + strokcolor + fillcolor + bounds + fillopacity);
                    rects += rectoptions + Environment.NewLine;
                }

            return rects;
        }

        //main method for draw map
        private string CreateMap(string divname)
        {
            //check location to be sure lat and lan is set
            if (_geoCoordinate == null)
                throw new Exception("Location must not be null");

            //set map center
            string center = string.Format(CGeoPoint, _geoCoordinate.Latitude, _geoCoordinate.Longitude) + Environment.NewLine;


            #region MapOptions&Controls
                string controls = SetControlsAndOptions();
                string zoomOnMap = string.Format(CZoomOption, _zoom) + Environment.NewLine;
                string mapType = string.Format(CMapTypeId, _mapType) + Environment.NewLine;
                string options = string.Format(COptions, center + zoomOnMap + mapType+controls);
            #endregion

            string subCodes = string.Format(CDivControl, divname);


            #region Overlays
                subCodes += SetMarkers();
                subCodes += SetPolylines();
                subCodes += SetPolygons();
                subCodes += SetCircles();
                subCodes += SetRects();
            #endregion 


            
            string code = string.Format(CInitialFunc, options + subCodes);

            //minifying
            if (Minified)
                code = Minify(code);

            return code;
        }

        private string Minify(string code)
        {
                var minifier = new Minifier();
                var codeSettings = new CodeSettings();
                codeSettings.MinifyCode = true;
                codeSettings.OutputMode = OutputMode.SingleLine;
                code = minifier.MinifyJavaScript(code, codeSettings);
            return code;

        }

        private String HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
  
    }
}
