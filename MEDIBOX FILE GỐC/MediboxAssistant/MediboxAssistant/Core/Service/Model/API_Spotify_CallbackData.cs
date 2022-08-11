using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Medibox.Service.Model
{
    [DataContract(Namespace = "")]
    public class API_Spotify_CallbackData_In
    {
        [DataMember]
        public String access_token { get; set; }

        [DataMember]
        public String token_type { get; set; }

        public API_Spotify_CallbackData_In()
        {

        }
    }

    [DataContract(Namespace = "")]
    public class API_Spotify_CallbackData_Out
    {

    }
}
