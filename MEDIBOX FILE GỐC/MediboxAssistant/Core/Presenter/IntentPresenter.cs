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
    public class IntentPresenter : BasePresenter
    {
        private const String TAG = "IntentPresenter";
        public static IList<Intent> GetIntents()
        {
            return IntentDB.mInstance.GetIntents();
        }

        public static Intent GetIntent()
        {
            return IntentDB.mInstance.GetIntent();
        }

        public static Intent GetIntent(int IntentID)
        {
            return IntentDB.mInstance.GetIntent(IntentID);
        }

        public static void UpdateIntent(Intent data)
        {
            IntentDB.mInstance.UpdateIntent(null, null, data);
        }

        public static void InsertIntent(Intent data)
        {
            IntentDB.mInstance.InsertIntent(null, null, data);
        }

        public static int DeleteIntent(Intent data)
        {
            return IntentDB.mInstance.DeleteIntent(data);
        }
    }
}

