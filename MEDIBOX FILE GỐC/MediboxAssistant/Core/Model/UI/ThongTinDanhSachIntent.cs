using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sanita.Utility;

namespace Medibox.Model
{
    [Serializable()]
    public class ThongTinDanhSachIntent
    {
        public enum TYPE
        {
            ROOT = 0,

            GROUP = 1,
            SUB_GROUP = 2,
        }

        public static int ThongTinDanhSachIntentID_Index { get; set; }

        public int ThongTinDanhSachIntentID { get; set; }
        public int DM_Intent_GroupID { get; set; }
        public int DM_Intent_SubGroupID { get; set; }
        public int ThongTinDanhSachIntentType { get; set; }
        public String ThongTinDanhSachIntentName { get; set; }
        public IList<Intent> mListData { get; set; }

        //Constructor
        public ThongTinDanhSachIntent()
        {
            ThongTinDanhSachIntentID = ThongTinDanhSachIntentID_Index++;
        }

        //Ref
        public IList<ThongTinDanhSachIntent> mListSubData { get; set; }
        public bool isSelected { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is ThongTinDanhSachIntent)
            {
                ThongTinDanhSachIntent data = obj as ThongTinDanhSachIntent;
                if (data.ThongTinDanhSachIntentID == ThongTinDanhSachIntentID)
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

