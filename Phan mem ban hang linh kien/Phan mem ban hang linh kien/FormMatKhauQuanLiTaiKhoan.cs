using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_mem_ban_hang_linh_kien
{
    public partial class FormMatKhauQuanLiTaiKhoan : Form
    {
        public FormMatKhauQuanLiTaiKhoan()
        {
            InitializeComponent();
        }

        private void tbxXacNhanMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Main();
            }
        }

        private void btnXacNhanMatKhau_Click(object sender, EventArgs e)
        {
            Main();
        }

        private void Main()
        {
            if (tbxXacNhanMatKhau.Text == "uyendepzai")
            {
                using (FormQuanLiTaiKhoan form = new FormQuanLiTaiKhoan())
                {
                    this.Hide();
                    var result = form.ShowDialog();
                }
                this.Close();
            }
        }
    }
}
