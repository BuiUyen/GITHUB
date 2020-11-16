using Medibox.Model;
using Medibox.Presenter;
using Medibox.Service.Model;
using Medibox.Utility;
using Sanita.Utility;
using Sanita.Utility.Encryption;
using Sanita.Utility.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using Medibox.Database;
using System.IO;
using System.Text.RegularExpressions;
using Medibox.Command;
using System.Reflection;

namespace Medibox.Service.Api
{
    public class WebAPI : ApiBase, IWebAPI
    {
        private const String TAG = "WebAPI";

        public String XuLyDuLieu(String data)
        {
            data = data ?? "";
            data = data.ToLower();
            data = data.Trim();
            data = data.TrimSpace();

            data = data.Replace("aa", "a");
            data = data.Replace("áá", "á");
            data = data.Replace("àà", "à");
            data = data.Replace("ãã", "ã");
            data = data.Replace("ảả", "ả");

            data = data.Replace("ii", "i");
            data = data.Replace("ìì", "ì");
            data = data.Replace("íí", "í");
            data = data.Replace("ỉỉ", "ỉ");

            data = data.Replace("ơơ", "ơ");
            data = data.Replace("ờờ", "ờ");
            data = data.Replace("ớớ", "ớ");
            data = data.Replace("ởở", "ở");

            data = data.Replace("uu", "u");
            data = data.Replace("úú", "ú");
            data = data.Replace("ùù", "ù");
            data = data.Replace("ủủ", "ủ");

            data = data.Replace("ưư", "ư");
            data = data.Replace("ừừ", "ừ");
            data = data.Replace("ứứ", "ứ");
            data = data.Replace("ửử", "ử");

            data = data.Replace("yy", "y");
            data = data.Replace("ýý", "ý");
            data = data.Replace("ỳỳ", "ỳ");
            data = data.Replace("ỷỷ", "ỷ");

            return data;
        }

