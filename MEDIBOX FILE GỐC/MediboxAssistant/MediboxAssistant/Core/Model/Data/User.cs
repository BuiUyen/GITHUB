using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    [Serializable()]
    public class User
    {
        public int UserID { get; set; }
        public string UserCode { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string APIKey { get; set; }

        //Localtion
        public string LocaltionName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        //Hass
        public string HassIO_URL { get; set; }
        public string HassIO_KEY { get; set; }

        //------------------------------------------------------------


        public static int GetID(String name)
        {
            User data = MyVar.mListUser.FirstOrDefault(p => p != null && p.UserName == name);
            data = data ?? new User();
            return data.UserID;
        }

        public static User GetDefault(int _id)
        {
            User data = MyVar.mListUser.FirstOrDefault(p => p.UserID == _id);
            if (data == null)
            {
                data = new User();
            }

            return data;
        }
    }
}
