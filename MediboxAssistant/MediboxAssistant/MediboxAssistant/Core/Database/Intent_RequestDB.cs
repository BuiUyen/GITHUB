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
    public class Intent_RequestDB : BaseDB
    {
        //Constant
        private const String TAG = "Intent_RequestDB";
        //Singleton
        private static Intent_RequestDB _instance;
        public static Intent_RequestDB mInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Intent_RequestDB();
                }
                return _instance;
            }
        }

        public IList<Intent_Request> GetIntent_Requests()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_intent_request ");                        
            DataTable dt = baseDAO.DoGetDataTable(sql.ToString());
            return (MakeIntent_Requests(dt));
        }

        public IList<Intent_Request> GetIntent_Requests(String query)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_intent_request ");
            sql.Append(" WHERE to_tsvector('vietnamese','" + query + "') @@ data_query");
            sql.Append(" ORDER BY random() ");
            sql.Append(" LIMIT 100");
            DataTable dt = baseDAO.DoGetDataTable(sql.ToString());
            return (MakeIntent_Requests(dt));
        }

        public Intent_Request GetIntent_Request()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_intent_request ");
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeIntent_Request(row));
        }

        public Intent_Request GetIntent_Request(int Intent_RequestID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_intent_request ");
            sql.Append(" WHERE Intent_RequestID = " + Intent_RequestID.Escape());
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeIntent_Request(row));
        }

        public int UpdateIntent_Request(IDbConnection connection, IDbTransaction trans, Intent_Request data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }

                String data_request = data.Data;
                data_request = data_request ?? "";
                data_request = System.Text.RegularExpressions.Regex.Replace(data_request, @"<[^>]+>", "");
                data_request = data_request.TrimSpace().Trim();

                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE tb_intent_request ");
                sql.Append("  SET  ");
                sql.Append("      IntentID = " + data.IntentID.Escape()).Append(", ");
                sql.Append("      Data = " + data.Data.Escape()).Append(", ");
                sql.Append("      Data_Query = " + data_request.Escape_TSQuery()).Append(", ");
                sql.Append("      DM_Entity_TypeID = " + data.DM_Entity_TypeID.Escape()).Append(", ");
                sql.Append("      Current_DM_Intent_TypeID = " + data.Current_DM_Intent_TypeID.Escape()).Append(", ");
                sql.Append("      Current_DM_Entity_TypeID = " + data.Current_DM_Entity_TypeID.Escape()).Append(", ");
                sql.Append("      DM_Intent_TypeID = " + data.DM_Intent_TypeID.Escape());
                sql.Append("  WHERE Intent_RequestID = " + data.Intent_RequestID);
                return baseDAO.DoUpdate(connection, trans, sql.ToString());
            }
        }
        public int InsertIntent_Request(IDbConnection connection, IDbTransaction trans, Intent_Request data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }

                String data_request = data.Data;
                data_request = data_request ?? "";
                data_request = System.Text.RegularExpressions.Regex.Replace(data_request, @"<[^>]+>", "");
                data_request = data_request.TrimSpace().Trim();

                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO tb_intent_request (");
                sql.Append("            IntentID,");
                sql.Append("            Data,");
                sql.Append("            Data_Query,");
                sql.Append("            DM_Entity_TypeID,");
                sql.Append("            Current_DM_Intent_TypeID,");
                sql.Append("            Current_DM_Entity_TypeID,");
                sql.Append("            DM_Intent_TypeID)");
                sql.Append("  VALUES( ");
                sql.Append("          " + data.IntentID.Escape()).Append(", ");
                sql.Append("          " + data.Data.Escape()).Append(", ");
                sql.Append("          " + data_request.Escape_TSQuery()).Append(", ");
                sql.Append("          " + data.DM_Entity_TypeID.Escape()).Append(", ");
                sql.Append("          " + data.Current_DM_Intent_TypeID.Escape()).Append(", ");
                sql.Append("          " + data.Current_DM_Entity_TypeID.Escape()).Append(", ");
                sql.Append("          " + data.DM_Intent_TypeID.Escape()).Append(") ");
                int newId = baseDAO.DoInsert(connection, trans, sql.ToString());
                data.Intent_RequestID = newId;
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
        public int DeleteIntent_Request(Intent_Request data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM tb_intent_request  ");
                sql.Append("  WHERE Intent_RequestID = " + DatabaseUtility.Escape(data.Intent_RequestID));
                return baseDAO.DoUpdate(sql.ToString());
            }
        }
        #region Utility
        private IList<Intent_Request> MakeIntent_Requests(DataTable dt)
        {
            IList<Intent_Request> list = new List<Intent_Request>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MakeIntent_Request(row));
                }
            }
            return list;
        }
        private Intent_Request MakeIntent_Request(DataRow row)
        {
            Intent_Request record = new Intent_Request();
            if (row != null)
            {
                record.SetProperty(row);
            }
            return record;
        }
        #endregion
    }
}
