namespace Gmap.net.Overlays
{
    /// <summary>
    /// common is a common class for all overlays have common staff like id
    /// </summary>
    public abstract class Common
    {
        public Common(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
