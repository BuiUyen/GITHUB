using Newtonsoft.Json;
using Sanita.Utility.Logger;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Integration.Spotify
{
    public class UtilitySpotify
    {
        private const String TAG = "UtilitySpotify";

        //Singleton
        private static UtilitySpotify _UtilityCache;
        public static UtilitySpotify mInstance
        {
            get
            {
                if (_UtilityCache == null)
                {
                    _UtilityCache = new UtilitySpotify();
                }
                return _UtilityCache;
            }
        }

        private WebClient mWebClient;

        public UtilitySpotify()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            mWebClient = new WebClient();
        }

        #region Public



        #endregion

    }
}