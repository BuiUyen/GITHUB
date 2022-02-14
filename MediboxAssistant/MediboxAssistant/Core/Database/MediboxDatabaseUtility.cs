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

            #region tb_room
            ClassTable tb_room = new ClassTable();
            tb_room.Table = "tb_room";
            {
                IList<ClassColumn> listColumn = new List<ClassColumn>();
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "RoomID";
                    Column.ColumnDefine = " int(10) unsigned NOT NULL auto_increment ";
                    Column.isPRIMARY = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "RoomName";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "HomeID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "UserID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
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
                tb_room.listColumn = listColumn;
            }
            listFixTable.Add(tb_room);
            #endregion

            #region tb_home
            ClassTable tb_home = new ClassTable();
            tb_home.Table = "tb_home";
            {
                IList<ClassColumn> listColumn = new List<ClassColumn>();
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "HomeID";
                    Column.ColumnDefine = " int(10) unsigned NOT NULL auto_increment ";
                    Column.isPRIMARY = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "HomeName";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "UserID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
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
                tb_home.listColumn = listColumn;
            }
            listFixTable.Add(tb_home);
            #endregion

            #region tb_user
            ClassTable tb_user = new ClassTable();
            tb_user.Table = "tb_user";
            {
                IList<ClassColumn> listColumn = new List<ClassColumn>();
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "UserID";
                    Column.ColumnDefine = " int(10) unsigned NOT NULL auto_increment ";
                    Column.isPRIMARY = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "UserCode";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "UserName";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "UserPassword";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "APIKey";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "LocaltionName";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Latitude";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Longitude";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "HassIO_URL";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "HassIO_KEY";
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
                tb_user.listColumn = listColumn;
            }
            listFixTable.Add(tb_user);
            #endregion

            #region tb_softupdate
            ClassTable tb_softupdate = new ClassTable();
            tb_softupdate.Table = "tb_softupdate";
            {
                IList<ClassColumn> listColumn = new List<ClassColumn>();
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "SoftUpdateID";
                    Column.ColumnDefine = " int(10) unsigned NOT NULL auto_increment ";
                    Column.isPRIMARY = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "SoftUpdateVersion";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "SoftUpdateSQL";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "SoftUpdateData";
                    Column.ColumnDefine = " longblob ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "SoftUpdateSize";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "SoftUpdateUser";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "SoftUpdateTime";
                    Column.ColumnDefine = " datetime ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "SoftUpdateKey";
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
                tb_softupdate.listColumn = listColumn;
            }
            listFixTable.Add(tb_softupdate);
            #endregion

            #region tb_dm_entity_type
            ClassTable tb_dm_entity_type = new ClassTable();
            tb_dm_entity_type.Table = "tb_dm_entity_type";
            {
                IList<ClassColumn> listColumn = new List<ClassColumn>();
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Entity_TypeDBID";
                    Column.ColumnDefine = " int(10) unsigned NOT NULL auto_increment ";
                    Column.isPRIMARY = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Entity_TypeID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Intent_TypeID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Entity_TypeName";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Entity_TypeHardcode";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Entity_TypeDisable";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
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
                tb_dm_entity_type.listColumn = listColumn;
            }
            listFixTable.Add(tb_dm_entity_type);
            #endregion

            #region tb_dm_intent_type
            ClassTable tb_dm_intent_type = new ClassTable();
            tb_dm_intent_type.Table = "tb_dm_intent_type";
            {
                IList<ClassColumn> listColumn = new List<ClassColumn>();
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Intent_TypeDBID";
                    Column.ColumnDefine = " int(10) unsigned NOT NULL auto_increment ";
                    Column.isPRIMARY = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Intent_TypeID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Intent_TypeName";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Intent_TypeHardcode";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Intent_TypeDisable";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
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
                tb_dm_intent_type.listColumn = listColumn;
            }
            listFixTable.Add(tb_dm_intent_type);
            #endregion

            #region tb_intent_response
            ClassTable tb_intent_response = new ClassTable();
            tb_intent_response.Table = "tb_intent_response";
            {
                IList<ClassColumn> listColumn = new List<ClassColumn>();
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Intent_ResponseID";
                    Column.ColumnDefine = " int(10) unsigned NOT NULL auto_increment ";
                    Column.isPRIMARY = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "IntentID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isIndex = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Intent_TypeID";
                    Column.ColumnDefine = " int(10)";
                    Column.isIndex = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Entity_TypeID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isIndex = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Data";
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
                tb_intent_response.listColumn = listColumn;
            }
            listFixTable.Add(tb_intent_response);
            #endregion

            #region tb_intent
            ClassTable tb_intent = new ClassTable();
            tb_intent.Table = "tb_intent";
            {
                IList<ClassColumn> listColumn = new List<ClassColumn>();
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "IntentID";
                    Column.ColumnDefine = " int(10) unsigned NOT NULL auto_increment ";
                    Column.isPRIMARY = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "IntentName";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Intent_TypeID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
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
                tb_intent.listColumn = listColumn;
            }
            listFixTable.Add(tb_intent);
            #endregion

            #region tb_device
            ClassTable tb_device = new ClassTable();
            tb_device.Table = "tb_device";
            {
                IList<ClassColumn> listColumn = new List<ClassColumn>();
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DeviceID";
                    Column.ColumnDefine = " int(10) unsigned NOT NULL auto_increment ";
                    Column.isPRIMARY = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DeviceName";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DeviceName_Short";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DeviceCode";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Hass_Entity_ID";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Hass_DeviceTypeID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "RoomID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "UserID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "HomeID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
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
                tb_device.listColumn = listColumn;
            }
            listFixTable.Add(tb_device);
            #endregion

            #region tb_intent_request
            ClassTable tb_intent_request = new ClassTable();
            tb_intent_request.Table = "tb_intent_request";
            {
                IList<ClassColumn> listColumn = new List<ClassColumn>();
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Intent_RequestID";
                    Column.ColumnDefine = " int(10) unsigned NOT NULL auto_increment ";
                    Column.isPRIMARY = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "IntentID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isIndex = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Intent_TypeID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isIndex = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DM_Entity_TypeID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isIndex = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Current_DM_Intent_TypeID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isIndex = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Current_DM_Entity_TypeID";
                    Column.ColumnDefine = " int(10) DEFAULT '0' ";
                    Column.isIndex = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Data";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Data_Query";
                    Column.ColumnDefine = " tsquery ";
                    Column.isIndex = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Version";
                    Column.ColumnDefine = " timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                tb_intent_request.listColumn = listColumn;
            }
            listFixTable.Add(tb_intent_request);
            #endregion

            #region tb_sanphamweb
            ClassTable tb_sanphamweb = new ClassTable();
            tb_sanphamweb.Table = "tb_sanphamweb";
            {
                IList<ClassColumn> listColumn = new List<ClassColumn>();
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "SanPhamWebID";
                    Column.ColumnDefine = " int(10) unsigned NOT NULL auto_increment ";
                    Column.isPRIMARY = true;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Alias";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "TenSanPham";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "NoiDung";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "NhaCungCap";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Loai";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Tag";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "HienThi";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "ThuocTinh";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "GiaTriThuocTinh";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "ThuocTinh2";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "GiaTriThuocTinh2";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "ThuocTinh3";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "GiaTriThuocTinh3";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "SKU";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "QuanLyKho";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "SoLuong";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "ChoPhepBan";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "Variant";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
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
                    Column.ColumnName = "GiaSoSanh";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "YeuCauVanChuyen";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "VAT";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "MaVach";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "AnhDaiDien";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "ChuThich";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "TheTieuDe";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "TheMoTa";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "CanNang";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "DonViCan";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "AnhPhienBan";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "MoTaNgan";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "ID";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "IDTuyChon";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "TenPhienBan";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "MaNganhSenDo";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "ThongSo";
                    Column.ColumnDefine = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                    Column.isPRIMARY = false;
                    listColumn.Add(Column);
                }
                {
                    ClassColumn Column = new ClassColumn();
                    Column.ColumnName = "CongDung";
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
                tb_sanphamweb.listColumn = listColumn;
            }
            listFixTable.Add(tb_sanphamweb);
            #endregion

            return listFixTable;
        }
    }
}
