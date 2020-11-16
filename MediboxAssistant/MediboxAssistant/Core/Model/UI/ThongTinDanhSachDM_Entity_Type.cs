using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sanita.Utility;

namespace Medibox.Model
{
    [Serializable()]
    public class ThongTinDanhSachDM_Entity_Type
    {
        public enum TYPE
        {
            ROOT = 0,

            GROUP = 1,
            SUB_GROUP = 2,
        }

        public static int ThongTinDanhSachDM_Entity_TypeID_Index { get; set; }

        public int ThongTinDanhSachDM_Entity_TypeID { get; set; }
        public int DM_DM_Entity_Type_GroupID { get; set; }
        public int DM_DM_Entity_Type_SubGroupID { get; set; }
        public int DM_Intent_TypeID { get; set; }
        public int DM_Entity_TypeID { get; set; }
        public int ThongTinDanhSachDM_Entity_TypeType { get; set; }
        public String ThongTinDanhSachDM_Entity_TypeName { get; set; }
        public IList<DM_Entity_Type> mListData { get; set; }

        //Constructor
        public ThongTinDanhSachDM_Entity_Type()
        {
            ThongTinDanhSachDM_Entity_TypeID = ThongTinDanhSachDM_Entity_TypeID_Index++;
        }

        //Ref
        public IList<ThongTinDanhSachDM_Entity_Type> mListSubData { get; set; }
        public bool isSelected { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is ThongTinDanhSachDM_Entity_Type)
            {
                ThongTinDanhSachDM_Entity_Type data = obj as ThongTinDanhSachDM_Entity_Type;
                if (data.ThongTinDanhSachDM_Entity_TypeID == ThongTinDanhSachDM_Entity_TypeID)
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

