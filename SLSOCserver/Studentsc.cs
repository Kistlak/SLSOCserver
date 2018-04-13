using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SLSOCserver
{
    [DataContract]
    public class Studentsc
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Fname { get; set; }
        [DataMember]
        public string Lname { get; set; }
        [DataMember]
        public string Adone { get; set; }
        [DataMember]
        public string Adtwo { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public string Byear { get; set; }
        [DataMember]
        public string Nic { get; set; }
        [DataMember]
        public string Faculty { get; set; }
        [DataMember]
        public string Jdate { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
