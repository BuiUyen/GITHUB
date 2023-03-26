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

    public class CheckerPresenter : BasePresenter
    {
        private const String TAG = "CheckerPresenter";
        public static IList<Checker> GetCheckers()
        {
            return CheckerDB.mInstance.GetCheckers(null,null);
        }

        public static Checker GetChecker()
        {
            return CheckerDB.mInstance.GetChecker();
        }

        public static Checker GetChecker(int CheckerID)
        {
            return CheckerDB.mInstance.GetChecker(CheckerID);
        }
        public static void UpdateChecker(Checker data)
        {
            CheckerDB.mInstance.UpdateChecker(null, null, data);
        }

        public static void InsertChecker(Checker data)
        {
            CheckerDB.mInstance.InsertChecker(null, null, data);
        }

        public static int DeleteChecker(Checker data)
        {
            return CheckerDB.mInstance.DeleteChecker(data);
        }

        public static Checker GetChecker_CheckerCode(string CheckerCode)
        {
            return CheckerDB.mInstance.GetChecker_CheckerCode(CheckerCode);
        }
    }

}
