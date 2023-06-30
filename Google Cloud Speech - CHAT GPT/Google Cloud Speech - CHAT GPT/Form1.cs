namespace Google_Cloud_Speech___CHAT_GPT
{
    using Google.Cloud.Speech.V1;
    using System;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var speechClient = SpeechClient.Create();

            var config = new RecognitionConfig
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = "vi-VN"
            };

            var audio = RecognitionAudio.FromFile("C:/Users/huuuy/Downloads/1234.mp3");

            var response = speechClient.Recognize(config, audio);
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    MessageBox.Show($"Transcript: {alternative.Transcript}");
                }
            }

        }
    }
}