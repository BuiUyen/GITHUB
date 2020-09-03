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
    public class Intent_ResponsePresenter : BasePresenter
    {
        private const String TAG = "Intent_ResponsePresenter";
        public static IList<Intent_Response> GetIntent_Responses()
        {
            return Intent_ResponseDB.mInstance.GetIntent_Responses();
        }

        public static Intent_Response GetIntent_Response()
        {
            return Intent_ResponseDB.mInstance.GetIntent_Response();
        }

        public static Intent_Response GetIntent_Response(int Intent_ResponseID)
        {
            return Intent_ResponseDB.mInstance.GetIntent_Response(Intent_ResponseID);
        }

        public static Intent_Response GetIntent_Response_Request(Intent_Request mIntent_Request)
        {
            return Intent_ResponseDB.mInstance.GetIntent_Response(mIntent_Request);
        }

        public static void UpdateIntent_Response(Intent_Response data)
        {
            Intent_ResponseDB.mInstance.UpdateIntent_Response(null, null, data);
        }

        public static void InsertIntent_Response(Intent_Response data)
        {
            Intent_ResponseDB.mInstance.InsertIntent_Response(null, null, data);
        }

        public static int DeleteIntent_Response(Intent_Response data)
        {
            return Intent_ResponseDB.mInstance.DeleteIntent_Response(data);
        }
    }
}

