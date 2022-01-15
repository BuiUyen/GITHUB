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

namespace Medibox.Command
{
    public class Command_WIKI : ICommand
    {
        //Singleton
        private static Command_WIKI _instance = null;
        public static Command_WIKI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Command_WIKI();
                }

                return _instance;
            }
        }

        public int DM_Intent_TypeID
        {
            get
            {
                return DM_Intent_Type.WIKI;
            }
        }

        public String ExecuteCommand(Intent_Request data)
        {
            EntityParam noi_dung = data.mListParam.FirstOrDefault(p => p.Name == "noi_dung");
            if (noi_dung != null)
            {
                String noi_dung_request = noi_dung.Value;

                if(data.DM_Entity_TypeID == DM_Entity_Type.WIKI_LA_AI)
                {
                    noi_dung_request += " là ai";
                }
                if (data.DM_Entity_TypeID == DM_Entity_Type.WIKI_LA_GI)
                {
                    noi_dung_request += " là gì";
                }
                if (data.DM_Entity_TypeID == DM_Entity_Type.WIKI_DINH_NGHIA)
                {
                    noi_dung_request = "định nghĩa " + noi_dung_request;
                }

                String data_response = TraCuuThongTin(noi_dung_request);
                if(!String.IsNullOrEmpty(data_response))
                {
                    return data_response;
                }
                else
                {
                    if (data.DM_Entity_TypeID == 0)
                    {
                        String data_response_new = "";

                        //là gì
                        noi_dung_request = noi_dung.Value + " là gì";
                        data_response_new = TraCuuThongTin(noi_dung_request);
                        if (!String.IsNullOrEmpty(data_response_new))
                        {
                            return data_response_new;
                        }

                        //là ai
                        noi_dung_request = noi_dung.Value + " là ai";
                        data_response_new = TraCuuThongTin(noi_dung_request);
                        if (!String.IsNullOrEmpty(data_response_new))
                        {
                            return data_response_new;
                        }

                        //định nghĩa
                        noi_dung_request = "định nghĩa " + noi_dung.Value;
                        data_response_new = TraCuuThongTin(noi_dung_request);
                        if (!String.IsNullOrEmpty(data_response_new))
                        {
                            return data_response_new;
                        }
                    }
                }
            }
            
            return "";
        }

        public String TraCuuThongTin(String noi_dung)
        {
            String data_web = UtilityWeb.mInstance.GetData("https://www.google.com.vn/search?lr=lang_vi&btnK=Google+Search&q=" + noi_dung.TrimSpace().Replace(' ', '+'));
            if (!String.IsNullOrEmpty(data_web))
            {
                data_web = System.Net.WebUtility.HtmlDecode(data_web);
            
                //Nếu có thông tin ở wiki (panel bên phải)
                {
                    String pattern = "<span>(?<noi_dung>.+)<a class(.+)>Wikipedia</a>";
                    Match match = new Regex(pattern,RegexOptions.Singleline | RegexOptions.IgnoreCase).Match(data_web);
                    if (match != null && match.Success)
                    {                        
                        String data_response = match.Groups["noi_dung"].Value;
                        data_response = data_response.Replace("<b>", "");
                        data_response = data_response.Replace("</b>", "");
                        IList<String> list_data_respone = data_response.Split('.').ToList();

                        String data_response_ok = "";
                        data_response_ok += "<speak>";
                        data_response_ok += "<p>";
                        data_response_ok += "<s>Theo Wikipedia:</s>";
                        data_response_ok += "<break time=\"300ms\"/>";
                        foreach (String data_text in list_data_respone)
                        {
                            data_response_ok += "<s>" + data_text + "</s>";
                        }
                        data_response_ok += "</p>";
                        data_response_ok += "</speak>";

                        return data_response_ok;
                    }
                }

                //Nếu có thông tin ở wiki (panel phía trước)
                {
                    String pattern = "<div class=\"KpMaL\">(?<noi_dung>.+)</div></div><div class=\"A9h3Vd\">";
                    Match match = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase).Match(data_web);
                    if (match != null && match.Success)
                    {
                        String data_response = match.Groups["noi_dung"].Value;
                        data_response = data_response.Replace("<b>", "");
                        data_response = data_response.Replace("</b>", "");
                        IList<String> list_data_respone = data_response.Split('.').ToList();

                        String data_response_ok = "";
                        data_response_ok += "<speak>";
                        data_response_ok += "<p>";
                        data_response_ok += "<s>Theo internet:</s>";
                        data_response_ok += "<break time=\"300ms\"/>";
                        foreach (String data_text in list_data_respone)
                        {
                            data_response_ok += "<s>" + data_text + "</s>";
                        }
                        data_response_ok += "</p>";
                        data_response_ok += "</speak>";

                        return data_response_ok;
                    }
                }
            }

            return "";
        }
    }
}
