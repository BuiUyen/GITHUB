using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    [Serializable()]
    public class DM_Hass_DeviceType
    {
        public const int SWITCH = 1;

        public int DM_Hass_DeviceTypeDBID { get; set; }
        public int DM_Hass_DeviceTypeID { get; set; }
        public string DM_Hass_DeviceTypeCode { get; set; }
        public string DM_Hass_DeviceTypeName { get; set; }
        public int DM_Hass_DeviceTypeHardcode { get; set; }
        public int DM_Hass_DeviceTypeDisable { get; set; }

        //Ref
        public IList<DM_Hass_DeviceType> mListSubData { get; set; }

        //Contructor
        public DM_Hass_DeviceType()
        {
            DM_Hass_DeviceTypeHardcode = 0;
            DM_Hass_DeviceTypeDisable = 0;
        }

        public DM_Hass_DeviceType(int _id, String _code, String _name, int _DM_Hass_DeviceTypeHardcode)
        {
            DM_Hass_DeviceTypeID = _id;
            DM_Hass_DeviceTypeCode = _code;
            DM_Hass_DeviceTypeName = _name;
            DM_Hass_DeviceTypeHardcode = _DM_Hass_DeviceTypeHardcode;
            DM_Hass_DeviceTypeDisable = 0;
        }

        //Method
        public static int GetID(String name, int idintent)
        {
            DM_Hass_DeviceType data = DM_Hass_DeviceType.GetDefaultList(0).FirstOrDefault(p => p != null && p.DM_Hass_DeviceTypeName == name);
            data = data ?? new DM_Hass_DeviceType();
            return data.DM_Hass_DeviceTypeID;
        }

        public static int GetID(Object data)
        {
            if (data == null)
            {
                return 0;
            }
            if (!(data is DM_Hass_DeviceType))
            {
                return 0;
            }
            return (data as DM_Hass_DeviceType).DM_Hass_DeviceTypeID;
        }
        public static DM_Hass_DeviceType GetDefault(Object list, int _id)
        {
            if (list == null)
            {
                return null;
            }

            if (!(list is IList<DM_Hass_DeviceType>))
            {
                return null;
            }

            IList<DM_Hass_DeviceType> list_data = list as IList<DM_Hass_DeviceType>;
            return list_data.FirstOrDefault(p => p.DM_Hass_DeviceTypeID == _id);
        }

        public static DM_Hass_DeviceType GetDefault(int _id)
        {
            DM_Hass_DeviceType data = GetDefaultList(0).FirstOrDefault(p => p.DM_Hass_DeviceTypeID == _id);
            if (data == null)
            {
                data = new DM_Hass_DeviceType();
            }

            return data;
        }

        private static IList<DM_Hass_DeviceType> _DefaultList = null;
        public static void InitDefaultList(IList<DM_Hass_DeviceType> list_data)
        {
            _DefaultList = null;
            GetDefaultList(1);

            foreach (DM_Hass_DeviceType data in list_data)
            {
                DM_Hass_DeviceType checkdata = _DefaultList.FirstOrDefault(p => p.DM_Hass_DeviceTypeID == data.DM_Hass_DeviceTypeID);
                if (checkdata != null)
                {
                    checkdata.DM_Hass_DeviceTypeDBID = data.DM_Hass_DeviceTypeDBID;
                    checkdata.DM_Hass_DeviceTypeID = data.DM_Hass_DeviceTypeID;
                    checkdata.DM_Hass_DeviceTypeName = data.DM_Hass_DeviceTypeName;
                    checkdata.DM_Hass_DeviceTypeDisable = data.DM_Hass_DeviceTypeDisable;
                    checkdata.DM_Hass_DeviceTypeHardcode = data.DM_Hass_DeviceTypeHardcode;
                }
                else
                {
                    _DefaultList.Add(data);
                }
            }
        }

        public static IList<DM_Hass_DeviceType> GetDefaultList(int include_deactive)
        {
            if (_DefaultList != null)
            {
                if (include_deactive == 0)
                {
                    //Deactive
                    _DefaultList =
                        (from p in _DefaultList
                         where p.DM_Hass_DeviceTypeDisable == 0
                         select p).ToList();
                }
                return _DefaultList;
            }
            _DefaultList = new List<DM_Hass_DeviceType>();

            _DefaultList.Add(new DM_Hass_DeviceType(SWITCH, "switch", "Công tắc", 1));

            return _DefaultList;
        }
    }
}
