using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;
using Gmap.net.locator;
using Gmap.net.locator.geocoding_classes;
using GoogleMapsApi;

namespace Gmap.net
{
    public class Locator
    {
        private const string BaseUrl = "http://maps.googleapis.com/maps/api/";
        const string GeocodeAddress = BaseUrl+"geocode/json?{0}";
        private const string PlaceAPIAddress = BaseUrl + "place";
        const string PlaceNearAPIAddress = PlaceAPIAddress + "/nearbysearch/json?{0}";
        const string PlaceDetailsAddress = PlaceAPIAddress + "/details/json?{0}";

        ComponentFiltering componentFiltering { get; set; }
        private string apiKey = "";
        public Locator()
        {
            componentFiltering=new ComponentFiltering();
        }
        public Locator(string APIKey)
        {
            apiKey = APIKey;
            componentFiltering = new ComponentFiltering();
        }
        public GeoCoding GeoCoding(string address)
        {
            try
            {
                string locatorAddress = GeocodeAddress;
                address = address.Replace(" ", "+");
                QueryStringParametersList paramsList=new QueryStringParametersList();
                paramsList.Add("address",address);
                string filters = componentFiltering.ToString();
                if(filters!=string.Empty)
                    paramsList.Add("components",filters);

           
            paramsList.Add("sensor", "false");
                if (apiKey.Trim().Length > 0)
                {
                    paramsList.Add("key", apiKey);
                }
            string url = string.Format(locatorAddress, paramsList.GetQueryStringPostfix());
            return Serialization(url);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public GeoCoding ReversGeoCoding(Location location, ReverseGeocodingParameters paramsList)
        {
            return reverseGeoCoding("latlng", location.ToString(),paramsList);
        }
        public GeoCoding ReversGeoCoding(string PlaceId, ReverseGeocodingParameters paramsList)
        {
            return reverseGeoCoding("place_id", PlaceId,paramsList);
        }

        private GeoCoding reverseGeoCoding(string key, string value,ReverseGeocodingParameters paramsList)
        {
            try
            {

            QueryStringParametersList parametersList =new QueryStringParametersList();
            parametersList.Add(key,value);
            if(apiKey.Trim().Length>0) parametersList.Add("key",apiKey);
            if (paramsList != null)
            {
                if(paramsList.Lanuage.Trim()=="") parametersList.Add("language",paramsList.Lanuage);
                if (paramsList.LocationType != LocationType.None) parametersList.Add("location_type", paramsList.LocationType.ToString().ToUpper());
                if (paramsList.ResultType != ResultType.None) parametersList.Add("result_type", paramsList.ResultType.ToString().ToLower());
            }
            string url = string.Format(GeocodeAddress,parametersList.GetQueryStringPostfix());

                return Serialization(url);
            }
            catch (Exception)
            {
                return null;
            } 
        }

        
        public GeoCoding SearchNearPlaces(PlaceQueryParams queryParams)
        {
            try
            {
            QueryStringParametersList parametersList =new QueryStringParametersList();

            if(apiKey.Trim().Length>0)
                parametersList.Add("key",apiKey);
            else
            {
                throw  new Exception("API Key Is Required.");
            }
            if (queryParams == null)
            {
                throw new Exception("PlaceQueryParams must not be null");
            }
            if(queryParams.Location==null)
                throw new Exception("Location (latlng) must not be null");
            if(!queryParams.Radius.HasValue && queryParams.RankBy!=Ranks.Distance)
                throw new Exception("Note that radius must not be included if rankby=distance.for rest of mode you should define raduis value");

            parametersList.Add("location",queryParams.Location.ToString());
            if(queryParams.RankBy!=Ranks.Distance)
                parametersList.Add("radius",queryParams.radius.ToString());

            bool reqire = false;

            if (!string.IsNullOrWhiteSpace(queryParams.Keyword))
            {
                parametersList.Add("keyword", queryParams.Keyword);
                reqire = true;
            }
              

            if (!string.IsNullOrWhiteSpace(queryParams.Name))
            { 
                parametersList.Add("name", queryParams.Keyword);
                reqire = true;
            }

            if (queryParams.PlaceTypesList.Size > 0)
            { 
                parametersList.Add("types", queryParams.PlaceTypesList.GetQueryStringPostfix());
                reqire = true;
            }

            if (queryParams.RankBy == Ranks.Distance && !reqire)
            {
                throw new Exception("When distance is specified, one or more of keyword, name, or types is required.");

            }
            if (!string.IsNullOrWhiteSpace(queryParams.Language))
                parametersList.Add("language", queryParams.Language);

            if (queryParams.MinPrice < queryParams.MaxPrice)
            {
                if ((queryParams.MinPrice > 0 && queryParams.MinPrice < 5) &&
                    (queryParams.MaxPrice > 0 && queryParams.MaxPrice < 5))
                {
                    parametersList.Add("minprice",queryParams.MinPrice.ToString());
                    parametersList.Add("maxprice", queryParams.MaxPrice.ToString());
                }
            }

            if (!string.IsNullOrWhiteSpace(queryParams.PageToken))
                parametersList.Add("pagetoken", queryParams.PageToken);

            string url = string.Format(PlaceNearAPIAddress, parametersList.GetQueryStringPostfix());
            if (queryParams.Zagatselected)
                url += "&zagatselected";

            return Serialization(url);
            }
            catch (Exception)
            {
                return null;
            } 
        }

        public GeoCoding SearchNearPlaces(string query, PlaceQueryParams queryParams)
        {
            try
            {
                QueryStringParametersList parametersList = new QueryStringParametersList();

                if (!string.IsNullOrWhiteSpace(apiKey))
                    parametersList.Add("key", apiKey);
                else
                {
                    throw new Exception("API Key Is Required.");
                }

                if (!string.IsNullOrWhiteSpace(query))
                    parametersList.Add("query", query);
                else
                {
                    throw new Exception("Query Is Not be NULL.");
                }


                if (queryParams != null)
                {

                    if (queryParams.Location != null && !queryParams.radius.HasValue)
                        throw new Exception(
                            " If you specify a location parameter, you must also specify a radius parameter.");

                    parametersList.Add("location", queryParams.Location.ToString());
                    parametersList.Add("radius", queryParams.radius.ToString());

                    if (queryParams.PlaceTypesList.Size > 0)
                    {
                        parametersList.Add("types", queryParams.PlaceTypesList.GetQueryStringPostfix());
                    }


                    if (!string.IsNullOrWhiteSpace(queryParams.Language))
                        parametersList.Add("language", queryParams.Language);

                    if (queryParams.MinPrice < queryParams.MaxPrice)
                    {
                        if ((queryParams.MinPrice > 0 && queryParams.MinPrice < 5) &&
                            (queryParams.MaxPrice > 0 && queryParams.MaxPrice < 5))
                        {
                            parametersList.Add("minprice", queryParams.MinPrice.ToString());
                            parametersList.Add("maxprice", queryParams.MaxPrice.ToString());
                        }
                    }
                }

               string url = string.Format(PlaceNearAPIAddress, parametersList.GetQueryStringPostfix());
                if (queryParams.Zagatselected)
                    url += "&zagatselected";

                return Serialization(url);
            }
            catch (Exception)
            {
                return null;
            } 
        }


        public GeoCoding PlaceDetails(string PlaceId, string language = "")
        {
            QueryStringParametersList parametersList = new QueryStringParametersList();

            if (string.IsNullOrEmpty(apiKey))
                parametersList.Add("key", apiKey);
            else
            {
                throw new Exception("API Key Is Required.");
            }
            if (string.IsNullOrEmpty(language))
            {
                parametersList.Add("language", language);
            }
        }
        private GeoCoding Serialization(string Url)
        {
            var content = new WebClient { Encoding = Encoding.UTF8 }.DownloadString(Url);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GeoCoding));
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(content));
            GeoCoding geo = serializer.ReadObject(ms) as GeoCoding;

            return geo;
        }
    
    }

}
