using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Viet_chu_vao_anh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Image bitmap = Bitmap.FromFile(@"D:\KHUNG SP.jpg");

            Graphics graphicsImage = Graphics.FromImage(bitmap);

            StringFormat stringformat1 = new StringFormat();
            stringformat1.Alignment = StringAlignment.Far;

            StringFormat stringformat2 = new StringFormat();
            stringformat2.Alignment = StringAlignment.Center;


            Color StringColor1 = ColorTranslator.FromHtml("#ff0000");
            Color StringColor2 = ColorTranslator.FromHtml("#ffffff");

            string Str_Text1OnImage = "Cường";
            string Str_Text2OnImage = "Minh Vũ Obit";

            graphicsImage.DrawString(Str_Text1OnImage, new Font("arail", 20, FontStyle.Regular), new SolidBrush(StringColor1), new Point(268, 245), stringformat1);

            graphicsImage.DrawString(Str_Text2OnImage, new Font("Cambria", 48, FontStyle.Bold), new SolidBrush(StringColor2), new Point(400, 10), stringformat2);


            bitmap.Save(@"D:\ket qua.jpg");            
        }
    }
}
