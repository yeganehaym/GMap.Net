namespace Gmap.net.Overlays
{
    public class InfoWindow:Common
    {
        public InfoWindow(string id):base(id)
        {
        }
      
        /// <summary>
        /// you can set text or even html content to show anything you want to user
        /// </summary>
        public string Content { get; set; }
    }
}
