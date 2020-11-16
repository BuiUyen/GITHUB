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

namespace Medibox.Integration
{
    public class Command_THOI_GIAN : ICommand
    {
        //Singleton
        private static Command_THOI_GIAN _instance = null;
        public static Command_THOI_GIAN Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Command_THOI_GIAN();
                }

                return _instance;
            }
        }

        public int DM_Intent_TypeID
        {
            get
            {
                return DM_Intent_Type.THOI_GIAN;
            }
        }

        public String ExecuteCommand(Intent_Request data)
        {
            String thoi_gian = "";
            String thoi_gian_gio = "";
            String thoi_gian_phut = "";

            //Check entity
            if (data.DM_Entity_TypeID == 0)
            {
                EntityParam mEntityParam_ThoiGian = data.mListParam.FirstOrDefault(p => p.Name == "thoi_gian");
                if (mEntityParam_ThoiGian != null)
                {
                    if (mEntityParam_ThoiGian.Value == "theo can chi")
                    {
                        data.DM_Entity_TypeID = DM_Entity_Type.THOI_GIAN_AM_LICH_HOM_NAY;
                    }
                }
            }
            if (data.DM_Entity_TypeID == 0)
            {
                data.DM_Entity_TypeID = DM_Entity_Type.THOI_GIAN_HOM_NAY;
            }

            //Lấy response
            Intent_Response mIntent_Response = Intent_ResponsePresenter.GetIntent_Response_Request(data);
            String response_data = mIntent_Response.Data;
            response_data = response_data ?? "";

            //Cập nhật biến
            switch (data.DM_Entity_TypeID)
            {
                case DM_Entity_Type.THOI_GIAN_HOM_NAY:
                    {
                        thoi_gian = String.Format("{0:HH:mm}", SystemInfo.NOW);
                        thoi_gian_gio = String.Format("{0:HH}", SystemInfo.NOW);
                        thoi_gian_phut = String.Format("{0:mm}", SystemInfo.NOW);
                    }
                    break;
                case DM_Entity_Type.THOI_GIAN_HOM_NAY_DIA_DIEM:
                    {
                        EntityParam dia_diem = data.mListParam.FirstOrDefault(p => p.Name == "dia_diem");
                        if (dia_diem != null)
                        {
                            thoi_gian = GetThoiGian_DiaDiem(dia_diem.Value);
                            IList<String> list_time = thoi_gian.Split(':').ToList();
                            if(list_time.Count == 2)
                            {
                                thoi_gian_gio = list_time[0];
                                thoi_gian_phut = list_time[1];
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            //Update biến
            if (!String.IsNullOrEmpty(thoi_gian))
            {
                response_data = response_data.Replace("<thoi_gian>", thoi_gian);
                response_data = response_data.Replace("<thoi_gian_gio>", thoi_gian_gio);
                response_data = response_data.Replace("<thoi_gian_phut>", thoi_gian_phut);
            }
            else
            {
                response_data = "";
                data.DM_Intent_TypeID = DM_Intent_Type.KHONG_HIEU;
            }

            //Update biến đầu vào
            foreach (EntityParam param in data.mListParam)
            {
                response_data = response_data.Replace("<" + param.Name + ">", param.Value);
            }

            //Response
            return response_data;
        }

        public String GetThoiGian_DiaDiem(String dia_diem)
        {
            String data_web = UtilityWeb.mInstance.GetData("https://www.google.com.vn/search?lr=lang_vi&btnK=Google+Search&q=thời+gian+ở+" + dia_diem.TrimSpace().Replace(' ', '+'));
            if (!String.IsNullOrEmpty(data_web))
            {
                data_web = System.Net.WebUtility.HtmlDecode(data_web);

                String pattern = "(id=\"resultStats\">.*>(?<Time>\\d+:\\d+)((?<AMPM> AM|PM))?<)";
                Match match = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase).Match(data_web);
                if (match != null && match.Success)
                {
                    String time = match.Groups["Time"].Value;
                    String am_pm = match.Groups["AMPM"].Value;
                    if(String.IsNullOrEmpty(am_pm))
                    {
                        return time;
                    }
                    else
                    {
                        if(am_pm == "PM")
                        {
                            IList<String> list_time = time.Split(':').ToList();
                            if(list_time.Count == 2)
                            {
                                return String.Format("{0}:{1}", list_time[0].GetInteger() + 12, list_time[1]);
                            }
                        }
                    }
                }
            }

            return "";
        }
    }
}
