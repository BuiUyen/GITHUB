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

namespace TEST_Conect_POSTGRESS_SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Connection information
            string connInfo = string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                            tbxDiaChiMayChu.Text, 5432, tbxTenDangNhap.Text, tbxMatKhau.Text, tbxTenCoSoDuLieu.Text);

            // Connection
            NpgsqlConnection conn = null;

            try
            {
                // Initialization
                conn = new NpgsqlConnection(connInfo);

                // Open connection
                conn.Open();

                MessageBox.Show("Successfully connected to PostgreSQL.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to PostgreSQL. Error: " + ex.Message);
            }
            finally
            {
                // Close connection
                if (null != conn)
                {
                    conn.Close();

                }
            }
        }
    }
}
