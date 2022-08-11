using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sanita.Utility;

namespace Medibox.Model
{
    [Serializable()]
    public class ThongTinDanhSachIntent_Response
    {
        public enum TYPE
        {
            ROOT = 0,

            GROUP = 1,
            SUB_GROUP = 2,
        }

        public static int ThongTinDanhSachIntent_ResponseID_Index { get; set; }

        public int ThongTinDanhSachIntent_ResponseID { get; set; }
        public int DM_Intent_Response_GroupID { get; set; }
        public int DM_Intent_Response_SubGroupID { get; set; }
        public int DM_Intent_TypeID { get; set; }
        public int DM_Entity_TypeID { get; set; }
        public int ThongTinDanhSachIntent_ResponseType { get; set; }
        public String ThongTinDanhSachIntent_ResponseName { get; set; }
        public IList<Intent_Response> mListData { get; set; }

        //Constructor
        public ThongTinDanhSachIntent_Response()
        {
            ThongTinDanhSachIntent_ResponseID = ThongTinDanhSachIntent_ResponseID_Index++;
        }

        //Ref
        public IList<ThongTinDanhSachIntent_Response> mListSubData { get; set; }
        public bool isSelected { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is ThongTinDanhSachIntent_Response)
            {
                ThongTinDanhSachIntent_Response data = obj as ThongTinDanhSachIntent_Response;
                if (data.ThongTinDanhSachIntent_ResponseID == ThongTinDanhSachIntent_ResponseID)
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

