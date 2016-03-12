using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gmap.net.locator.geocoding_classes
{
    [DataContract]
    public class GeoCoding
    {
        [DataMember(Name = "status")]
        internal string GeoStatus
        {
            get
            {
                return Status.ToString();
            }
            set
            {
                Status = (Status)Enum.Parse(typeof(Status), value);
            }
        }
        public Status Status { get; set; }

        [DataMember(Name = "results")]
        public IEnumerable<Result> Results { get; set; }

        [DataMember(Name = "error_message")]
        public string ErrorMessage { get; set; }
    }
}
