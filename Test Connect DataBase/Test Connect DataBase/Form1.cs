using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Test_Connect_DataBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var cs = "Host = " + tbxID.Text + ";Username = postgres;Password=230798;Database=postgres";
                var con = new NpgsqlConnection(cs);
                con.Open();
                var sql = "SELECT version()";
                var cmd = new NpgsqlCommand(sql, con);
                var version = cmd.ExecuteScalar().ToString();
                MessageBox.Show($"PostgreSQL version: {version}");
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối!");
            }
        }
    }
}
