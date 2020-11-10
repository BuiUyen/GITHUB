using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viet_Hoa_Chu_Cai_Dau
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChuyenDoi_Click(object sender, EventArgs e)
        {
            tbxOutput.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tbxInput.Text);
        }

        private string ToUpperFirstLetter(string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            // convert to char array of the string 
            char[] letters = source.ToCharArray();
            // upper case the first char 
            letters[0] = char.ToUpper(letters[0]);
            // return the array made of the new char array 
            return new string(letters);
        }
    }
}
