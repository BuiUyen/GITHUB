using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medibox.Model;
using Medibox.Presenter;
using Medibox.Utility;
using Sanita.Utility;
using Medibox.Integration.HassIO;

namespace Medibox.Command
{
    public class Command_HOME_CONTROL : ICommand
    {
        //Singleton
        private static Command_HOME_CONTROL _instance = null;
        public static Command_HOME_CONTROL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Command_HOME_CONTROL();
                }

                return _instance;
            }
        }

        public int DM_Intent_TypeID
        {
            get
            {
                return DM_Intent_Type.HOME_CONTROL;
            }
        }

        public String ExecuteCommand(Intent_Request data)
        {
            EntityParam thiet_bi = data.mListParam.FirstOrDefault(p => p.Name == "thiet_bi");
            if (thiet_bi == null)
            {
                return "<speak><p><s>Bạn hãy nói tên thiết bị</s></p></speak>";
            }

            //Danh sách thiết bị
            IList<Device> mListDevice = DevicePresenter.GetDevices(null, null);
            IList<Room> mListRoom = RoomPresenter.GetRooms(null, null);
            foreach (Device device in mListDevice)
            {
                device.mRoom = mListRoom.FirstOrDefault(p => p.RoomID == device.RoomID);
                device.mRoom = device.mRoom ?? new Room();
            }

            Device mDevice = null;

            while (true)
            {
                //Tìm thiết bị trùng khớp
                //ví dụ "đèn ngủ 1"
                {
                    mDevice = mListDevice.FirstOrDefault(p => p.DeviceName.EqualTextNoCase(thiet_bi.Value));
                    if (mDevice != null)
                    {
                        break;
                    }
                }

                //Tìm thiết bị gồm tên thiết bị (đầy đủ) + tên phòng
                //ví dụ "đèn ngủ 1 phòng khách"                
                {
                    mDevice = mListDevice.FirstOrDefault(p => (p.DeviceName + " " + p.mRoom.RoomName).EqualTextNoCase(thiet_bi.Value));
                    if (mDevice != null)
                    {
                        break;
                    }
                }

                //Tìm thiết bị gồm tên thiết bị (ngắn gọn) + tên phòng
                //ví dụ "đèn phòng khách"                
                {
                    mDevice = mListDevice.FirstOrDefault(p => (p.DeviceName_Short + " " + p.mRoom.RoomName).EqualTextNoCase(thiet_bi.Value));
                    if (mDevice != null)
                    {
                        break;
                    }
                }

                //Tìm thiết bị cùng phòng (tên đầy đủ)
                {
                    mListDevice = mListDevice.Where(p => p.RoomID == data.mDevice.RoomID).ToList();

                    {
                        mDevice = mListDevice.FirstOrDefault(p => p.DeviceName.EqualTextNoCase(thiet_bi.Value));
                        if (mDevice != null)
                        {
                            break;
                        }
                    }

                    //Tìm thiết bị cùng phòng (tên ngắn gọn)
                    {
                        mDevice = mListDevice.FirstOrDefault(p => p.DeviceName_Short.EqualTextNoCase(thiet_bi.Value));
                        if (mDevice != null)
                        {
                            break;
                        }
                    }
                }

                break;
            }

            if (mDevice != null)
            {
                switch (data.DM_Entity_TypeID)
                {
                    case DM_Entity_Type.HOME_CONTROL_BAT_THIET_VI:
                        {
                            if (UtilityHassIO.mInstance.Switch_Turn_OnOff(data.mDevice.mUser.HassIO_URL, data.mDevice.mUser.HassIO_KEY, mDevice.DeviceCode, "on"))
                            {
                                return String.Format("<speak><p><s>Đã bật {0}</s></p></speak>", mDevice.DeviceName);
                            }
                            else
                            {
                                return String.Format("<speak><p><s>Xin lỗi, tôi không thực hiện được yêu cầu của bạn</s></p></speak>", mDevice.DeviceName);
                            }
                        }
                    case DM_Entity_Type.HOME_CONTROL_TAT_THIET_VI:
                        {
                            if (UtilityHassIO.mInstance.Switch_Turn_OnOff(data.mDevice.mUser.HassIO_URL, data.mDevice.mUser.HassIO_KEY, mDevice.DeviceCode, "off"))
                            {
                                return String.Format("<speak><p><s>Đã tắt {0}</s></p></speak>", mDevice.DeviceName);
                            }
                            else
                            {
                                return String.Format("<speak><p><s>Xin lỗi, tôi không thực hiện được yêu cầu của bạn</s></p></speak>", mDevice.DeviceName);
                            }
                        }                   
                    default:
                        break;
                }
            }
            else
            {
                return "<speak><p><s>Tôi không tìm được thiết bị trong nhà của bạn</s></p></speak>";
            }

            return "";
        }
    }
}
