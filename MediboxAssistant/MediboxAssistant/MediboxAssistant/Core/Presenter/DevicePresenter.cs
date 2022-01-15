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
    public class DevicePresenter : BasePresenter
    {
        private const String TAG = "DevicePresenter";

        public static IList<Device> GetDevices()
        {
            return DeviceDB.mInstance.GetDevices(null, null);
        }

        public static IList<Device> GetDevices(IDbConnection connection, IDbTransaction trans)
        {
            return DeviceDB.mInstance.GetDevices(connection, trans);
        }

        public static IList<Device> GetDevices_List(IDbConnection connection, IDbTransaction trans, int UserID, int RoomID, int HomeID)
        {
            return DeviceDB.mInstance.GetDevices_List(connection, trans, UserID, RoomID, HomeID);
        }

        public static Device GetDevice()
        {
            return DeviceDB.mInstance.GetDevice();
        }

        public static Device GetDevice(int DeviceID)
        {
            return DeviceDB.mInstance.GetDevice(DeviceID);
        }

        public static Device GetDevice(String DeviceCode)
        {
            return DeviceDB.mInstance.GetDevice(DeviceCode);
        }

        public static void UpdateDevice(Device data)
        {
            DeviceDB.mInstance.UpdateDevice(null, null, data);
        }

        public static void InsertDevice(Device data)
        {
            DeviceDB.mInstance.InsertDevice(null, null, data);
        }

        public static int DeleteDevice(Device data)
        {
            return DeviceDB.mInstance.DeleteDevice(data);
        }
    }
}

