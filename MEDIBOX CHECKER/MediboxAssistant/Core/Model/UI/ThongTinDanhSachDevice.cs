using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sanita.Utility;

namespace Medibox.Model
{
    [Serializable()]
    public class ThongTinDanhSachDevice
    {
        public enum TYPE
        {
            ROOT = 0,

            GROUP = 1,
            SUB_GROUP = 2,
        }

        public static int ThongTinDanhSachDeviceID_Index { get; set; }

        public int ThongTinDanhSachDeviceID { get; set; }
        public int DM_Device_GroupID { get; set; }
        public int DM_Device_SubGroupID { get; set; }
        public int HomeID { get; set; }
        public int RoomID { get; set; }
        public int ThongTinDanhSachDeviceType { get; set; }
        public String ThongTinDanhSachDeviceName { get; set; }
        public IList<Device> mListData { get; set; }

        //Constructor
        public ThongTinDanhSachDevice()
        {
            ThongTinDanhSachDeviceID = ThongTinDanhSachDeviceID_Index++;
        }

        //Ref
        public IList<ThongTinDanhSachDevice> mListSubData { get; set; }
        public bool isSelected { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is ThongTinDanhSachDevice)
            {
                ThongTinDanhSachDevice data = obj as ThongTinDanhSachDevice;
                if (data.ThongTinDanhSachDeviceID == ThongTinDanhSachDeviceID)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}

