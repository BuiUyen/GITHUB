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
    public class HomeDB : BaseDB
    {
        //Constant
        private const String TAG = "HomeDB";
        //Singleton
        private static HomeDB _instance;
        public static HomeDB mInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HomeDB();
                }
                return _instance;
            }
        }
        public IList<Home> GetHomes(IDbConnection connection, IDbTransaction trans)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_home ");
            DataTable dt = baseDAO.DoGetDataTable(connection, trans, sql.ToString());
            return (MakeHomes(dt));
        }

        public Home GetHome()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_home ");
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeHome(row));
        }

        public Home GetHome(int HomeID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_home ");
            sql.Append(" WHERE HomeID = " + HomeID.Escape());
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeHome(row));
        }

        public int UpdateHome(IDbConnection connection, IDbTransaction trans, Home data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }

                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE tb_home ");
                sql.Append("  SET  ");
                sql.Append("      HomeName = " + data.HomeName.Escape()).Append(", ");
                sql.Append("      UserID = " + data.UserID.Escape());
                sql.Append("  WHERE HomeID = " + data.HomeID);
                return baseDAO.DoUpdate(connection, trans, sql.ToString());
            }
        }
        public int InsertHome(IDbConnection connection, IDbTransaction trans, Home data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO tb_home (");
                sql.Append("            HomeName,");
                sql.Append("            UserID)");
                sql.Append("  VALUES( ");
                sql.Append("          " + data.HomeName.Escape()).Append(", ");
                sql.Append("          " + data.UserID.Escape()).Append(") ");
                int newId = baseDAO.DoInsert(connection, trans, sql.ToString());
                data.HomeID = newId;
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
        public int DeleteHome(Home data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM tb_home  ");
                sql.Append("  WHERE HomeID = " + DatabaseUtility.Escape(data.HomeID));
                return baseDAO.DoUpdate(sql.ToString());
            }
        }
        #region Utility
        private IList<Home> MakeHomes(DataTable dt)
        {
            IList<Home> list = new List<Home>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MakeHome(row));
                }
            }
            return list;
        }
        private Home MakeHome(DataRow row)
        {
            Home record = new Home();
            if (row != null)
            {
                record.SetProperty(row);
            }
            return record;
        }
        #endregion
    }
}
