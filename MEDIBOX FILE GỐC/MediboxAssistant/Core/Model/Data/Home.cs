using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    [Serializable()]
    public class Home
    {
        public int HomeID { get; set; }
        public string HomeName { get; set; }
        public int UserID { get; set; }

        //Ref
        public bool isSelected { get; set; }
        
        public static int GetID(String name)
        {
            Home data = MyVar.mListHome.FirstOrDefault(p => p != null && p.HomeName == name);
            data = data ?? new Home();
            return data.HomeID;
        }

        public static Home GetDefault(int _id)
        {
            Home data = MyVar.mListHome.FirstOrDefault(p => p.HomeID == _id);
            if (data == null)
            {
                data = new Home();
            }

            return data;
        }
    }

}
