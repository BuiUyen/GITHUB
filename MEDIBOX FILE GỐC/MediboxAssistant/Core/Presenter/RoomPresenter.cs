using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Medibox.Database;
using Medibox.Model;
using Sanita.Utility.Database.BaseDao;
using Sanita.Utility.Database.Utility;
using Sanita.Utility.ExtendedThread;

namespace Medibox.Presenter
{
    public class RoomPresenter : BasePresenter
    {
        private const String TAG = "RoomPresenter";
        public static IList<Room> GetRooms(IDbConnection connection, IDbTransaction trans)
        {
            return RoomDB.mInstance.GetRooms(connection, trans);
        }

        public static Room GetRoom()
        {
            return RoomDB.mInstance.GetRoom();
        }

        public static Room GetRoom(int RoomID)
        {
            return RoomDB.mInstance.GetRoom(RoomID);
        }

        public static void UpdateRoom(Room data)
        {
            RoomDB.mInstance.UpdateRoom(null, null, data);
        }

        public static void InsertRoom(Room data)
        {
            RoomDB.mInstance.InsertRoom(null, null, data);
        }

        public static int DeleteRoom(Room data)
        {
            return RoomDB.mInstance.DeleteRoom(data);
        }
    }
}

