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
                line.Trim();
                if (line.Contains("public class"))
                {
                    string[] arr = line.Split(' ');
                    Model = arr[2];
                }

                if (line.Contains("public") & line.Contains("get"))
                {
                    ThuocTinh _thuoctinh = new ThuocTinh();
                    string[] arr = line.Split(' ');
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

                for(int i = 1; i < ListThuocTinh.Count ; i++)
                {
                    if(ListThuocTinh[i].DuLieu == "string")
                    {
                        DB.AppendLine("            sql.Append(\"      IntentName = \" + data.IntentName.Escape())");
                    }

                    if (ListThuocTinh[i].DuLieu == "int")
                    {
                        DB.AppendLine("            sql.Append(\"      DM_Intent_TypeID = \" + data.DM_Intent_TypeID.Escape())");
                    }

                    if ( i == ListThuocTinh.Count -1)
                    {
                        DB.Append(";");
                    }
                    else
                    {
                        DB.Append(".Append(\", \");");
                    }
                }

                DB.AppendLine("            sql.Append(\"  WHERE " + ListThuocTinh[0].TenThuocTinh + " = \" + data.IntentID);");
                DB.AppendLine("            return baseDAO.DoUpdate(connection, trans, sql.ToString());");
                DB.AppendLine("        }");
                DB.AppendLine("    }");


                DB.AppendLine("    ");
                DB.AppendLine("    ");
                DB.AppendLine("    ");
                DB.AppendLine("    ");
                DB.AppendLine("    ");
                DB.AppendLine("    ");
                DB.AppendLine("    ");
                DB.AppendLine("    ");
                DB.AppendLine("    ");
                tbxDB.Text = DB.ToString();

            }
        }
    }
}
