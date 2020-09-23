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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnQuanLiTaiKhoan_Click(object sender, EventArgs e)
        {
            using (FormMatKhauQuanLiTaiKhoan form = new FormMatKhauQuanLiTaiKhoan())
            {
                var result = form.ShowDialog();
            }            
        }
    }
}
