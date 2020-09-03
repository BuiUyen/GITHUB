using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    [Serializable()]
    public class Intent
    {
        public int IntentID { get; set; }        
        public string IntentName { get; set; }
        public int DM_Intent_TypeID { get; set; }

        //Ref
        public IList<Intent> mListSubData { get; set; }
        public int STT { get; set; }
    }
}
