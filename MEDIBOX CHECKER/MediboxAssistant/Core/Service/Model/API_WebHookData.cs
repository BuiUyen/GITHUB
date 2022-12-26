using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Medibox.Service.Model
{
    [DataContract(Namespace = "")]
    public class API_WebHookData_In
    {
        [DataMember]
        public String responseId { get; set; }

        [DataMember]
        public String session { get; set; }

        [DataMember]
        public API_WebHookData_In_queryResult queryResult { get; set; }

        public API_WebHookData_In()
        {

        }
    }

    [DataContract(Namespace = "")]
    public class API_WebHookData_In_queryResult
    {
        [DataMember]
        public String queryText { get; set; }

        [DataMember]
        public double speechRecognitionConfidence { get; set; }

        [DataMember]
        public String action { get; set; }
    }

    [DataContract(Namespace = "")]
    public class API_WebHookData_Out
    {
        [DataMember]
        public String fulfillmentText { get; set; }

        [DataMember]
        public String source { get; set; }
    }
}
