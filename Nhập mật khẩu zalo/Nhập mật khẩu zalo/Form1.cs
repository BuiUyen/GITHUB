using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput.Native;
using WindowsInput;


namespace Nhập_mật_khẩu_zalo
{
    public partial class Form1 : Form
    {
        string mk;

        InputSimulator sim = new InputSimulator();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRUN_Click(object sender, EventArgs e)
        {
            sim.Keyboard.Sleep(5000);

            for(int i = 0; i < 9999;i++)
            {
                mk = i.ToString("0000");
                sim.Keyboard.TextEntry(mk);
                sim.Keyboard.Sleep(100);
            }
        }
    }
}