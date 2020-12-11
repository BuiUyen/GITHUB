using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Lay_Du_Lieu_PageSource
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string fileName = @"D:\code.txt";
        public List<string> ListCode = new List<string>();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ListCode.Clear();
            try
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains(textBox1.Text))
                        {
                            string code = s.Trim();
                            //textBox2.Text = code;
                            ListCode.Add(code);
                        }

                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

            lbThongBao.Text = "Có " + ListCode.Count.ToString() + " kết quả.";
            if (ListCode.Count == 1)
            {
                textBox2.Text = ListCode[0];
            }
            else
            {
                textBox2.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            lbDemKiTu.Text = "Có: " + textBox3.Text.Length + " kí tự.";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbKetQua.Text = "=>" + ListCode[0].Substring(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text)) + "<=";
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbKetQua.Text = "=>" + ListCode[0].Substring(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text)) +"<=";
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}
