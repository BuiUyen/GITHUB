using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public int SoLuongPublic { get; set; }

        public int x;
        public Form2(int soluong)
        {
            x = soluong;            
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SoLuongPublic = Convert.ToInt32(tbxSoLuong.Text);
            this.Close();
        }

        private void tbxSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
