using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SLSOCserver
{
    [DataContract]
    public class Timetablesc
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public string Time { get; set; }
        [DataMember]
        public string Batch { get; set; }
        [DataMember]
        public string Modcode { get; set; }
        [DataMember]
        public string Lecname { get; set; }
        [DataMember]
        public string Lechall { get; set; }
        [DataMember]
        public string Lab { get; set; }
    }
}
