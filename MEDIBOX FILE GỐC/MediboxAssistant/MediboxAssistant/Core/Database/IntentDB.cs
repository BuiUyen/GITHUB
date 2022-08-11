using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Sanita.Utility.Database.BaseDao;
using Sanita.Utility.Database.Utility;
using Medibox.Model;

namespace Medibox.Database
{
    public class IntentDB : BaseDB
    {
        //Constant
        private const String TAG = "IntentDB";
        //Singleton
        private static IntentDB _instance;
        public static IntentDB mInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IntentDB();
                }
                return _instance;
            }
        }
        public IList<Intent> GetIntents()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_intent ");
            DataTable dt = baseDAO.DoGetDataTable(sql.ToString());
            return (MakeIntents(dt));
        }

        public Intent GetIntent()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_intent ");
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeIntent(row));
        }

        public Intent GetIntent(int IntentID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_intent ");
            sql.Append(" WHERE IntentID = " + IntentID.Escape());
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeIntent(row));
        }

        public int UpdateIntent(IDbConnection connection, IDbTransaction trans, Intent data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }

                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE tb_intent ");
                sql.Append("  SET  ");
                sql.Append("      IntentName = " + data.IntentName.Escape()).Append(", ");
                sql.Append("      DM_Intent_TypeID = " + data.DM_Intent_TypeID.Escape());
                sql.Append("  WHERE IntentID = " + data.IntentID);
                return baseDAO.DoUpdate(connection, trans, sql.ToString());
            }
        }
        public int InsertIntent(IDbConnection connection, IDbTransaction trans, Intent data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO tb_intent (");
                sql.Append("            IntentName,");
                sql.Append("            DM_Intent_TypeID)");
                sql.Append("  VALUES( ");
                sql.Append("          " + data.IntentName.Escape()).Append(", ");
                sql.Append("          " + data.DM_Intent_TypeID.Escape()).Append(") ");
                int newId = baseDAO.DoInsert(connection, trans, sql.ToString());
                data.IntentID = newId;
                if (newId > 0)
                {
                    return newId;
                }
                else
                {
                    return DataTypeModel.RESULT_NG;
                }
            }
        }
        public int DeleteIntent(Intent data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM tb_intent  ");
                sql.Append("  WHERE IntentID = " + DatabaseUtility.Escape(data.IntentID));
                return baseDAO.DoUpdate(sql.ToString());
            }
        }
        #region Utility
        private IList<Intent> MakeIntents(DataTable dt)
        {
            IList<Intent> list = new List<Intent>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MakeIntent(row));
                }
            }
            return list;
        }
        private Intent MakeIntent(DataRow row)
        {
            Intent record = new Intent();
            if (row != null)
            {
                record.SetProperty(row);
            }
            return record;
        }
        #endregion
    }
}
