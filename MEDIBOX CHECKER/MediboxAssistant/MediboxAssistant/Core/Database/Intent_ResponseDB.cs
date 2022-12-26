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
    public class Intent_ResponseDB : BaseDB
    {
        //Constant
        private const String TAG = "Intent_ResponseDB";
        //Singleton
        private static Intent_ResponseDB _instance;
        public static Intent_ResponseDB mInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Intent_ResponseDB();
                }
                return _instance;
            }
        }
        public IList<Intent_Response> GetIntent_Responses()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_intent_response ");
            DataTable dt = baseDAO.DoGetDataTable(sql.ToString());
            return (MakeIntent_Responses(dt));
        }

        public Intent_Response GetIntent_Response()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_intent_response ");
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeIntent_Response(row));
        }

        public Intent_Response GetIntent_Response(int Intent_ResponseID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_intent_response ");
            sql.Append(" WHERE Intent_ResponseID = " + Intent_ResponseID.Escape());
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeIntent_Response(row));
        }

        public Intent_Response GetIntent_Response(Intent_Request mIntent_Request)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_intent_response ");
            sql.Append(" WHERE DM_Intent_TypeID = " + mIntent_Request.DM_Intent_TypeID.Escape() + " AND DM_Entity_TypeID = " + mIntent_Request.DM_Entity_TypeID.Escape());
            sql.Append(" ORDER BY random() limit 10 ");
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeIntent_Response(row));
        }

        public int UpdateIntent_Response(IDbConnection connection, IDbTransaction trans, Intent_Response data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }

                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE tb_intent_response ");
                sql.Append("  SET  ");
                sql.Append("      IntentID = " + data.IntentID.Escape()).Append(", ");
                sql.Append("      DM_Intent_TypeID = " + data.DM_Intent_TypeID.Escape()).Append(", ");
                sql.Append("      DM_Entity_TypeID = " + data.DM_Entity_TypeID.Escape()).Append(", ");          
                sql.Append("      Data = " + data.Data.Escape());
                sql.Append("  WHERE Intent_ResponseID = " + data.Intent_ResponseID);
                return baseDAO.DoUpdate(connection, trans, sql.ToString());
            }
        }
        public int InsertIntent_Response(IDbConnection connection, IDbTransaction trans, Intent_Response data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO tb_intent_response (");
                sql.Append("            IntentID,");
                sql.Append("            DM_Intent_TypeID,");
                sql.Append("            DM_Entity_TypeID,");
                sql.Append("            Data)");                
                sql.Append("  VALUES( ");
                sql.Append("          " + data.IntentID.Escape()).Append(", ");
                sql.Append("          " + data.DM_Intent_TypeID.Escape()).Append(", ");
                sql.Append("          " + data.DM_Entity_TypeID.Escape()).Append(", ");      
                sql.Append("          " + data.Data.Escape()).Append(") ");
                int newId = baseDAO.DoInsert(connection, trans, sql.ToString());
                data.Intent_ResponseID = newId;
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
        public int DeleteIntent_Response(Intent_Response data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM tb_intent_response  ");
                sql.Append("  WHERE Intent_ResponseID = " + DatabaseUtility.Escape(data.Intent_ResponseID));
                return baseDAO.DoUpdate(sql.ToString());
            }
        }
        #region Utility
        private IList<Intent_Response> MakeIntent_Responses(DataTable dt)
        {
            IList<Intent_Response> list = new List<Intent_Response>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MakeIntent_Response(row));
                }
            }
            return list;
        }
        private Intent_Response MakeIntent_Response(DataRow row)
        {
            Intent_Response record = new Intent_Response();
            if (row != null)
            {
                record.SetProperty(row);
            }
            return record;
        }
        #endregion
    }
}
