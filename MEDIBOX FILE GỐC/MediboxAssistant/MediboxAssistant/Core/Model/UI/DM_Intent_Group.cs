using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    //Nhóm danh mục loại khoa
    [Serializable()]
    public class DM_Intent_Group : BaseModel
    {
        public const int LOAI = 1;

        public int DM_Intent_GroupDBID { get; set; }
        public int DM_Intent_GroupID { get; set; }
        public string DM_Intent_GroupCode { get; set; }
        public string DM_Intent_GroupName { get; set; }
        public int DM_Intent_GroupHardcode { get; set; }
        public int DM_Intent_GroupDisable { get; set; }

        //Contructor
        public DM_Intent_Group()
        {
            DM_Intent_GroupHardcode = 0;
            DM_Intent_GroupDisable = 0;
        }

        public DM_Intent_Group(int _id, String _name, int _DM_DepartmentGroupHardcode)
        {
            DM_Intent_GroupID = _id;
            DM_Intent_GroupName = _name;
            DM_Intent_GroupHardcode = _DM_DepartmentGroupHardcode;
            DM_Intent_GroupDisable = 0;
        }

        //Method
        public static int GetID(Object data)
        {
            if (data == null)
            {
                return 0;
            }
            if (!(data is DM_Intent_Group))
            {
                return 0;
            }
            return (data as DM_Intent_Group).DM_Intent_GroupID;
        }
        public static DM_Intent_Group GetDefault(Object list, String _id)
        {
            if (list == null)
            {
                return null;
            }

            if (!(list is IList<DM_Intent_Group>))
            {
                return null;
            }

            IList<DM_Intent_Group> list_data = list as IList<DM_Intent_Group>;
            return list_data.FirstOrDefault(p => p.DM_Intent_GroupID.ToString() == _id);
        }
        public static DM_Intent_Group GetDefault(Object list, int _id)
        {
            if (list == null)
            {
                return null;
            }

            if (!(list is IList<DM_Intent_Group>))
            {
                return null;
            }

            IList<DM_Intent_Group> list_data = list as IList<DM_Intent_Group>;
            return list_data.FirstOrDefault(p => p.DM_Intent_GroupID == _id);
        }
        public static DM_Intent_Group GetDefault(int _id)
        {
            DM_Intent_Group data = GetDefaultList(1).FirstOrDefault(p => p.DM_Intent_GroupID == _id);
            if (data == null)
            {
                data = new DM_Intent_Group();
            }

            return data;
        }

        public static void InitDefaultList(IList<DM_Intent_Group> list_data)
        {
            _DefaultList = null;
            GetDefaultList(1);

            foreach (DM_Intent_Group data in list_data)
            {
                DM_Intent_Group checkdata = _DefaultList.FirstOrDefault(p => p.DM_Intent_GroupID == data.DM_Intent_GroupID);
                if (checkdata != null)
                {
                    checkdata.DM_Intent_GroupDBID = data.DM_Intent_GroupDBID;
                    checkdata.DM_Intent_GroupName = data.DM_Intent_GroupName;
                    checkdata.DM_Intent_GroupDisable = data.DM_Intent_GroupDisable;
                }
                else
                {
                    _DefaultList.Add(data);
                }
            }
        }

        private static IList<DM_Intent_Group> _DefaultList = null;
        public static IList<DM_Intent_Group> GetDefaultList(int include_deactive)
        {
            if (_DefaultList != null)
            {
                if (include_deactive == 0)
                {
                    //Deactive
                    _DefaultList =
                        (from p in _DefaultList
                         where p.DM_Intent_GroupDisable == 0
                         select p).ToList();
                }
                return _DefaultList;
            }

            _DefaultList = new List<DM_Intent_Group>();

            _DefaultList.Add(new DM_Intent_Group(LOAI, "Type".Translate(), 1));

            return _DefaultList;
        }
    }
}