        public String XuLyRequest(Intent_Request data)
        {
            var type = typeof(ICommand);
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p));
            foreach (Type m_type in types)
            {
                var field = m_type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);
                if (field != null)
                {
                    var value = (ICommand)field.GetValue(null, null);
                    if (value != null)
                    {
                        if (value.DM_Intent_TypeID == data.DM_Intent_TypeID)
                        {
                            return value.ExecuteCommand(data);
                        }
                    }
                }
            }

            return "";
        }

        public API_TroLyAoData_Out TroLyAo_Execute(API_TroLyAoData_In data)
        {
            //Output
            API_TroLyAoData_Out mAPI_TroLyAoData_Out = new API_TroLyAoData_Out();
            mAPI_TroLyAoData_Out.Language = "vi-VN";

            //Kiểm tra data
            if (data == null)
            {
                mAPI_TroLyAoData_Out.Data = "Bạn hãy hỏi gì đi...";
                mAPI_TroLyAoData_Out.ID = Sanita.Utility.Encryption.CryptorEngine.CreateMD5Hash(mAPI_TroLyAoData_Out.Data);
                return mAPI_TroLyAoData_Out;
            }

            //Kiểm tra device
            Device mDevice = DevicePresenter.GetDevice(data.DeviceID);
            if (mDevice.DeviceID <= 0)
            {
                mAPI_TroLyAoData_Out.Data = "Thiết bị của bạn chưa được đăng ký.";
                mAPI_TroLyAoData_Out.ID = Sanita.Utility.Encryption.CryptorEngine.CreateMD5Hash(mAPI_TroLyAoData_Out.Data);
                return mAPI_TroLyAoData_Out;
            }

            //Kiểm tra user
            User mUser = UserPresenter.GetUser(mDevice.UserID);
            if (mUser.APIKey != data.API_Key)
            {
                mAPI_TroLyAoData_Out.Data = "API key không đúng.";
                mAPI_TroLyAoData_Out.ID = Sanita.Utility.Encryption.CryptorEngine.CreateMD5Hash(mAPI_TroLyAoData_Out.Data);
                return mAPI_TroLyAoData_Out;
            }

            if (!MyVar.mListDevice.Any(p => p.DeviceID == mDevice.DeviceID))
            {
                MyVar.mListDevice.Add(mDevice);
            }
            mDevice = MyVar.mListDevice.FirstOrDefault(p => p.DeviceID == mDevice.DeviceID);
            mDevice.mUser = mUser;

            //Xử lý input
            data.Data = XuLyDuLieu(data.Data);

            //Lấy danh sách request
            IList<Intent_Request> mListRequest = Intent_RequestPresenter.GetIntent_Requests(data.Data);

            //Lọc theo bối cảnh hiện tại
            IList<Intent_Request> mListRequest_Current = mListRequest.Where(p => p.Current_DM_Entity_TypeID == mDevice.Current_DM_Entity_TypeID && p.Current_DM_Intent_TypeID == mDevice.Current_DM_Intent_TypeID).ToList();
            if (mListRequest_Current.Count == 0)
            {
                mListRequest_Current = mListRequest.Where(p => p.Current_DM_Entity_TypeID == 0 && p.Current_DM_Intent_TypeID == 0).ToList();
            }
            if (mListRequest_Current.Count > 0)
            {
                mListRequest = mListRequest_Current;
            }

            //Sắp xếp
            IList<Intent_Request> mListRequest_NoneParam = mListRequest.Where(p => !p.Data.Contains("<") && !p.Data.Contains(">")).OrderByDescending(p => p.Data.Length).ToList();
            IList<Intent_Request> mListRequest_Param = mListRequest.Where(p => p.Data.Contains("<") && p.Data.Contains(">")).OrderByDescending(p => p.Data.Length).ToList();
            mListRequest = mListRequest_NoneParam.Concat(mListRequest_Param).ToList();

            Intent_Request mIntent_Request = new Intent_Request();
            foreach (Intent_Request request in mListRequest)
            {
                String request_data = request.Data;
                request_data = request_data ?? "";
                request_data = request_data.Replace("<*>", "(.*)");
                request_data = request_data.Replace("<", "(?<");
                request_data = request_data.Replace(">", ">(.+))");
                request_data = "^" + request_data + "$";

                Regex mRegex = new Regex(request_data, RegexOptions.IgnoreCase | RegexOptions.Singleline);

                if (mRegex.IsMatch(data.Data))
                {
                    mIntent_Request = request;
                    mDevice.Current_DM_Intent_TypeID = mIntent_Request.DM_Intent_TypeID;
                    mDevice.Current_DM_Entity_TypeID = mIntent_Request.DM_Entity_TypeID;

                    GroupCollection groups = mRegex.Match(data.Data).Groups;

                    foreach (string groupName in mRegex.GetGroupNames())
                    {
                        EntityParam mEntityParam = new EntityParam();
                        mEntityParam.Name = groupName;
                        mEntityParam.Value = groups[groupName].Value;
                        mIntent_Request.mListParam.Add(mEntityParam);
                    }
                }
            }

            //Set device
            mIntent_Request.mDevice = mDevice;

            //Xử lý request
            String response_request = XuLyRequest(mIntent_Request);
            if (!String.IsNullOrEmpty(response_request))
            {
                mAPI_TroLyAoData_Out.Data = response_request;
                mAPI_TroLyAoData_Out.ID = Sanita.Utility.Encryption.CryptorEngine.CreateMD5Hash(mAPI_TroLyAoData_Out.Data);
                return mAPI_TroLyAoData_Out;
            }

            //Get response
            Intent_Response mIntent_Response = Intent_ResponsePresenter.GetIntent_Response_Request(mIntent_Request);
            if (String.IsNullOrEmpty(mIntent_Response.Data))
            {
                mIntent_Response.Data = "Xin lỗi... Tôi không hiểu !";
            }

            //Update global
            if (mIntent_Response.Data.Contains("<") && mIntent_Response.Data.Contains(">"))
            {
                mIntent_Response.Data.Replace("<thoi_gian_hien_tai>", String.Format("{0:HH:mm}", SystemInfo.NOW));
                mIntent_Response.Data.Replace("<ngay_hien_tai>", String.Format("{0:dd/MM/yyyy}", SystemInfo.NOW));
                mIntent_Response.Data.Replace("<thu_hien_tai>", String.Format("{0}", SystemInfo.NOW.GetThu()));
                mIntent_Response.Data.Replace("<ngay_mai>", String.Format("{0:dd/MM/yyyy}", SystemInfo.NOW.AddDays(1)));
                mIntent_Response.Data.Replace("<thu_mai>", String.Format("{0}", SystemInfo.NOW.AddDays(1).GetThu()));
            }

            //Return            
            mAPI_TroLyAoData_Out.Data = mIntent_Response.Data;
            mAPI_TroLyAoData_Out.ID = Sanita.Utility.Encryption.CryptorEngine.CreateMD5Hash(mAPI_TroLyAoData_Out.Data);
            return mAPI_TroLyAoData_Out;

#if false
            //Check
            if (data.Data.Contains("thời tiết") && data.Data.Contains("hôm nay"))
            {
                String thu = "";
                if (SystemInfo.NOW.DayOfWeek == DayOfWeek.Sunday)
                {
                    thu = String.Format("chủ nhật");
                }
                else
                {
                    thu = String.Format("thứ {0}", (int)SystemInfo.NOW.DayOfWeek + 1);
                }

                mAPI_TroLyAoData_Out.Data = String.Format("Dự báo thời tiết hôm nay ở Quan Khê, Hải Dương {0} ngày {1:dd/MM} có mưa rào nhẹ, nhiệt độ từ 26 đến 32 độ, độ ẩm 94%", thu, SystemInfo.NOW);
            }
            else if ((data.Data.Contains("thời tiết") && data.Data.Contains("ngày mai")) || data.Data.Contains("còn ngày mai"))
            {
                String thu = "";
                if (SystemInfo.NOW.AddDays(1).DayOfWeek == DayOfWeek.Sunday)
                {
                    thu = String.Format("chủ nhật");
                }
                else
                {
                    thu = String.Format("thứ {0}", (int)SystemInfo.NOW.AddDays(1).DayOfWeek + 1);
                }

                mAPI_TroLyAoData_Out.Data = String.Format("Dự báo thời tiết ngày mai ở Quan Khê, Hải Dương {0} ngày {1:dd/MM} trời nhiều mây và nắng nhẹ, nhiệt độ từ 26 đến 33 độ, độ ẩm 76%", thu, SystemInfo.NOW.AddDays(1));
            }
            else if (data.Data.Contains("mấy giờ rồi") || data.Data.Contains("bây giờ là mấy giờ"))
            {
                mAPI_TroLyAoData_Out.Data = String.Format("Thời gian là {0:HH:mm} phút", SystemInfo.NOW);
            }
            else if (data.Data.Contains("hôm nay") && data.Data.Contains("thứ mấy"))
            {
                if (SystemInfo.NOW.DayOfWeek == DayOfWeek.Sunday)
                {
                    mAPI_TroLyAoData_Out.Data = String.Format("Hôm nay là chủ nhật");
                }
                else
                {
                    mAPI_TroLyAoData_Out.Data = String.Format("Hôm nay là thứ {0}", (int)SystemInfo.NOW.DayOfWeek + 1);
                }
            }
            else if (data.Data.Contains("ngày mai") && data.Data.Contains("thứ mấy"))
            {
                if (SystemInfo.NOW.AddDays(1).DayOfWeek == DayOfWeek.Sunday)
                {
                    mAPI_TroLyAoData_Out.Data = String.Format("Ngày mai là chủ nhật");
                }
                else
                {
                    mAPI_TroLyAoData_Out.Data = String.Format("Ngày mai là thứ {0}", (int)SystemInfo.NOW.AddDays(1).DayOfWeek + 1);
                }
            }
            else if (data.Data.EqualText("bạn là ai") || data.Data.EqualText("bạn là cái gì"))
            {
                mAPI_TroLyAoData_Out.Data = "Tôi là trợ lý ảo của bạn đây";
            }
            else if (data.Data.EqualText("tên bạn là gì"))
            {
                mAPI_TroLyAoData_Out.Data = "Tôi chưa tự giới thiệu sao ? Tên tôi là Daisy !";
            }
            else if (data.Data.Contains("bạn biết hát không") || data.Data.Contains("bạn có biết hát không") || data.Data.Contains("hát cho tôi nghe"))
            {
                mAPI_TroLyAoData_Out.Data += "<speak>";
                mAPI_TroLyAoData_Out.Data += "<p>";

                mAPI_TroLyAoData_Out.Data += "<s>Xin lỗi, giờ tôi vẫn chưa biết hát.</s>";
                mAPI_TroLyAoData_Out.Data += "<s>Thay vào đó, tôi có thể đọc lời bài hát cho bạn tự tưởng tượng theo.</s>";
                mAPI_TroLyAoData_Out.Data += "<break time=\"300ms\"/>";

                mAPI_TroLyAoData_Out.Data += "<s>Kìa con bướm vàng.</s>";
                mAPI_TroLyAoData_Out.Data += "<s>Kìa con bướm vàng.</s>";

                mAPI_TroLyAoData_Out.Data += "<s>Xòe đôi cánh.</s>";
                mAPI_TroLyAoData_Out.Data += "<s>Xòe đôi cánh.</s>";

                mAPI_TroLyAoData_Out.Data += "<s>Tung cánh bay năm ba vòng.</s>";
                mAPI_TroLyAoData_Out.Data += "<s>Tung cánh bay năm ba vòng.</s>";

                mAPI_TroLyAoData_Out.Data += "<s>Em ngồi xem...</s>";
                mAPI_TroLyAoData_Out.Data += "<s>Em ngồi xem...</s>";

                mAPI_TroLyAoData_Out.Data += "</p>";
                mAPI_TroLyAoData_Out.Data += "</speak>";
            }
            else if (data.Data.Contains("bạn đang ở đâu"))
            {
                mAPI_TroLyAoData_Out.Data += "<speak>";
                mAPI_TroLyAoData_Out.Data += "<p>";

                mAPI_TroLyAoData_Out.Data += "<s>Tôi ở trong thiết bị này.</s>";
                mAPI_TroLyAoData_Out.Data += "<s>cả máy tính bảng có ngay khi cần.</s>";
                mAPI_TroLyAoData_Out.Data += "<s>Google home cũng có phần.</s>";
                mAPI_TroLyAoData_Out.Data += "<s>Ôi nhiều nhà quá phân vân chọn hoài.</s>";

                mAPI_TroLyAoData_Out.Data += "</p>";
                mAPI_TroLyAoData_Out.Data += "</speak>";
            }
            else if (data.Data.Contains("truyện cười") || data.Data.Contains("chuyện cười"))
            {
                mAPI_TroLyAoData_Out.Data += "<speak>";
                mAPI_TroLyAoData_Out.Data += "<p>";
                
                mAPI_TroLyAoData_Out.Data += "<s>Được, bạn nghe nhé !</s>";
                mAPI_TroLyAoData_Out.Data += "<break time=\"300ms\"/>";

                mAPI_TroLyAoData_Out.Data += "<s>Trong giờ địa lý, thầy hỏi trò.</s>";
                mAPI_TroLyAoData_Out.Data += "<s>Em hãy nói ba lý do khiến em chắc rằng trái đất hình cầu.</s>";
                mAPI_TroLyAoData_Out.Data += "<s>Thưa thầy, bố em nói thế, mẹ em nói thế và thầy cũng nói thế ạ !</s>";

                mAPI_TroLyAoData_Out.Data += "<audio src=\"https://ia601507.us.archive.org/31/items/google_cuoi/google_cuoi.ogg\"/>";

                mAPI_TroLyAoData_Out.Data += "</p>";
                mAPI_TroLyAoData_Out.Data += "</speak>";
            }
            else if (data.Data.Contains("truyện khác") || data.Data.Contains("chuyện khác"))
            {
                mAPI_TroLyAoData_Out.Data += "<speak>";
                mAPI_TroLyAoData_Out.Data += "<p>";
                
                mAPI_TroLyAoData_Out.Data += "<s>Được, nghe tôi kể đây này !</s>";                
                mAPI_TroLyAoData_Out.Data += "<break time=\"300ms\"/>";

                mAPI_TroLyAoData_Out.Data += "<s>Ngày đầu tiên bé đi học về, bố mẹ hỏi. Ở lớp thế nào con ?</s>";
                mAPI_TroLyAoData_Out.Data += "<s>Vui lắm bố ạ, cô giáo con xinh lắm !</s>";
                mAPI_TroLyAoData_Out.Data += "<s>Thế cô dạy con những gì ?</s>";
                mAPI_TroLyAoData_Out.Data += "<s>Cô chẳng biết gì cả ! Cái gì cũng phải hỏi : Em nào cho cô biết nào.</s>";

                mAPI_TroLyAoData_Out.Data += "<audio src=\"https://ia601507.us.archive.org/31/items/google_cuoi/google_cuoi.ogg\"/>";                

                mAPI_TroLyAoData_Out.Data += "</p>";
                mAPI_TroLyAoData_Out.Data += "</speak>";
            }
            else if (data.Data.EqualText("bật đèn phòng khách"))
            {
                mAPI_TroLyAoData_Out.Data = "OK, đã bật đèn phòng khách";
            }
            else if (data.Data.EqualText("tắt đèn phòng khách"))
            {
                mAPI_TroLyAoData_Out.Data = "OK, đã tắt đèn phòng khách";
            }
            else if (data.Data.EqualText("bật điều hòa") || data.Data.EqualText("tôi nóng quá"))
            {
                mAPI_TroLyAoData_Out.Data = "OK, đã bật điều hòa";
            }
            else if (data.Data.EqualText("để điều hòa 26 độ"))
            {
                mAPI_TroLyAoData_Out.Data = "OK, đã để điều hòa 26 độ C";
            }

            //Return
            if (String.IsNullOrEmpty(mAPI_TroLyAoData_Out.Data))
            {
                mAPI_TroLyAoData_Out.Data = "Xin lỗi... Tôi không hiểu !";
            }

            mAPI_TroLyAoData_Out.ID = Sanita.Utility.Encryption.CryptorEngine.CreateMD5Hash(mAPI_TroLyAoData_Out.Data);
            mAPI_TroLyAoData_Out.Language = "vi-VN";

            return mAPI_TroLyAoData_Out;
#endif
        }

        public API_WebHookData_Out TroLyAo_Webhook(API_WebHookData_In data)
        {
            API_TroLyAoData_In mAPI_TroLyAoData_In = new API_TroLyAoData_In();
            mAPI_TroLyAoData_In.DeviceID = "000000005f26648f";
            mAPI_TroLyAoData_In.API_Key = "123456";
            mAPI_TroLyAoData_In.Data = data.queryResult.queryText;

            API_TroLyAoData_Out mAPI_TroLyAoData_Out = TroLyAo_Execute(mAPI_TroLyAoData_In);

            API_WebHookData_Out mAPI_WebHookData_Out = new API_WebHookData_Out();
            mAPI_WebHookData_Out.fulfillmentText = mAPI_TroLyAoData_Out.Data;
            mAPI_WebHookData_Out.source = "medibot.vn";
            return mAPI_WebHookData_Out;
        }

        public Stream API_Spotify_Callback(String code, String state)
        {
            return null;
        }
    }
}
