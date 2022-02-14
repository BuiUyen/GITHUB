using System;
using System.Collections.Generic;
using Sanita.Utility.Database.BaseDao;
using Sanita.Utility.Database.Utility;

namespace Medibox.Database
{
    public class MediboxDatabaseUtility
    {
        private const String TAG = "MediboxDatabaseUtility";
        private static DatabaseUtility mDatabaseUtility_Main = new DatabaseUtility();
        public static void InitDatabase()
        {
            mDatabaseUtility_Main.GetDatabaseImplementUtility().InitDatabase(GetDatabaseDAO(), InitTable());
        }
        public static IBaseDao GetDatabaseDAO()
        {
            return mDatabaseUtility_Main.GetDatabaseDAO();
        }
        public static DatabaseUtility GetDatabaseUtility()
        {
            return mDatabaseUtility_Main;
        }
        public static string GetDatabaseVersion()
        {
            return "20";
        }
        public static List<ClassTable> InitTable()
        {
            List<ClassTable> listFixTable = new List<ClassTable>();

            //#region tb_device
            //ClassTable tb_device = new ClassTable();
            //tb_device.Table = "tb_device";
            //{
            //    IList<ClassColumn> listColumn = new List<ClassColumn>();
            //    {
            //        ClassColumn Column = new ClassColumn();
            //        Column.ColumnName = "DeviceID";
            //        Column.ColumnDefine = " int(10) unsigned NOT NULL auto_increment ";
            //        Column.isPRIMARY = true;
            //        listColumn.Add(Column);
            //    }
            //    {
            //        ClassColumn Column = new ClassColumn();
            //        Column.ColumnName = "DeviceName";
            //        Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
            //        Column.isPRIMARY = false;
            //        listColumn.Add(Column);
            //    }
            //    {
            //        ClassColumn Column = new ClassColumn();
            //        Column.ColumnName = "DeviceName_Short";
            //        Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
            //        Column.isPRIMARY = false;
            //        listColumn.Add(Column);
            //    }
            //    {
            //        ClassColumn Column = new ClassColumn();
            //        Column.ColumnName = "DeviceCode";
            //        Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
            //        Column.isPRIMARY = false;
            //        listColumn.Add(Column);
            //    }
            //    {
            //        ClassColumn Column = new ClassColumn();
            //        Column.ColumnName = "Hass_Entity_ID";
            //        Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
            //        Column.isPRIMARY = false;
            //        listColumn.Add(Column);
            //    }
            //    {
            //        ClassColumn Column = new ClassColumn();
            //        Column.ColumnName = "DM_Hass_DeviceTypeID";
            //        Column.ColumnDefine = " int(10) DEFAULT '0' ";
            //        Column.isPRIMARY = false;
            //        listColumn.Add(Column);
            //    }
            //    {
            //        ClassColumn Column = new ClassColumn();
            //        Column.ColumnName = "RoomID";
            //        Column.ColumnDefine = " int(10) DEFAULT '0' ";
            //        Column.isPRIMARY = false;
            //        listColumn.Add(Column);
            //    }
            //    {
            //        ClassColumn Column = new ClassColumn();
            //        Column.ColumnName = "UserID";
            //        Column.ColumnDefine = " int(10) DEFAULT '0' ";
            //        Column.isPRIMARY = false;
            //        listColumn.Add(Column);
            //    }
            //    {
            //        ClassColumn Column = new ClassColumn();
            //        Column.ColumnName = "HomeID";
            //        Column.ColumnDefine = " int(10) DEFAULT '0' ";
            //        Column.isPRIMARY = false;
            //        listColumn.Add(Column);
            //    }
            //    {
            //        ClassColumn Column = new ClassColumn();
            //        Column.ColumnName = "Version";
            //        Column.ColumnDefine = " timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP ";
            //        Column.isPRIMARY = false;
            //        listColumn.Add(Column);
            //    }
            //    tb_device.listColumn = listColumn;
            //}
            //listFixTable.Add(tb_device);
            //#endregion

            #region tb_checker
            ClassTable tb_checker = new ClassTable();
            tb_checker.Table = "tb_checker";
            {
                IList<ClassColumn> listColumn = new List<ClassColumn>();
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "CheckerID";
                    Column.ColumnDefine = " int(10) unsigned NOT NULL auto_increment ";
                    Column.isPRIMARY = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Gia";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Ten";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "SDT";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "LinkAnh";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Version";
                    Column.ColumnDefine = " timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                tb_checker.listColumn = listColumn;
            }
            listFixTable.Add(tb_checker);
            #endregion

            return listFixTable;
        }
    }
}
