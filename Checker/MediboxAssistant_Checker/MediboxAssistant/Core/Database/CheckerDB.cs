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
    public class CheckerDB : BaseDB
    {
        //Constant
        private const String TAG = "CheckerDB";
        //Singleton
        private static CheckerDB _instance;
        public static CheckerDB mInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CheckerDB();
                }
                return _instance;
            }
        }
        public IList<Checker> GetCheckers(IDbConnection connection, IDbTransaction trans)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_checker ");
            DataTable dt = baseDAO.DoGetDataTable(connection, trans, sql.ToString());
            return (MakeCheckers(dt));
        }
        public Checker GetChecker()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_checker ");
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeChecker(row));
        }
        public Checker GetChecker(int CheckerID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_checker ");
            sql.Append(" WHERE CheckerID = " + CheckerID.Escape());
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeChecker(row));
        }
        public int UpdateChecker(IDbConnection connection, IDbTransaction trans, Checker data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }

                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE tb_Checker ");
                sql.Append("  SET  ");
                sql.Append("      Gia = " + data.Gia.Escape()).Append(", ");
                sql.Append("      Ten = " + data.Ten.Escape()).Append(", ");
                sql.Append("      SDT = " + data.SDT.Escape()).Append(", ");
                sql.Append("      LinkAnh = " + data.LinkAnh.Escape());
                sql.Append("  WHERE CheckerID = " + data.CheckerID);
                return baseDAO.DoUpdate(connection, trans, sql.ToString());
            }
        }
        public int InsertChecker(IDbConnection connection, IDbTransaction trans, Checker data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO tb_checker (");
                sql.Append("            Gia,");
                sql.Append("            Ten,");
                sql.Append("            SDT,");
                sql.Append("            LinkAnh)");
                sql.Append("  VALUES( ");
                sql.Append("          " + data.Gia.Escape()).Append(", ");
                sql.Append("          " + data.Ten.Escape()).Append(", ");
                sql.Append("          " + data.SDT.Escape()).Append(", ");
                sql.Append("          " + data.LinkAnh.Escape()).Append(") ");
                int newId = baseDAO.DoInsert(connection, trans, sql.ToString());
                data.CheckerID = newId;
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
        public int DeleteChecker(Checker data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM tb_checker  ");
                sql.Append("  WHERE CheckerID = " + DatabaseUtility.Escape(data.CheckerID));
                return baseDAO.DoUpdate(sql.ToString());
            }
        }
        #region Utility
        private IList<Checker> MakeCheckers(DataTable dt)
        {
            IList<Checker> list = new List<Checker>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MakeChecker(row));
                }
            }
            return list;
        }
        private Checker MakeChecker(DataRow row)
        {
            Checker record = new Checker();
            if (row != null)
            {
                record.SetProperty(row);
            }
            return record;
        }
        #endregion
    }
}