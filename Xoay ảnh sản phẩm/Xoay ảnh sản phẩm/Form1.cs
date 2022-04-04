namespace Xoay_ảnh_sản_phẩm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Boolean saveRotateImg(string path)
        {
            pictureBox1.ImageLocation = path; //path to image
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            string new_path1 = path.Replace(".jpg", "_xa(1).jpg");
            string new_path2 = path.Replace(".jpg", "_xa(2).jpg");

            using (Image image = Image.FromFile(path))
            {
                //rotate the picture by 90 degrees and re-save the picture as a Jpeg
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save the image to the new_path
                image.Save(new_path1, System.Drawing.Imaging.ImageFormat.Jpeg);

                pictureBox2.ImageLocation = new_path1; //path to image
                pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            }
            //System.IO.File.Delete(path);

            using (Image image = Image.FromFile(path))
            {
                //rotate the picture by 180 degrees and re-save the picture as a Jpeg
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                // Save the image to the new_path
                image.Save(new_path2, System.Drawing.Imaging.ImageFormat.Jpeg);

                pictureBox3.ImageLocation = new_path2; //path to image
                pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            }
            return true;
        }


        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txbFile.Text = openFileDialog.FileName;
                    saveRotateImg(openFileDialog.FileName);
                }
            }
        }
    }
}