using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SLSOCserver
{
    [DataContract]
    public class Labsc
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Labcode { get; set; }
        [DataMember]
        public string Numstu { get; set; }
    }
}
