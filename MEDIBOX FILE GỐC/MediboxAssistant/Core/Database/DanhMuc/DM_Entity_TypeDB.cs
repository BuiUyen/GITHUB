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
    public class DM_Entity_TypeDB : BaseDB
    {
        //Constant
        private const String TAG = "DM_Entity_TypeDB";
        //Singleton
        private static DM_Entity_TypeDB _instance;
        public static DM_Entity_TypeDB mInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DM_Entity_TypeDB();
                }
                return _instance;
            }
        }
        public IList<DM_Entity_Type> GetDM_Entity_Types(IDbConnection connection, IDbTransaction trans)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_dm_entity_type ");
            DataTable dt = baseDAO.DoGetDataTable(connection, trans, sql.ToString());
            return (MakeDM_Entity_Types(dt));
        }

        public DM_Entity_Type GetDM_Entity_Type()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_dm_entity_type ");
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeDM_Entity_Type(row));
        }

        public DM_Entity_Type GetDM_Entity_Type(int DM_Entity_TypeID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_dm_entity_type ");
            sql.Append(" WHERE DM_Entity_TypeID = " + DM_Entity_TypeID.Escape());
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeDM_Entity_Type(row));
        }

        public int UpdateDM_Entity_Type(IDbConnection connection, IDbTransaction trans, DM_Entity_Type data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }

                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE tb_dm_entity_type ");
                sql.Append("  SET  ");
                sql.Append("      DM_Entity_TypeID = " + data.DM_Entity_TypeID.Escape()).Append(", ");
                sql.Append("      DM_Intent_TypeID = " + data.DM_Intent_TypeID.Escape()).Append(", ");
                sql.Append("      DM_Entity_TypeName = " + data.DM_Entity_TypeName.Escape()).Append(", ");
                sql.Append("      DM_Entity_TypeHardcode = " + data.DM_Entity_TypeHardcode.Escape()).Append(", ");
                sql.Append("      DM_Entity_TypeDisable = " + data.DM_Entity_TypeDisable.Escape());
                sql.Append("  WHERE DM_Entity_TypeDBID = " + data.DM_Entity_TypeDBID);
                return baseDAO.DoUpdate(connection, trans, sql.ToString());
            }
        }
        public int InsertDM_Entity_Type(IDbConnection connection, IDbTransaction trans, DM_Entity_Type data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO tb_dm_entity_type (");
                sql.Append("            DM_Entity_TypeID,");
                sql.Append("            DM_Intent_TypeID,");
                sql.Append("            DM_Entity_TypeName,");
                sql.Append("            DM_Entity_TypeHardcode,");
                sql.Append("            DM_Entity_TypeDisable)");
                sql.Append("  VALUES( ");
                sql.Append("          " + data.DM_Entity_TypeID.Escape()).Append(", ");
                sql.Append("          " + data.DM_Intent_TypeID.Escape()).Append(", ");
                sql.Append("          " + data.DM_Entity_TypeName.Escape()).Append(", ");
                sql.Append("          " + data.DM_Entity_TypeHardcode.Escape()).Append(", ");
                sql.Append("          " + data.DM_Entity_TypeDisable.Escape()).Append(") ");
                int newId = baseDAO.DoInsert(connection, trans, sql.ToString());
                data.DM_Entity_TypeDBID = newId;
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
        public int DeleteDM_Entity_Type(DM_Entity_Type data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM tb_dm_entity_type  ");
                sql.Append("  WHERE DM_Entity_TypeDBID = " + DatabaseUtility.Escape(data.DM_Entity_TypeDBID));
                return baseDAO.DoUpdate(sql.ToString());
            }
        }
        #region Utility
        private IList<DM_Entity_Type> MakeDM_Entity_Types(DataTable dt)
        {
            IList<DM_Entity_Type> list = new List<DM_Entity_Type>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MakeDM_Entity_Type(row));
                }
            }
            return list;
        }
        private DM_Entity_Type MakeDM_Entity_Type(DataRow row)
        {
            DM_Entity_Type record = new DM_Entity_Type();
            if (row != null)
            {
                record.SetProperty(row);
            }
            return record;
        }
        #endregion
    }
}
