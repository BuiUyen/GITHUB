using Newtonsoft.Json;
using Sanita.Utility.Logger;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;

namespace Medibox.Utility
{
    public class UtilityWeb
    {
        private const String TAG = "UtilityWeb";

        //Singleton
        private static UtilityWeb _UtilityCache;
        public static UtilityWeb mInstance
        {
            get
            {
                if (_UtilityCache == null)
                {
                    _UtilityCache = new UtilityWeb();
                }
                return _UtilityCache;
            }
        }

        private WebClient mWebClient;

        public UtilityWeb()
        {
            mWebClient = new WebClient();            
        }

        #region Public

        public String GetData(String urlAddress)
        {            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string data = "";

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }

            return data;
        }

        #endregion

    }
}