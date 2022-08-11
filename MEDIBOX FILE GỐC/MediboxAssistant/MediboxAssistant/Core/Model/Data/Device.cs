using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    [Serializable()]
    public class Device
    {
        public int DeviceID { get; set; }
        public string DeviceCode { get; set; }
        public string DeviceName { get; set; }
        public string DeviceName_Short { get; set; }
        public int RoomID { get; set; }
        public int HomeID { get; set; }
        public int UserID { get; set; }

        public string Hass_Entity_ID { get; set; }
        public int DM_Hass_DeviceTypeID { get; set; }

        //------------------------------------------------------------

        //Ref
        public bool isSelected { get; set; }
        public Home mHome { get; set; }
        public Room mRoom { get; set; }
        public User mUser { get; set; }
        public Device mParent { get; set; }
        public IList<Device> mListSubData { get; set; }
        public int Current_DM_Intent_TypeID { get; set; }
        public int Current_DM_Entity_TypeID { get; set; }
    }
}
