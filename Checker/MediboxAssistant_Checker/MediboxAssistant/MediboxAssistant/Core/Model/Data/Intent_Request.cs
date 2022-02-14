using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    [Serializable()]
    public class Intent_Request
    {        
        public int Intent_RequestID { get; set; }
        public int IntentID { get; set; }
        public int DM_Intent_TypeID { get; set; }
        public int DM_Entity_TypeID { get; set; }
        public int Current_DM_Intent_TypeID { get; set; }
        public int Current_DM_Entity_TypeID { get; set; }
        public string Data { get; set; }        

        //Ref
        public IList<Intent_Request> mListSubData { get; set; }
        public Intent_Request mParent { get; set; }
        public IList<EntityParam> mListParam { get; set; }
        public Device mDevice { get; set; }

        public Intent_Request()
        {
            mListParam = new List<EntityParam>();
        }
    }
}
