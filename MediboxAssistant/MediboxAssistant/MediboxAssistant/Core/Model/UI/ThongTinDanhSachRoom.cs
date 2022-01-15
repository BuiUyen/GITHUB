using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sanita.Utility;

namespace Medibox.Model
{
    [Serializable()]
    public class ThongTinDanhSachRoom
    {
        public enum TYPE
        {
            ROOT = 0,

            GROUP = 1,
            SUB_GROUP = 2,
        }

        public static int ThongTinDanhSachRoomID_Index { get; set; }

        public int ThongTinDanhSachRoomID { get; set; }
        public int DM_Room_GroupID { get; set; }
        public int DM_Room_SubGroupID { get; set; }
        public int DM_Intent_TypeID { get; set; }
        public int RoomID { get; set; }
        public int ThongTinDanhSachRoomType { get; set; }
        public String ThongTinDanhSachRoomName { get; set; }
        public IList<Room> mListData { get; set; }

        //Constructor
        public ThongTinDanhSachRoom()
        {
            ThongTinDanhSachRoomID = ThongTinDanhSachRoomID_Index++;
        }

        //Ref
        public IList<ThongTinDanhSachRoom> mListSubData { get; set; }
        public bool isSelected { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is ThongTinDanhSachRoom)
            {
                ThongTinDanhSachRoom data = obj as ThongTinDanhSachRoom;
                if (data.ThongTinDanhSachRoomID == ThongTinDanhSachRoomID)
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

