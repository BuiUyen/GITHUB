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
    public class UserDB : BaseDB
    {
        //Constant
        private const String TAG = "UserDB";
        //Singleton
        private static UserDB _instance;
        public static UserDB mInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserDB();
                }
                return _instance;
            }
        }
        public IList<User> GetUsers(IDbConnection connection, IDbTransaction trans)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_user ");
            DataTable dt = baseDAO.DoGetDataTable(connection, trans, sql.ToString());
            return (MakeUsers(dt));
        }

        public User GetUser()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_user ");
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeUser(row));
        }

        public User GetUser(int UserID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_user ");
            sql.Append(" WHERE UserID = " + UserID.Escape());
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeUser(row));
        }

        public int UpdateUser(IDbConnection connection, IDbTransaction trans, User data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }

                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE tb_user ");
                sql.Append("  SET  ");
                sql.Append("      UserCode = " + data.UserCode.Escape()).Append(", ");
                sql.Append("      UserPassword = " + data.UserPassword.Escape()).Append(", ");
                sql.Append("      UserName = " + data.UserName.Escape()).Append(", ");
                sql.Append("      APIKey = " + data.APIKey.Escape()).Append(", ");
                sql.Append("      LocaltionName = " + data.LocaltionName.Escape()).Append(", ");
                sql.Append("      Latitude = " + data.Latitude.Escape()).Append(", ");
                sql.Append("      Longitude = " + data.Longitude.Escape()).Append(", ");
                sql.Append("      HassIO_URL = " + data.HassIO_URL.Escape()).Append(", ");
                sql.Append("      HassIO_KEY = " + data.HassIO_KEY.Escape());
                sql.Append("  WHERE UserID = " + data.UserID);
                return baseDAO.DoUpdate(connection, trans, sql.ToString());
            }
        }
        public int InsertUser(IDbConnection connection, IDbTransaction trans, User data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO tb_user (");
                sql.Append("            UserCode,");
                sql.Append("            UserPassword,");
                sql.Append("            UserName,");
                sql.Append("            APIKey,");
                sql.Append("            LocaltionName,");
                sql.Append("            Latitude,");
                sql.Append("            Longitude,");
                sql.Append("            HassIO_URL,");
                sql.Append("            HassIO_KEY)");
                sql.Append("  VALUES( ");
                sql.Append("          " + data.UserCode.Escape()).Append(", ");
                sql.Append("          " + data.UserPassword.Escape()).Append(", ");
                sql.Append("          " + data.UserName.Escape()).Append(", ");
                sql.Append("          " + data.APIKey.Escape()).Append(", ");
                sql.Append("          " + data.LocaltionName.Escape()).Append(", ");
                sql.Append("          " + data.Latitude.Escape()).Append(", ");
                sql.Append("          " + data.Longitude.Escape()).Append(", ");
                sql.Append("          " + data.HassIO_URL.Escape()).Append(", ");
                sql.Append("          " + data.HassIO_KEY.Escape()).Append(") ");
                int newId = baseDAO.DoInsert(connection, trans, sql.ToString());
                data.UserID = newId;
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
        public int DeleteUser(User data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM tb_user  ");
                sql.Append("  WHERE UserID = " + DatabaseUtility.Escape(data.UserID));
                return baseDAO.DoUpdate(sql.ToString());
            }
        }
        #region Utility
        private IList<User> MakeUsers(DataTable dt)
        {
            IList<User> list = new List<User>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MakeUser(row));
                }
            }
            return list;
        }
        private User MakeUser(DataRow row)
        {
            User record = new User();
            if (row != null)
            {
                record.SetProperty(row);
            }
            return record;
        }
        #endregion
    }
}
