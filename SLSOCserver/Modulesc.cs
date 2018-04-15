using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SLSOCserver
{
    [DataContract]
    public class Modulesc
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Modcode { get; set; }
        [DataMember]
        public string Modname { get; set; }
        [DataMember]
        public string Lecname { get; set; }
    }
}
