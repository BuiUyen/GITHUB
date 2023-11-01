using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medibox.Service.Net;
using Medibox.Model;
using Sanita.Utility.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medibox.Model;
using Medibox.Presenter;
using Medibox.Utility;
using Sanita.Utility;
using System.Text.RegularExpressions;
using System.IO;

namespace Medibox.Tool
{
    public class UtilityThoCa
    {
        //Tag
        private const String TAG = "UtilityThoCa";

        //Singleton
        private static UtilityThoCa _instance;
        public static UtilityThoCa mInstance
        {
            get
            {
                _instance = _instance ?? new UtilityThoCa();
                return _instance;
            }
        }

        //Constructor
        public UtilityThoCa()
        {

        }

        public void UpdateData()
        {
            String root_folder = "D:\\ThiVien.Net";

            IList<String> list_group_tacgia = new List<String>();
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=50&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=52&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=53&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=54&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=55&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=56&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=57&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=2&Sort=Views&SortOrder=desc&Page=");
            list_group_tacgia.Add("https://www.thivien.net/searchauthor.php?Country=2&Age[]=3&Sort=Views&SortOrder=desc&Page=");

            foreach (String group_tacgia in list_group_tacgia)
            {
                for (int page = 1; page <= 10; page++)
                {
                    String url_group_tacgia = group_tacgia + page;
                    String data_group_tacgia = UtilityWeb.mInstance.GetData(url_group_tacgia);
                    if (!String.IsNullOrEmpty(data_group_tacgia))
                    {
                        data_group_tacgia = System.Net.WebUtility.HtmlDecode(data_group_tacgia);                        
                        if(data_group_tacgia.ToLower().Contains("Số trang không hợp lệ".ToLower()))
                        {
                            break;
                        }

                        //Lấy danh sách tác giả                        
                        {
                            String pattern = "list-item-header\"><a href=\"(?<Link>[^\"]+)\">(?<Name>[^<]+)<";
                            MatchCollection list_match = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase).Matches(data_group_tacgia);
                            foreach(Match match in list_match)
                            {
                                String link = match.Groups["Link"].Value;
                                String name = match.Groups["Name"].Value;
                                if(name.Contains("-"))
                                {
                                    name = name.Split('-')[0].Trim();
                                }

                                String folder = root_folder + "\\" + name;
                                Directory.CreateDirectory(folder);
                            }
                        }
                    }
                }
            }
        }
    }
}
