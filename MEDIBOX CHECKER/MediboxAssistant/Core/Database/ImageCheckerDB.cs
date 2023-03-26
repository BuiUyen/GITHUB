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
    public class ImageCheckerDB : BaseDB
    {
        //Constant
        private const String TAG = "ImageCheckerDB";
        //Singleton
        private static ImageCheckerDB _instance;
        public static ImageCheckerDB mInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ImageCheckerDB();
                }
                return _instance;
            }
        }
        public IList<ImageChecker> GetImageCheckers(IDbConnection connection, IDbTransaction trans)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_imagechecker ");
            DataTable dt = baseDAO.DoGetDataTable(connection, trans, sql.ToString());
            return (MakeImageCheckers(dt));
        }
        public ImageChecker GetImageChecker()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_imagechecker ");
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeImageChecker(row));
        }
        public ImageChecker GetImageChecker(int ImageID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM tb_imagechecker ");
            sql.Append(" WHERE ImageID = " + ImageID.Escape());
            DataRow row = baseDAO.DoGetDataRow(sql.ToString());
            return (MakeImageChecker(row));
        }
        public int UpdateImageChecker(IDbConnection connection, IDbTransaction trans, ImageChecker data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }

                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE tb_ImageChecker ");
                sql.Append("  SET  ");
                sql.Append("      Link = " + data.Link.Escape()).Append(", ");
                sql.Append("      Alt = " + data.Alt.Escape()).Append(", ");
                sql.Append("      CheckerCode = " + data.CheckerCode.Escape());
                sql.Append("  WHERE ImageID = " + data.ImageID);
                return baseDAO.DoUpdate(connection, trans, sql.ToString());
            }
        }
        public int InsertImageChecker(IDbConnection connection, IDbTransaction trans, ImageChecker data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO tb_imagechecker (");
                sql.Append("            Link,");
                sql.Append("            Alt,");
                sql.Append("            CheckerCode)");
                sql.Append("  VALUES( ");
                sql.Append("          " + data.Link.Escape()).Append(", ");
                sql.Append("          " + data.Alt.Escape()).Append(", ");
                sql.Append("          " + data.CheckerCode.Escape()).Append(") ");
                int newId = baseDAO.DoInsert(connection, trans, sql.ToString());
                data.ImageID = newId;
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
        public int DeleteImageChecker(ImageChecker data)
        {
            lock (lockObject)
            {
                if (data == null)
                {
                    return DataTypeModel.RESULT_NG;
                }
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM tb_imagechecker  ");
                sql.Append("  WHERE ImageID = " + DatabaseUtility.Escape(data.ImageID));
                return baseDAO.DoUpdate(sql.ToString());
            }
        }
        #region Utility
        private IList<ImageChecker> MakeImageCheckers(DataTable dt)
        {
            IList<ImageChecker> list = new List<ImageChecker>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MakeImageChecker(row));
                }
            }
            return list;
        }
        private ImageChecker MakeImageChecker(DataRow row)
        {
            ImageChecker record = new ImageChecker();
            if (row != null)
            {
                record.SetProperty(row);
            }
            return record;
        }
        #endregion
    }
}