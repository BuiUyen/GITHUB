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
    public class HomePresenter : BasePresenter
    {
        private const String TAG = "HomePresenter";
        public static IList<Home> GetHomes(IDbConnection connection, IDbTransaction trans)
        {
            return HomeDB.mInstance.GetHomes(connection, trans);
        }

        public static Home GetHome()
        {
            return HomeDB.mInstance.GetHome();
        }

        public static Home GetHome(int HomeID)
        {
            return HomeDB.mInstance.GetHome(HomeID);
        }

        public static void UpdateHome(Home data)
        {
            HomeDB.mInstance.UpdateHome(null, null, data);
        }

        public static void InsertHome(Home data)
        {
            HomeDB.mInstance.InsertHome(null, null, data);
        }

        public static int DeleteHome(Home data)
        {
            return HomeDB.mInstance.DeleteHome(data);
        }
    }
}

