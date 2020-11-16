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
    public class RoomDB : BaseDB
    {
        //Constant
        private const String TAG = "RoomDB";
        //Singleton
        private static RoomDB _instance;
        public static RoomDB mInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RoomDB();
                }
                return _instance;
            }
        }
        public IList<Room> GetRooms(IDbConnection connection, IDbTransaction trans)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_room ");
            DataTable dt = baseDAO.DoGetDataTable(connection, trans, sql.ToString());
            return (MakeRooms(dt));
        }

        public Room GetRoom()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_room ");
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeRoom(row));
        }

        public Room GetRoom(int RoomID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_room ");
            sql.Append(" WHERE RoomID = " + RoomID.Escape());
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeRoom(row));
        }

        public int UpdateRoom(IDbConnection connection, IDbTransaction trans, Room data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }

                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE tb_room ");
                sql.Append("  SET  ");
                sql.Append("      RoomName = " + data.RoomName.Escape()).Append(", ");
                sql.Append("      HomeID = " + data.HomeID.Escape()).Append(", ");
                sql.Append("      UserID = " + data.UserID.Escape());
                sql.Append("  WHERE RoomID = " + data.RoomID);
                return baseDAO.DoUpdate(connection, trans, sql.ToString());
            }
        }
        public int InsertRoom(IDbConnection connection, IDbTransaction trans, Room data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO tb_room (");
                sql.Append("            RoomName,");
                sql.Append("            HomeID,");
                sql.Append("            UserID)");
                sql.Append("  VALUES( ");
                sql.Append("          " + data.RoomName.Escape()).Append(", ");
                sql.Append("          " + data.HomeID.Escape()).Append(", ");
                sql.Append("          " + data.UserID.Escape()).Append(") ");
                int newId = baseDAO.DoInsert(connection, trans, sql.ToString());
                data.RoomID = newId;
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
        public int DeleteRoom(Room data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM tb_room  ");
                sql.Append("  WHERE RoomID = " + DatabaseUtility.Escape(data.RoomID));
                return baseDAO.DoUpdate(sql.ToString());
            }
        }
        #region Utility
        private IList<Room> MakeRooms(DataTable dt)
        {
            IList<Room> list = new List<Room>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MakeRoom(row));
                }
            }
            return list;
        }
        private Room MakeRoom(DataRow row)
        {
            Room record = new Room();
            if (row != null)
            {
                record.SetProperty(row);
            }
            return record;
        }
        #endregion
    }
}
