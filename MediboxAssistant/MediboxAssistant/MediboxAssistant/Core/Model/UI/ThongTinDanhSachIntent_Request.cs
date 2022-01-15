using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sanita.Utility;

namespace Medibox.Model
{
    [Serializable()]
    public class ThongTinDanhSachIntent_Request
    {
        public enum TYPE
        {
            ROOT = 0,

            GROUP = 1,
            SUB_GROUP = 2,
        }

        public static int ThongTinDanhSachIntent_RequestID_Index { get; set; }

        public int ThongTinDanhSachIntent_RequestID { get; set; }
        public int DM_Intent_Request_GroupID { get; set; }
        public int DM_Intent_Request_SubGroupID { get; set; }
        public int DM_Intent_TypeID { get; set; }
        public int DM_Entity_TypeID { get; set; }
        public int ThongTinDanhSachIntent_RequestType { get; set; }
        public String ThongTinDanhSachIntent_RequestName { get; set; }
        public IList<Intent_Request> mListData { get; set; }

        //Constructor
        public ThongTinDanhSachIntent_Request()
        {
            ThongTinDanhSachIntent_RequestID = ThongTinDanhSachIntent_RequestID_Index++;
        }

        //Ref
        public IList<ThongTinDanhSachIntent_Request> mListSubData { get; set; }
        public bool isSelected { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is ThongTinDanhSachIntent_Request)
            {
                ThongTinDanhSachIntent_Request data = obj as ThongTinDanhSachIntent_Request;
                if (data.ThongTinDanhSachIntent_RequestID == ThongTinDanhSachIntent_RequestID)
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

