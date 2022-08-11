using Medibox.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sanita.Utility.Logger;

namespace Medibox.Tool
{
    public partial class Form_ThoCa_BaiThoChiTiet : Form
    {
        private IList<String> list_danh_sach_tac_pham = new List<String>();
        private int index_group = 194;
        private String ten_tac_gia_tac_pham = "";
        private String ten_tac_pham = "";
        private bool IsNext = true;

        public Form_ThoCa_BaiThoChiTiet()
        {
            InitializeComponent();

            list_danh_sach_tac_pham = Directory.GetFiles("D:\\ThiVien.Net\\TacPham");
            mWeb.DocumentCompleted += mWeb_DocumentCompleted;
        }

        void mWeb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            String data_group_tacgia = mWeb.DocumentText;
            if (!String.IsNullOrEmpty(data_group_tacgia))
            {
                data_group_tacgia = System.Net.WebUtility.HtmlDecode(data_group_tacgia);
                if (!data_group_tacgia.ToLower().Contains("poem-content".ToLower()))
                {
                    return;
                }

                //Lấy danh sách tác phẩm                        
                {
                    IList<String> list_pattern = new List<String>();
                    list_pattern.Add("<h4><strong>" + ten_tac_pham + "</strong></h4>(?<NoiDung>.*?)</div>");
                    list_pattern.Add("<div class=\"poem-content\">(?<NoiDung>.*?)</div>");

                    bool IsOk = false;
                    foreach(String pattern in list_pattern)
                    {                        
                        Match match = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase).Match(data_group_tacgia);
                        if (match != null && match.Success)
                        {
                            String name = match.Groups["NoiDung"].Value;

                            try
                            {
                                String path_file = "D:\\ThiVien.Net\\TacPhamChiTiet\\" + ten_tac_gia_tac_pham + ".txt";
                                File.WriteAllText(path_file, name);
                                IsOk = true;
                                break;
                            }
                            catch (Exception ex)
                            {
                                SanitaLog.d("Form_ThoCa_BaiThoChiTiet", ex.Message);
                                return;
                            }
                        }
                    }
                    if(!IsOk)
                    {
                        SanitaLog.d("Form_ThoCa_BaiThoChiTiet", "Parse failed : " + mWeb.Url);                        
                        MessageBox.Show("Lỗi không xử lý được data, index = " + index_group);
                        return;
                    }
                }

                IsNext = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsNext = false;

            String group_tac_pham = list_danh_sach_tac_pham[index_group - 1];
            String url_group_tacgia = File.ReadAllText(group_tac_pham);

            String file_name_simple = new FileInfo(group_tac_pham).Name;
            ten_tac_gia_tac_pham = file_name_simple.Replace(".txt", "");
            IList<String> list_ten_tac_pham = ten_tac_gia_tac_pham.Split(new string[] { "+++" }, StringSplitOptions.None);
            ten_tac_pham = list_ten_tac_pham[1];

            SanitaLog.d("Form_ThoCa_BaiThoChiTiet", "index_group = " + index_group);

            mWeb.Url = new Uri(url_group_tacgia);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (index_group > list_danh_sach_tac_pham.Count)
            {
                return;
            }

            index_group++;

            btnAdd_Click(null, null);
        }

        private void CurrentTimer_Tick(object sender, EventArgs e)
        {
            if (IsNext)
            {
                btnNext_Click(null, null);
            }
        }
    }
}
