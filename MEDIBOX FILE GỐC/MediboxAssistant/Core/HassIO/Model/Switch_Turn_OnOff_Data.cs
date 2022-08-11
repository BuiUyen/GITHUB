using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Medibox.HassIO.Model
{
    [DataContract(Namespace = "")]
    public class Switch_Turn_OnOff_In
    {
        [DataMember]
        public String entity_id { get; set; }
    }

    [DataContract(Namespace = "")]
    public class Switch_Turn_OnOff_Out
    {

    }
}
