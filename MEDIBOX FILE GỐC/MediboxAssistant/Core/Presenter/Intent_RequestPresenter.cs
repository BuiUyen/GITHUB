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
    public class Intent_RequestPresenter : BasePresenter
    {
        private const String TAG = "Intent_RequestPresenter";
        public static IList<Intent_Request> GetIntent_Requests(String query)
        {
            return Intent_RequestDB.mInstance.GetIntent_Requests(query);
        }

        public static IList<Intent_Request> GetIntent_Requests()
        {
            return Intent_RequestDB.mInstance.GetIntent_Requests();
        }

        public static Intent_Request GetIntent_Request()
        {
            return Intent_RequestDB.mInstance.GetIntent_Request();
        }

        public static Intent_Request GetIntent_Request(int Intent_RequestID)
        {
            return Intent_RequestDB.mInstance.GetIntent_Request(Intent_RequestID);
        }

        public static void UpdateIntent_Request(Intent_Request data)
        {
            Intent_RequestDB.mInstance.UpdateIntent_Request(null, null, data);
        }

        public static void InsertIntent_Request(Intent_Request data)
        {
            Intent_RequestDB.mInstance.InsertIntent_Request(null, null, data);
        }

        public static int DeleteIntent_Request(Intent_Request data)
        {
            return Intent_RequestDB.mInstance.DeleteIntent_Request(data);
        }
    }
}

