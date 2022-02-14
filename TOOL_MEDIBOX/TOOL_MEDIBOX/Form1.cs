using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOOL_MEDIBOX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class ThuocTinh
        {
            public string DuLieu { get; set; }
            public string TenThuocTinh { get; set; }
        }

        public string Model;
        public List<ThuocTinh> ListThuocTinh = new List<ThuocTinh>();

        private void tbxModel_TextChanged(object sender, EventArgs e)
        {
            Model = "";
            ListThuocTinh.Clear();

            foreach (string line in tbxModel.Lines)
            {
                string text = line.Trim();
                if (text.Contains("public class"))
                {
                    string[] arr = text.Split(' ');
                    Model = arr[2];
                }

                if (text.Contains("public") & text.Contains("get"))
                {
                    ThuocTinh _thuoctinh = new ThuocTinh();
                    string[] arr = text.Split(' ');
                    _thuoctinh.DuLieu = arr[1];
                    _thuoctinh.TenThuocTinh = arr[2];
                    ListThuocTinh.Add(_thuoctinh);
                }
            }

            if (Model == "" || ListThuocTinh.Count == 0)
            {
                MessageBox.Show("Chưa đủ dữ liệu model!!!");
            }
            else
            {
                #region DB
                StringBuilder DB = new StringBuilder();
                DB.AppendLine("public class " + Model + "DB : BaseDB");
                DB.AppendLine("{");
                DB.AppendLine("    //Constant");
                DB.AppendLine("    private const String TAG = \"" + Model + "DB\";");
                DB.AppendLine("    //Singleton");
                DB.AppendLine("    private static " + Model + "DB _instance;");
                DB.AppendLine("    public static " + Model + "DB mInstance");
                DB.AppendLine("    {");
                DB.AppendLine("        get");
                DB.AppendLine("        {");
                DB.AppendLine("            if (_instance == null)");
                DB.AppendLine("            {");
                DB.AppendLine("                _instance = new " + Model + "DB();");
                DB.AppendLine("            }");
                DB.AppendLine("            return _instance;");
                DB.AppendLine("        }");
                DB.AppendLine("    }");
                //-----------------------------------------------------------------------------------------------

                DB.AppendLine("    public IList<" + Model + "> Get" + Model + "s(IDbConnection connection, IDbTransaction trans)");
                DB.AppendLine("    {");
                DB.AppendLine("        StringBuilder sql = new StringBuilder();");
                DB.AppendLine("        sql.Append(\" SELECT * \");");
                DB.AppendLine("        sql.Append(\" FROM tb_" + Model.ToLower() + " \"); ");
                DB.AppendLine("        DataTable dt = baseDAO.DoGetDataTable(connection, trans, sql.ToString());");
                DB.AppendLine("        return (Make" + Model + "s(dt));");
                DB.AppendLine("    }");
                //-----------------------------------------------------------------------------------------------


                DB.AppendLine("    public " + Model + " Get" + Model + "()");
                DB.AppendLine("    {");
                DB.AppendLine("        StringBuilder sql = new StringBuilder();");
                DB.AppendLine("        sql.Append(\" SELECT * \");");
                DB.AppendLine("        sql.Append(\" FROM tb_" + Model.ToLower() + " \");");
                DB.AppendLine("        DataRow row = baseDAO.DoGetDataRow(sql.ToString());");
                DB.AppendLine("        return (Make" + Model + "(row));");
                DB.AppendLine("    }");
                //-----------------------------------------------------------------------------------------------


                DB.AppendLine("    public " + Model + " Get" + Model + "(int " + ListThuocTinh[0].TenThuocTinh + ")");
                DB.AppendLine("    {");
                DB.AppendLine("        StringBuilder sql = new StringBuilder();");
                DB.AppendLine("        sql.Append(\" SELECT * \");");
                DB.AppendLine("        sql.Append(\" FROM tb_" + Model.ToLower() + " \");");
                DB.AppendLine("        sql.Append(\" WHERE " + ListThuocTinh[0].TenThuocTinh + " = \" + " + ListThuocTinh[0].TenThuocTinh + ".Escape());");
                DB.AppendLine("        DataRow row = baseDAO.DoGetDataRow(sql.ToString());");
                DB.AppendLine("        return (Make" + Model + "(row));");
                DB.AppendLine("    }");
                //-----------------------------------------------------------------------------------------------


                DB.AppendLine("    public int Update" + Model + "(IDbConnection connection, IDbTransaction trans, " + Model + " data)");
                DB.AppendLine("    {");
                DB.AppendLine("        lock (lockObject)");
                DB.AppendLine("        {");
                DB.AppendLine("            if (data == null)");
                DB.AppendLine("            {");
                DB.AppendLine("                return DataTypeModel.RESULT_NG;");
                DB.AppendLine("            }");
                DB.AppendLine("    ");
                DB.AppendLine("            StringBuilder sql = new StringBuilder();");
                DB.AppendLine("            sql.Append(\" UPDATE tb_" + Model + " \");");
                DB.AppendLine("            sql.Append(\"  SET  \");");

                for (int i = 1; i < ListThuocTinh.Count; i++)
                {
                    if (ListThuocTinh[i].DuLieu == "string")
                    {
                        DB.Append("            sql.Append(\"      " + ListThuocTinh[i].TenThuocTinh + " = \" + data." + ListThuocTinh[i].TenThuocTinh + ".Escape())");
                    }

                    if (ListThuocTinh[i].DuLieu == "int")
                    {
                        DB.Append("            sql.Append(\"     " + ListThuocTinh[i].TenThuocTinh + " = \" + data." + ListThuocTinh[i].TenThuocTinh + ".Escape())");
                    }

                    if (i == ListThuocTinh.Count - 1)
                    {
                        DB.AppendLine(";");
                    }
                    else
                    {
                        DB.AppendLine(".Append(\", \");");
                    }
                }

                DB.AppendLine("            sql.Append(\"  WHERE " + ListThuocTinh[0].TenThuocTinh + " = \" + data." + ListThuocTinh[0].TenThuocTinh + ");");
                DB.AppendLine("            return baseDAO.DoUpdate(connection, trans, sql.ToString());");
                DB.AppendLine("        }");
                DB.AppendLine("    }");
                //-----------------------------------------------------------------------------------------------

                DB.AppendLine("    public int Insert" + Model + "(IDbConnection connection, IDbTransaction trans," + Model + " data)");
                DB.AppendLine("         {");
                DB.AppendLine("        lock (lockObject)");
                DB.AppendLine("        {");
                DB.AppendLine("            if (data == null)");
                DB.AppendLine("            {");
                DB.AppendLine("                return DataTypeModel.RESULT_NG;");
                DB.AppendLine("            }");
                DB.AppendLine("            StringBuilder sql = new StringBuilder();");
                DB.AppendLine("            sql.Append(\" INSERT INTO tb_" + Model.ToLower() + " (\");");
                for (int i = 1; i < ListThuocTinh.Count; i++)
                {
                    DB.Append("            sql.Append(\"            " + ListThuocTinh[i].TenThuocTinh);
                    if (i == ListThuocTinh.Count - 1)
                    {
                        DB.AppendLine(")\"); ");
                    }
                    else
                    {
                        DB.AppendLine(",\"); ");
                    }
                }

                DB.AppendLine("            sql.Append(\"  VALUES( \");");

                for (int i = 1; i < ListThuocTinh.Count; i++)
                {
                    DB.Append("            sql.Append(\"          \" + data." + ListThuocTinh[i].TenThuocTinh + ".Escape()).Append(\"");
                    if (i == ListThuocTinh.Count - 1)
                    {
                        DB.AppendLine(") \"); ");
                    }
                    else
                    {
                        DB.AppendLine(", \");");
                    }
                }
                DB.AppendLine("            int newId = baseDAO.DoInsert(connection, trans, sql.ToString());");
                DB.AppendLine("            data." + ListThuocTinh[0].TenThuocTinh + " = newId;");
                DB.AppendLine("            if (newId > 0)");
                DB.AppendLine("            {");
                DB.AppendLine("                return newId;");
                DB.AppendLine("            }");
                DB.AppendLine("            else");
                DB.AppendLine("            {");
                DB.AppendLine("                return DataTypeModel.RESULT_NG;");
                DB.AppendLine("            }");
                DB.AppendLine("        }");
                DB.AppendLine("    }");
                //-----------------------------------------------------------------------------------------------

                DB.AppendLine("    public int Delete" + Model + "(" + Model + " data)");
                DB.AppendLine("    {");
                DB.AppendLine("        lock (lockObject)");
                DB.AppendLine("        {");
                DB.AppendLine("            if (data == null)");
                DB.AppendLine("            {");
                DB.AppendLine("                return DataTypeModel.RESULT_NG;");
                DB.AppendLine("            }");
                DB.AppendLine("            StringBuilder sql = new StringBuilder();");
                DB.AppendLine("            sql.Append(\" DELETE FROM tb_" + Model.ToLower() + "  \");");
                DB.AppendLine("            sql.Append(\"  WHERE " + ListThuocTinh[0].TenThuocTinh + " = \" + DatabaseUtility.Escape(data." + ListThuocTinh[0].TenThuocTinh + "));");
                DB.AppendLine("            return baseDAO.DoUpdate(sql.ToString());");
                DB.AppendLine("        }");
                DB.AppendLine("    }");
                //-----------------------------------------------------------------------------------------------

                DB.AppendLine("    #region Utility");
                DB.AppendLine("    private IList<" + Model + "> Make" + Model + "s(DataTable dt)");
                DB.AppendLine("    {");
                DB.AppendLine("        IList <" + Model + "> list = new List<" + Model + ">();");
                DB.AppendLine("        if (dt != null)");
                DB.AppendLine("        {");
                DB.AppendLine("            foreach (DataRow row in dt.Rows)");
                DB.AppendLine("            {");
                DB.AppendLine("                list.Add(Make" + Model + "(row));");
                DB.AppendLine("            }");
                DB.AppendLine("        }");
                DB.AppendLine("        return list;");
                DB.AppendLine("    }");
                DB.AppendLine("    private " + Model + " Make" + Model + "(DataRow row)");
                DB.AppendLine("    {");
                DB.AppendLine("        " + Model + " record = new " + Model + "();");
                DB.AppendLine("        if (row != null)");
                DB.AppendLine("        {");
                DB.AppendLine("            record.SetProperty(row);");
                DB.AppendLine("        }");
                DB.AppendLine("        return record;");
                DB.AppendLine("    }");
                DB.AppendLine("    #endregion");
                DB.AppendLine("}");
                DB.AppendLine("}");
                tbxDB.Text = DB.ToString();
                #endregion

                #region Presenter
                StringBuilder Presenter = new StringBuilder();
                Presenter.AppendLine("    ");
                Presenter.AppendLine("    public class " + Model + "Presenter : BasePresenter");
                Presenter.AppendLine("    {");
                Presenter.AppendLine("        private const String TAG = \"" + Model + "Presenter\";");
                Presenter.AppendLine("        public static IList<" + Model + "> Get" + Model + "s()");
                Presenter.AppendLine("        {");
                Presenter.AppendLine("        return " + Model + "DB.mInstance.Get" + Model + "s();");
                Presenter.AppendLine("        }");
                Presenter.AppendLine("        ");
                Presenter.AppendLine("        public static " + Model + " Get" + Model + "()");
                Presenter.AppendLine("        {");
                Presenter.AppendLine("        return " + Model + "DB.mInstance.Get" + Model + "();");
                Presenter.AppendLine("        }");
                Presenter.AppendLine("        ");
                Presenter.AppendLine("        public static " + Model + " Get" + Model + "(int " + ListThuocTinh[0].TenThuocTinh + ")");
                Presenter.AppendLine("        {");
                Presenter.AppendLine("        return " + Model + "DB.mInstance.Get" + Model + "(" + ListThuocTinh[0].TenThuocTinh + ");");
                Presenter.AppendLine("        }");
                Presenter.AppendLine("        public static void Update" + Model + "(" + Model + " data)");
                Presenter.AppendLine("        {");
                Presenter.AppendLine("        " + Model + "DB.mInstance.Update" + Model + "(null, null, data);");
                Presenter.AppendLine("        }");
                Presenter.AppendLine("        ");
                Presenter.AppendLine("        public static void Insert" + Model + "(" + Model + " data)");
                Presenter.AppendLine("        {");
                Presenter.AppendLine("        " + Model + "DB.mInstance.Insert" + Model + "(null, null, data);");
                Presenter.AppendLine("        }");
                Presenter.AppendLine("        ");
                Presenter.AppendLine("        public static int Delete" + Model + "(" + Model + " data)");
                Presenter.AppendLine("        {");
                Presenter.AppendLine("        return " + Model + "DB.mInstance.Delete" + Model + "(data);");
                Presenter.AppendLine("        }");
                Presenter.AppendLine("    }");
                tbxPresenter.Text = Presenter.ToString();
                #endregion


                #region MediboxDatabaseUtility
                StringBuilder Utility = new StringBuilder();
                Utility.AppendLine("    #region tb_" + Model.ToLower() + "");
                Utility.AppendLine("    ClassTable tb_" + Model.ToLower() + " = new ClassTable();");
                Utility.AppendLine("    tb_" + Model.ToLower() + ".Table = \"tb_" + Model.ToLower() + "\";");
                Utility.AppendLine("    {");
                Utility.AppendLine("        IList <ClassColumn> listColumn = new List<ClassColumn>();");

                for (int i = 0; i < ListThuocTinh.Count; i++)
                {
                    Utility.AppendLine("    {");
                    Utility.AppendLine("        ClassColumn Column = new ClassColumn();");
                    if(i==0)
                    {
                        Utility.AppendLine("        Column.ColumnName = \"" + ListThuocTinh[0].TenThuocTinh + "\";");
                        Utility.AppendLine("        Column.ColumnDefine = \" int(10) unsigned NOT NULL auto_increment \";");
                        Utility.AppendLine("        Column.isPRIMARY = true;");
                    }
                    else
                    {
                        Utility.AppendLine("        Column.ColumnName = \"" + ListThuocTinh[i].TenThuocTinh + "\";");
                        string define = "";
                        switch (ListThuocTinh[i].DuLieu)
                        {
                            case "string":
                                define = " text CHARACTER SET utf8 COLLATE utf8_unicode_ci ";
                                break;
                            case "int":
                                define = " int(10) DEFAULT '0' ";
                                break;
                            default:
                                break;
                        }
                        Utility.AppendLine("        Column.ColumnDefine = \"" + define + "\"; ");
                        Utility.AppendLine("        Column.isPRIMARY = false;");
                    }
                    Utility.AppendLine("        listColumn.Add(Column);");
                    Utility.AppendLine("    }");
                }

                Utility.AppendLine("    {");
                Utility.AppendLine("        ClassColumn Column = new ClassColumn();");
                Utility.AppendLine("        Column.ColumnName = \"Version\";");
                Utility.AppendLine("        Column.ColumnDefine = \" timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP \";");
                Utility.AppendLine("        Column.isPRIMARY = false;");
                Utility.AppendLine("        listColumn.Add(Column);");
                Utility.AppendLine("    }");
                Utility.AppendLine("    tb_" + Model.ToLower() + ".listColumn = listColumn;");
                Utility.AppendLine("    }");
                Utility.AppendLine("    listFixTable.Add(tb_" + Model.ToLower() + ");");
                Utility.AppendLine("    #endregion");

                tbxUtility.Text = Utility.ToString();
                #endregion
            }
        }
    }
}