using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    [Serializable()]
    public class Intent_Response
    {
        public int Intent_ResponseID { get; set; }
        public int IntentID { get; set; }
        public int DM_Intent_TypeID { get; set; }
        public int DM_Entity_TypeID { get; set; }
        public string Data { get; set; }

        //Ref
        public IList<Intent_Response> mListSubData { get; set; }
        public Intent_Response mParent { get; set; }
    }
}
