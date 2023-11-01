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
    public class DM_Intent_TypeDB : BaseDB
    {
        //Constant
        private const String TAG = "DM_Intent_TypeDB";
        //Singleton
        private static DM_Intent_TypeDB _instance;
        public static DM_Intent_TypeDB mInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DM_Intent_TypeDB();
                }
                return _instance;
            }
        }
        public IList<DM_Intent_Type> GetDM_Intent_Types(IDbConnection connection, IDbTransaction trans)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_dm_intent_type ");
            DataTable dt = baseDAO.DoGetDataTable(connection, trans, sql.ToString());
            return (MakeDM_Intent_Types(dt));
        }

        public DM_Intent_Type GetDM_Intent_Type()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_dm_intent_type ");
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeDM_Intent_Type(row));
        }

        public DM_Intent_Type GetDM_Intent_Type(int DM_Intent_TypeID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_dm_intent_type ");
            sql.Append(" WHERE DM_Intent_TypeID = " + DM_Intent_TypeID.Escape());
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeDM_Intent_Type(row));
        }

        public int UpdateDM_Intent_Type(IDbConnection connection, IDbTransaction trans, DM_Intent_Type data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }

                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE tb_dm_intent_type ");
                sql.Append("  SET  ");
                sql.Append("      DM_Intent_TypeID = " + data.DM_Intent_TypeID.Escape()).Append(", ");
                sql.Append("      DM_Intent_TypeName = " + data.DM_Intent_TypeName.Escape()).Append(", ");
                sql.Append("      DM_Intent_TypeHardcode = " + data.DM_Intent_TypeHardcode.Escape()).Append(", ");
                sql.Append("      DM_Intent_TypeDisable = " + data.DM_Intent_TypeDisable.Escape());
                sql.Append("  WHERE DM_Intent_TypeDBID = " + data.DM_Intent_TypeDBID);
                return baseDAO.DoUpdate(connection, trans, sql.ToString());
            }
        }
        public int InsertDM_Intent_Type(IDbConnection connection, IDbTransaction trans, DM_Intent_Type data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO tb_dm_intent_type (");
                sql.Append("            DM_Intent_TypeID,");
                sql.Append("            DM_Intent_TypeName,");
                sql.Append("            DM_Intent_TypeHardcode,");
                sql.Append("            DM_Intent_TypeDisable)");
                sql.Append("  VALUES( ");
                sql.Append("          " + data.DM_Intent_TypeID.Escape()).Append(", ");
                sql.Append("          " + data.DM_Intent_TypeName.Escape()).Append(", ");
                sql.Append("          " + data.DM_Intent_TypeHardcode.Escape()).Append(", ");
                sql.Append("          " + data.DM_Intent_TypeDisable.Escape()).Append(") ");
                int newId = baseDAO.DoInsert(connection, trans, sql.ToString());
                data.DM_Intent_TypeDBID = newId;
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
        public int DeleteDM_Intent_Type(DM_Intent_Type data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM tb_dm_intent_type  ");
                sql.Append("  WHERE DM_Intent_TypeDBID = " + DatabaseUtility.Escape(data.DM_Intent_TypeDBID));
                return baseDAO.DoUpdate(sql.ToString());
            }
        }
        #region Utility
        private IList<DM_Intent_Type> MakeDM_Intent_Types(DataTable dt)
        {
            IList<DM_Intent_Type> list = new List<DM_Intent_Type>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MakeDM_Intent_Type(row));
                }
            }
            return list;
        }
        private DM_Intent_Type MakeDM_Intent_Type(DataRow row)
        {
            DM_Intent_Type record = new DM_Intent_Type();
            if (row != null)
            {
                record.SetProperty(row);
            }
            return record;
        }
        #endregion
    }
}
