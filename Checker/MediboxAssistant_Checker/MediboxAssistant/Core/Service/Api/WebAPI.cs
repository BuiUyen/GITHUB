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
