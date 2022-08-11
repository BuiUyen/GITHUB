using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Medibox.Integration.HassIO.Model
{
    [DataContract(Namespace = "")]
    public class States_Get_In
    {
        [DataMember]
        public String entity_id { get; set; }
    }

    [DataContract(Namespace = "")]
    public class States_Get_Out
    {
        [DataMember]
        public String entity_id { get; set; }

        [DataMember]
        public String state { get; set; }
    }
}
