using Medibox.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Medibox.Tool
{
    public partial class Form_ThoCa_TacGia : Form
    {
        private IList<String> list_group_tacgia = new List<String>();
        private int index_group = 1;
        private int index_page = 0;
        private bool IsNext = true;

        public Form_ThoCa_TacGia()
        {
            InitializeComponent();

            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=50&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=52&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=53&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=54&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=55&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=56&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=57&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=2&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=3&Sort=Views&SortOrder=desc&Page=");

            mWeb.DocumentCompleted += mWeb_DocumentCompleted;
        }

        void mWeb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            String root_folder = "D:\\ThiVien.Net\\TacGia";

            String data_group_tacgia = mWeb.DocumentText;
            if (!String.IsNullOrEmpty(data_group_tacgia))
            {
                data_group_tacgia = System.Net.WebUtility.HtmlDecode(data_group_tacgia);
                if (data_group_tacgia.ToLower().Contains("Số trang không hợp lệ".ToLower()))
                {
                    index_page = 100;
                    IsNext = true;
                    return;
                }
                if (!data_group_tacgia.ToLower().Contains("Danh mục các tác giả".ToLower()))
                {
                    return;
                }

                //Lấy danh sách tác giả                        
                {
                    String pattern = "list-item-header\"><a href=\"(?<Link>[^\"]+)\">(?<Name>[^<]+)<";
                    MatchCollection list_match = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase).Matches(data_group_tacgia);
                    foreach (Match match in list_match)
                    {
                        String link = match.Groups["Link"].Value;
                        String name = match.Groups["Name"].Value;
                        if (name.Contains("-"))
                        {
                            name = name.Split('-')[0].Trim();
                        }

                        String path_file = root_folder + "\\" + name + ".txt";
                        File.WriteAllText(path_file, "https://www.thivien.net/" + link);
                    }
                }

                IsNext = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsNext = false;

            String group_tacgia = list_group_tacgia[index_group - 1];
            String url_group_tacgia = group_tacgia + index_page;
            mWeb.Url = new Uri(url_group_tacgia);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (index_group > 9)
            {
                return;
            }
            if (index_page > 10)
            {
                index_page = 1;
                index_group++;
            }
            else
            {
                index_page++;
            }
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
