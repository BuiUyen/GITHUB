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
    public class DM_Entity_TypePresenter : BasePresenter
    {
        private const String TAG = "DM_Entity_TypePresenter";
        public static IList<DM_Entity_Type> GetDM_Entity_Types(IDbConnection connection, IDbTransaction trans)
        {
            return DM_Entity_TypeDB.mInstance.GetDM_Entity_Types(connection, trans);
        }

        public static DM_Entity_Type GetDM_Entity_Type()
        {
            return DM_Entity_TypeDB.mInstance.GetDM_Entity_Type();
        }

        public static DM_Entity_Type GetDM_Entity_Type(int DM_Entity_TypeID)
        {
            return DM_Entity_TypeDB.mInstance.GetDM_Entity_Type(DM_Entity_TypeID);
        }

        public static void UpdateDM_Entity_Type(DM_Entity_Type data)
        {
            DM_Entity_TypeDB.mInstance.UpdateDM_Entity_Type(null, null, data);
        }

        public static int InsertDM_Entity_Type(DM_Entity_Type data)
        {
            return DM_Entity_TypeDB.mInstance.InsertDM_Entity_Type(null, null, data);
        }

        public static int DeleteDM_Entity_Type(DM_Entity_Type data)
        {
            return DM_Entity_TypeDB.mInstance.DeleteDM_Entity_Type(data);
        }
    }
}

