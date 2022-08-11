using Medibox.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sanita.Utility.Logger;

namespace Medibox.Tool
{
    public partial class Form_ThoCa_BaiTho : Form
    {
        private IList<String> list_group_tacgia = new List<String>();
        private int index_group = 0;
        private String ten_tac_gia = "";
        private bool IsNext = true;

        public Form_ThoCa_BaiTho()
        {
            InitializeComponent();

            list_group_tacgia = Directory.GetFiles("D:\\ThiVien.Net\\TacGia");
            mWeb.DocumentCompleted += mWeb_DocumentCompleted;
        }

        void mWeb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            SanitaLog.d("Form_ThoCa_BaiTho", "mWeb_DocumentCompleted");

            String data_group_tacgia = mWeb.DocumentText;
            if (!String.IsNullOrEmpty(data_group_tacgia))
            {
                data_group_tacgia = System.Net.WebUtility.HtmlDecode(data_group_tacgia);
                if (!data_group_tacgia.ToLower().Contains("Nước:".ToLower()) && !data_group_tacgia.ToLower().Contains("poem - group - list".ToLower()))
                {
                    return;
                }

                //Lấy danh sách tác phẩm                        
                {
                    String pattern = "<a href=\"(?<Link1>[^\"]+)(/poem-)(?<Link2>[^\"]+)\">(?<Name>[^<]+)<";
                    MatchCollection list_match = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase).Matches(data_group_tacgia);

                    foreach (Match match in list_match)
                    {
                        String link = match.Groups["Link1"].Value + "/poem-" + match.Groups["Link2"].Value;
                        String name = match.Groups["Name"].Value;

                        name = name.Replace("?", "");
                        name = name.Replace("<", "");
                        name = name.Replace(">", "");
                        name = name.Replace("/", "");
                        name = name.Replace("\\", "");
                        name = name.Replace("#", "");
                        name = name.Replace(":", "");

                        SanitaLog.d("Form_ThoCa_BaiTho", "ten_tac_gia = " + ten_tac_gia);
                        SanitaLog.d("Form_ThoCa_BaiTho", "ten_tac_pham = " + name);

                        try
                        {
                            String path_file = "D:\\ThiVien.Net\\TacPham\\" + ten_tac_gia + "+++" + name + ".txt";
                            File.WriteAllText(path_file, "https://www.thivien.net/" + link);
                        }
                        catch (Exception ex)
                        {
                            SanitaLog.d("Form_ThoCa_BaiTho", ex.Message);
                            IsNext = false;
                            return;
                        }
                    }
                }

                IsNext = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsNext = false;

            String group_tacgia = list_group_tacgia[index_group - 1];
            String url_group_tacgia = File.ReadAllText(group_tacgia);

            String file_name_simple = new FileInfo(list_group_tacgia[index_group - 1]).Name;
            ten_tac_gia = file_name_simple.Replace(".txt", "");

            SanitaLog.d("Form_ThoCa_BaiTho", "index_group = " + index_group);

            mWeb.Url = new Uri(url_group_tacgia);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (index_group > list_group_tacgia.Count)
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
