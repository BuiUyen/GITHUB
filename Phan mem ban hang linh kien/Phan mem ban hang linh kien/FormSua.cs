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
    public partial class FormSua : Form
    {
        public int SoLuongPublic { get; set; }
        public int GiaPublic { get; set; }

        public FormSua(int soluong, int giaban)
        {
            SoLuongPublic = soluong;
            GiaPublic = giaban;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbxSoLuong.Text != "" & tbxGia.Text != "")
            {
                this.SoLuongPublic = Convert.ToInt32(tbxSoLuong.Text);
                this.GiaPublic = Convert.ToInt32(tbxGia.Text);
                this.Close();
            }
            else MessageBox.Show("Chưa điền thông tin thay đổi");
        }

        private void tbxGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }

        private void tbxGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbxSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }

        private void tbxSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void FormSua_Load(object sender, EventArgs e)
        {
            tbxSoLuong.Text = SoLuongPublic.ToString();
            tbxGia.Text = GiaPublic.ToString();
        }
    }
}
