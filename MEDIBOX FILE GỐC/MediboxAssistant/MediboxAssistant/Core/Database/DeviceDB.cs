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
    public class DeviceDB : BaseDB
    {
        //Constant
        private const String TAG = "DeviceDB";
        //Singleton
        private static DeviceDB _instance;
        public static DeviceDB mInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DeviceDB();
                }
                return _instance;
            }
        }
        public IList<Device> GetDevices(IDbConnection connection, IDbTransaction trans)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_device ");
            DataTable dt = baseDAO.DoGetDataTable(connection, trans, sql.ToString());
            return (MakeDevices(dt));
        }

        public IList<Device> GetDevices_List(IDbConnection connection, IDbTransaction trans, int UserID, int RoomID, int HomeID)
        {
            IList<String> ListWhere = new List<String>();
            if (UserID > 0)
            {
                ListWhere.Add(String.Format(" UserID = {0}", UserID.Escape()));
            }
            if (RoomID > 0)
            {
                ListWhere.Add(String.Format(" RoomID = {0}", RoomID.Escape()));
            }
            if (HomeID > 0)
            {
                ListWhere.Add(String.Format(" HomeID = {0}", HomeID.Escape()));
            }

            if (ListWhere.Count == 0)
            {
                return new List<Device>();
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_device ");
            sql.Append(" WHERE  " + String.Join(" AND ", ListWhere));
            DataTable dt = baseDAO.DoGetDataTable(connection, trans, sql.ToString());
            return (MakeDevices(dt));
        }

        public Device GetDevice()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_device ");
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeDevice(row));
        }

        public Device GetDevice(int DeviceID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_device ");
            sql.Append(" WHERE DeviceID = " + DeviceID.Escape());
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeDevice(row));
        }

        public Device GetDevice(String DeviceCode)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_device ");
            sql.Append(" WHERE DeviceCode = " + DeviceCode.Escape());
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeDevice(row));
        }

        public int UpdateDevice(IDbConnection connection, IDbTransaction trans, Device data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }

                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE tb_device ");
                sql.Append("  SET  ");
                sql.Append("      DeviceName = " + data.DeviceName.Escape()).Append(", ");
                sql.Append("      DeviceName_Short = " + data.DeviceName_Short.Escape()).Append(", ");
                sql.Append("      DeviceCode = " + data.DeviceCode.Escape()).Append(", ");
                sql.Append("      RoomID = " + data.RoomID.Escape()).Append(", ");
                sql.Append("      UserID = " + data.UserID.Escape()).Append(", ");

                sql.Append("      Hass_Entity_ID = " + data.Hass_Entity_ID.Escape()).Append(", ");
                sql.Append("      DM_Hass_DeviceTypeID = " + data.DM_Hass_DeviceTypeID.Escape()).Append(", ");

                sql.Append("      HomeID = " + data.HomeID.Escape());
                sql.Append("  WHERE DeviceID = " + data.DeviceID);
                return baseDAO.DoUpdate(connection, trans, sql.ToString());
            }
        }
        public int InsertDevice(IDbConnection connection, IDbTransaction trans, Device data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO tb_device (");
                sql.Append("            DeviceName,");
                sql.Append("            DeviceName_Short,");
                sql.Append("            DeviceCode,");
                sql.Append("            RoomID,");
                sql.Append("            UserID,");

                sql.Append("            Hass_Entity_ID,");
                sql.Append("            DM_Hass_DeviceTypeID,");

                sql.Append("            HomeID)");
                sql.Append("  VALUES( ");
                sql.Append("          " + data.DeviceName.Escape()).Append(", ");
                sql.Append("          " + data.DeviceName_Short.Escape()).Append(", ");
                sql.Append("          " + data.DeviceCode.Escape()).Append(", ");
                sql.Append("          " + data.RoomID.Escape()).Append(", ");
                sql.Append("          " + data.UserID.Escape()).Append(", ");

                sql.Append("          " + data.Hass_Entity_ID.Escape()).Append(", ");
                sql.Append("          " + data.DM_Hass_DeviceTypeID.Escape()).Append(", ");

                sql.Append("          " + data.HomeID.Escape()).Append(") ");
                int newId = baseDAO.DoInsert(connection, trans, sql.ToString());
                data.DeviceID = newId;
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
        public int DeleteDevice(Device data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM tb_device  ");
                sql.Append("  WHERE DeviceID = " + DatabaseUtility.Escape(data.DeviceID));
                return baseDAO.DoUpdate(sql.ToString());
            }
        }
        #region Utility
        private IList<Device> MakeDevices(DataTable dt)
        {
            IList<Device> list = new List<Device>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MakeDevice(row));
                }
            }
            return list;
        }
        private Device MakeDevice(DataRow row)
        {
            Device record = new Device();
            if (row != null)
            {
                record.SetProperty(row);
            }
            return record;
        }
        #endregion
    }
}
