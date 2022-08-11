using Newtonsoft.Json;
using Sanita.Utility.Logger;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;
using Medibox.Integration.HassIO.Model;

namespace Medibox.Integration.HassIO
{
    public class UtilityHassIO
    {
        private const String TAG = "UtilityHassIO";

        //Singleton
        private static UtilityHassIO _UtilityCache;
        public static UtilityHassIO mInstance
        {
            get
            {
                if (_UtilityCache == null)
                {
                    _UtilityCache = new UtilityHassIO();
                }
                return _UtilityCache;
            }
        }

        private WebClient mWebClient;

        public UtilityHassIO()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            mWebClient = new WebClient();            
        }

        #region Public

        public String GetData(String url)
        {
            try
            {
                var buf = mWebClient.DownloadData(url);
                if (buf != null)
                {
                    return System.Text.Encoding.UTF8.GetString(buf);                    
                }
            }
            catch (Exception ex)
            {
                SanitaLog.e(TAG, ex);
            }

            return "";
        }

        public States_Get_Out States_Get(String hass_url, String hass_api_password, String hass_entity_id)
        {
            States_Get_Out mData_Output = null;

            String url = String.Format("{0}/api/states/{1}?api_password={2}", hass_url, hass_entity_id, hass_api_password);

            try
            {
                String result_data = GetData(url);

                if (!String.IsNullOrEmpty(result_data))
                {
                    mData_Output = JsonConvert.DeserializeObject<States_Get_Out>(result_data);
                }
            }
            catch(Exception ex)
            {
                Sanita.Utility.Logger.SanitaLog.e(TAG, ex);
            }

            return mData_Output;
        }

        //Turn-on-switch
        public bool Switch_Turn_OnOff(String hass_url, String hass_api_password, String hass_entity_id, String on_off)
        {
            String url = String.Format("{0}/api/services/switch/turn_{1}?api_password={2}", hass_url, on_off, hass_api_password);

            Switch_Turn_OnOff_In mData_In = new Switch_Turn_OnOff_In();
            mData_In.entity_id = hass_entity_id;            

            try
            {
                var http = (HttpWebRequest)WebRequest.Create(new Uri(url));
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.Method = "POST";
                http.Proxy = new WebProxy();//no proxy

                if (hass_url.StartsWith("https"))
                {
                    try
                    {
                        ServicePointManager.ServerCertificateValidationCallback =
                           new System.Net.Security.RemoteCertificateValidationCallback(
                                delegate
                                {
                                    return true;
                                }
                            );
                    }
                    catch (Exception ex)
                    {
                        Sanita.Utility.Logger.SanitaLog.e(TAG, ex);
                    }
                }

                string parsedContent = JsonConvert.SerializeObject(mData_In);

                UTF8Encoding encoding = new UTF8Encoding();
                Byte[] bytes = encoding.GetBytes(parsedContent);

                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();

                var response = http.GetResponse();

                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var result_data = sr.ReadToEnd();

                if (!String.IsNullOrEmpty(result_data))
                {
                    //Delay
                    System.Threading.Thread.Sleep(1000);

                    //Check state
                    States_Get_Out mStates_Get_Out = States_Get(hass_url, hass_api_password, hass_entity_id);
                    if(mStates_Get_Out != null)
                    {
                        if(mStates_Get_Out.state == on_off)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {                
                Sanita.Utility.Logger.SanitaLog.e(TAG, ex);                
            }

            return false;
        }

        #endregion

    }
}