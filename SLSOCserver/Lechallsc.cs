using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SLSOCserver
{
    [DataContract]
    public class Lechallsc
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Lechallcode { get; set; }
        [DataMember]
        public string Numstu { get; set; }
    }
}
