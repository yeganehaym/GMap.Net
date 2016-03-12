using System.Runtime.Serialization;

namespace Gmap.net.locator.geocoding_classes
{
    [DataContract]
    public enum Status
    {
        /// <summary>
        /// Indicates that no errors occurred; the address was successfully parsed and at least one geocode was returned.
        /// </summary>
        [EnumMember]
        OK,

        /// <summary>
        /// Indicates that the geocode was successful but returned no results. This may occur if the geocode was passed a non-existent address or a latlng in a remote location.
        /// </summary>
        [EnumMember]
        ZERO_RESULTS,

        /// <summary>
        /// Indicates that you are over your quota.
        /// </summary>
        [EnumMember]
        OVER_QUERY_LIMIT,

        /// <summary>
        /// Indicates that your request was denied, generally because of lack of a sensor parameter.
        /// </summary>
        [EnumMember]
        REQUEST_DENIED,

        /// <summary>
        /// Generally indicates that the query (address or latlng) is missing.
        /// </summary>
        [EnumMember]
        INVALID_REQUEST
    }
}
