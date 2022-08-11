using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medibox.Model;
using Medibox.Presenter;
using Medibox.Utility;
using Sanita.Utility;

namespace Medibox.Command
{
    public class Command_KE_CHUYEN : ICommand
    {
        //Singleton
        private static Command_KE_CHUYEN _instance = null;
        public static Command_KE_CHUYEN Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Command_KE_CHUYEN();                    
                }

                return _instance;
            }
        }

        public int DM_Intent_TypeID
        {
            get
            {
                return DM_Intent_Type.KE_CHUYEN;
            }
        }

        public String ExecuteCommand(Intent_Request data)
        {            
            if (data.DM_Entity_TypeID == 0)
            {
                data.DM_Entity_TypeID = DM_Entity_Type.KE_CHUYEN_CUOI;
            }

            //Lấy response
            Intent_Response mIntent_Response = Intent_ResponsePresenter.GetIntent_Response_Request(data);
            String response_data = mIntent_Response.Data;
            response_data = response_data ?? "";        

            //Response
            return response_data;
        }
    }
}
