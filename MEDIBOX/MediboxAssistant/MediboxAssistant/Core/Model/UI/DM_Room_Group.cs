using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    //Nhóm danh mục loại khoa
    [Serializable()]
    public class DM_Room_Group : BaseModel
    {
        public const int HOME = 1;
        public const int USER = 2;

        public int DM_Room_GroupDBID { get; set; }
        public int DM_Room_GroupID { get; set; }
        public string DM_Room_GroupCode { get; set; }
        public string DM_Room_GroupName { get; set; }
        public int DM_Room_GroupHardcode { get; set; }
        public int DM_Room_GroupDisable { get; set; }

        //Contructor
        public DM_Room_Group()
        {
            DM_Room_GroupHardcode = 0;
            DM_Room_GroupDisable = 0;
        }

        public DM_Room_Group(int _id, String _name, int _DM_DepartmentGroupHardcode)
        {
            DM_Room_GroupID = _id;
            DM_Room_GroupName = _name;
            DM_Room_GroupHardcode = _DM_DepartmentGroupHardcode;
            DM_Room_GroupDisable = 0;
        }

        //Method
        public static int GetID(Object data)
        {
            if (data == null)
            {
                return 0;
            }
            if (!(data is DM_Room_Group))
            {
                return 0;
            }
            return (data as DM_Room_Group).DM_Room_GroupID;
        }
        public static DM_Room_Group GetDefault(Object list, String _id)
        {
            if (list == null)
            {
                return null;
            }

            if (!(list is IList<DM_Room_Group>))
            {
                return null;
            }

            IList<DM_Room_Group> list_data = list as IList<DM_Room_Group>;
            return list_data.FirstOrDefault(p => p.DM_Room_GroupID.ToString() == _id);
        }
        public static DM_Room_Group GetDefault(Object list, int _id)
        {
            if (list == null)
            {
                return null;
            }

            if (!(list is IList<DM_Room_Group>))
            {
                return null;
            }

            IList<DM_Room_Group> list_data = list as IList<DM_Room_Group>;
            return list_data.FirstOrDefault(p => p.DM_Room_GroupID == _id);
        }
        public static DM_Room_Group GetDefault(int _id)
        {
            DM_Room_Group data = GetDefaultList(1).FirstOrDefault(p => p.DM_Room_GroupID == _id);
            if (data == null)
            {
                data = new DM_Room_Group();
            }

            return data;
        }

        public static void InitDefaultList(IList<DM_Room_Group> list_data)
        {
            _DefaultList = null;
            GetDefaultList(1);

            foreach (DM_Room_Group data in list_data)
            {
                DM_Room_Group checkdata = _DefaultList.FirstOrDefault(p => p.DM_Room_GroupID == data.DM_Room_GroupID);
                if (checkdata != null)
                {
                    checkdata.DM_Room_GroupDBID = data.DM_Room_GroupDBID;
                    checkdata.DM_Room_GroupName = data.DM_Room_GroupName;
                    checkdata.DM_Room_GroupDisable = data.DM_Room_GroupDisable;
                }
                else
                {
                    _DefaultList.Add(data);
                }
            }
        }

        private static IList<DM_Room_Group> _DefaultList = null;
        public static IList<DM_Room_Group> GetDefaultList(int include_deactive)
        {
            if (_DefaultList != null)
            {
                if (include_deactive == 0)
                {
                    //Deactive
                    _DefaultList =
                        (from p in _DefaultList
                         where p.DM_Room_GroupDisable == 0
                         select p).ToList();
                }
                return _DefaultList;
            }

            _DefaultList = new List<DM_Room_Group>();

            _DefaultList.Add(new DM_Room_Group(HOME, "Home".Translate(), 1));
            _DefaultList.Add(new DM_Room_Group(USER, "Quản Lý".Translate(), 1));

            return _DefaultList;
        }
    }
}
