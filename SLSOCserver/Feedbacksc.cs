using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SLSOCserver
{
    [DataContract]
    public class Feedbacksc
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Faculty { get; set; }
        [DataMember]
        public string Modcode { get; set; }
        [DataMember]
        public string Feedback { get; set; }
    }
}
