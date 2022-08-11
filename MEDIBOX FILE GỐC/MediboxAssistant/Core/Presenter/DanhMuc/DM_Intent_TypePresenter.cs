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
    public class DM_Intent_TypePresenter : BasePresenter
    {
        private const String TAG = "DM_Intent_TypePresenter";
        public static IList<DM_Intent_Type> GetDM_Intent_Types(IDbConnection connection, IDbTransaction trans)
        {
            return DM_Intent_TypeDB.mInstance.GetDM_Intent_Types(connection, trans);
        }

        public static DM_Intent_Type GetDM_Intent_Type()
        {
            return DM_Intent_TypeDB.mInstance.GetDM_Intent_Type();
        }

        public static DM_Intent_Type GetDM_Intent_Type(int DM_Intent_TypeID)
        {
            return DM_Intent_TypeDB.mInstance.GetDM_Intent_Type(DM_Intent_TypeID);
        }

        public static void UpdateDM_Intent_Type(DM_Intent_Type data)
        {
            DM_Intent_TypeDB.mInstance.UpdateDM_Intent_Type(null, null, data);
        }

        public static int InsertDM_Intent_Type(DM_Intent_Type data)
        {
            return DM_Intent_TypeDB.mInstance.InsertDM_Intent_Type(null, null, data);
        }

        public static int DeleteDM_Intent_Type(DM_Intent_Type data)
        {
            return DM_Intent_TypeDB.mInstance.DeleteDM_Intent_Type(data);
        }
    }
}

