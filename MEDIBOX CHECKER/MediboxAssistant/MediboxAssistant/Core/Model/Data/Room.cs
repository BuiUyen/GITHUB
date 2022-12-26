using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    [Serializable()]
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }        
        public int HomeID { get; set; }
        public int UserID { get; set; }

        //Ref
        public IList<Room> mListSubData { get; set; }
        public bool isSelected { get; set; }

        public static int GetID(String name)
        {
            Room data = MyVar.mListRoom.FirstOrDefault(p => p != null && p.RoomName == name);
            data = data ?? new Room();
            return data.RoomID;
        }

        public static Room GetDefault(int _id)
        {
            Room data = MyVar.mListRoom.FirstOrDefault(p => p.RoomID == _id);
            if (data == null)
            {
                data = new Room();
            }

            return data;
        }
    }
}
