using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using System.Management;
using SharpDX.MediaFoundation;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace MultiFaceRec
{
    public partial class FrmPrincipal : Form
    {        
        Image<Bgr, Byte> currentFrame;
        Emgu.CV.Capture grabber;
        HaarCascade face;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.5d, 0.5d);        
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels= new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;

        List<string> ListNameWebCams = new List<string>();
        int camIndex = 0;

        public FrmPrincipal()
        {
            InitializeComponent();
            //Load file nguồn nhận diện gương mặt
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
                //Load các hình ảnh gương mặt đã được ghi nhớ
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels+1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }            
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show("Không có gương mặt lưu trong cơ sở dữ liệu (Thực hiện bằng cách ấn nút: Thêm Gương Mặt).", "Thông báo cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnChangeCamera_Click(object sender, EventArgs e)
        {
            camIndex++;
            if(camIndex == 5)
            {
                camIndex = 0;
            }    
        }

        private void btnAddFace_Click(object sender, EventArgs e)
        {
            try
            {
                ContTrain = ContTrain + 1;

                //Get a gray frame from capture device
                gray = grabber.QueryGrayFrame().Resize(320, 262, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));

                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);//lưu ảnh gương mặt
                trainingImages.Add(TrainedFace);
                labels.Add(textBox1.Text);

                //Hiển thị ảnh gương mặt đã được học
                imageBoxTraining.Image = TrainedFace.Resize(150, 150, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Số lượng khuôn mặt đã được nhận diện vào file TrainedLabels
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                //Điền tên và ảnh vào file
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }

                MessageBox.Show("Gương mặt của "+ textBox1.Text + " đã được thêm vào bộ nhớ!", "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Chưa nhận diện được gương mặt nào!!!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            //Khởi tạo thiết bị
            grabber = new Emgu.CV.Capture(camIndex);
            //grabber = new Emgu.CV.Capture(@"http://192.168.1.63:81/stream");
            grabber.QueryFrame();
            //Bắt đầu nhận diện gương mặt
            Application.Idle += new EventHandler(FrameGrabber);
            //btnDetect.Enabled = false;
        }

        void FrameGrabber(object sender, EventArgs e)
        {
            label3.Text = "0";
            //label4.Text = "";
            NamePersons.Add("");


            //Thay đổi khung video đầu vào
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            gray = currentFrame.Convert<Gray, Byte>();  //chuyển đổi màu xám
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2,20, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(10, 10));

            //nhận diện từng gương mặt
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //Vẽ khung nhận diện gương mặt
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


                if (trainingImages.ToArray().Length != 0)
                {
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                    //Nhận diện từng gương mặt
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                       labels.ToArray(),
                       3000,
                       ref termCrit);
                    name = recognizer.Recognize(result);

                    //Vẽ từng khung nhận diện gương mặt đã nhận diện
                    currentFrame.Draw(ConvertToUnsign(name), ref font, new System.Drawing.Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                }
                NamePersons[t - 1] = name;
                NamePersons.Add("");


                //Số lượng gương mặt đã nhận diện
                label3.Text = facesDetected[0].Length.ToString();                
            }
            t = 0;

            //Hiển thị tên người đã nhận diện
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
            }
            label4.Text = names;

            //Hiển thị video đã được xử lý
            imageBoxFrameGrabber.Image = currentFrame;
            names = "";
            
            NamePersons.Clear();
        }

        public string ConvertToUnsign(string strInput)
        {
            string result = strInput.ToLower();
            result = Regex.Replace(result, "à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|/g", "a");
            result = Regex.Replace(result, "è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|/g", "e");
            result = Regex.Replace(result, "ì|í|ị|ỉ|ĩ|/g", "i");
            result = Regex.Replace(result, "ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|/g", "o");
            result = Regex.Replace(result, "ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|/g", "u");
            result = Regex.Replace(result, "ỳ|ý|ỵ|ỷ|ỹ|/g", "y");
            result = Regex.Replace(result, "đ", "d");
            return result;
        }
    }
}