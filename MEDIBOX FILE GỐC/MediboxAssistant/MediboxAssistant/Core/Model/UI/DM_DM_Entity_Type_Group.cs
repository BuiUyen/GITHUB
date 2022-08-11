using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    //Nhóm danh mục loại khoa
    [Serializable()]
    public class DM_DM_Entity_Type_Group : BaseModel
    {
        public const int INTENT = 1;

        public int DM_DM_Entity_Type_GroupDBID { get; set; }
        public int DM_DM_Entity_Type_GroupID { get; set; }
        public string DM_DM_Entity_Type_GroupCode { get; set; }
        public string DM_DM_Entity_Type_GroupName { get; set; }
        public int DM_DM_Entity_Type_GroupHardcode { get; set; }
        public int DM_DM_Entity_Type_GroupDisable { get; set; }

        //Contructor
        public DM_DM_Entity_Type_Group()
        {
            DM_DM_Entity_Type_GroupHardcode = 0;
            DM_DM_Entity_Type_GroupDisable = 0;
        }

        public DM_DM_Entity_Type_Group(int _id, String _name, int _DM_DepartmentGroupHardcode)
        {
            DM_DM_Entity_Type_GroupID = _id;
            DM_DM_Entity_Type_GroupName = _name;
            DM_DM_Entity_Type_GroupHardcode = _DM_DepartmentGroupHardcode;
            DM_DM_Entity_Type_GroupDisable = 0;
        }

        //Method
        public static int GetID(Object data)
        {
            if (data == null)
            {
                return 0;
            }
            if (!(data is DM_DM_Entity_Type_Group))
            {
                return 0;
            }
            return (data as DM_DM_Entity_Type_Group).DM_DM_Entity_Type_GroupID;
        }
        public static DM_DM_Entity_Type_Group GetDefault(Object list, String _id)
        {
            if (list == null)
            {
                return null;
            }

            if (!(list is IList<DM_DM_Entity_Type_Group>))
            {
                return null;
            }

            IList<DM_DM_Entity_Type_Group> list_data = list as IList<DM_DM_Entity_Type_Group>;
            return list_data.FirstOrDefault(p => p.DM_DM_Entity_Type_GroupID.ToString() == _id);
        }
        public static DM_DM_Entity_Type_Group GetDefault(Object list, int _id)
        {
            if (list == null)
            {
                return null;
            }

            if (!(list is IList<DM_DM_Entity_Type_Group>))
            {
                return null;
            }

            IList<DM_DM_Entity_Type_Group> list_data = list as IList<DM_DM_Entity_Type_Group>;
            return list_data.FirstOrDefault(p => p.DM_DM_Entity_Type_GroupID == _id);
        }
        public static DM_DM_Entity_Type_Group GetDefault(int _id)
        {
            DM_DM_Entity_Type_Group data = GetDefaultList(1).FirstOrDefault(p => p.DM_DM_Entity_Type_GroupID == _id);
            if (data == null)
            {
                data = new DM_DM_Entity_Type_Group();
            }

            return data;
        }

        public static void InitDefaultList(IList<DM_DM_Entity_Type_Group> list_data)
        {
            _DefaultList = null;
            GetDefaultList(1);

            foreach (DM_DM_Entity_Type_Group data in list_data)
            {
                DM_DM_Entity_Type_Group checkdata = _DefaultList.FirstOrDefault(p => p.DM_DM_Entity_Type_GroupID == data.DM_DM_Entity_Type_GroupID);
                if (checkdata != null)
                {
                    checkdata.DM_DM_Entity_Type_GroupDBID = data.DM_DM_Entity_Type_GroupDBID;
                    checkdata.DM_DM_Entity_Type_GroupName = data.DM_DM_Entity_Type_GroupName;
                    checkdata.DM_DM_Entity_Type_GroupDisable = data.DM_DM_Entity_Type_GroupDisable;
                }
                else
                {
                    _DefaultList.Add(data);
                }
            }
        }

        private static IList<DM_DM_Entity_Type_Group> _DefaultList = null;
        public static IList<DM_DM_Entity_Type_Group> GetDefaultList(int include_deactive)
        {
            if (_DefaultList != null)
            {
                if (include_deactive == 0)
                {
                    //Deactive
                    _DefaultList =
                        (from p in _DefaultList
                         where p.DM_DM_Entity_Type_GroupDisable == 0
                         select p).ToList();
                }
                return _DefaultList;
            }

            _DefaultList = new List<DM_DM_Entity_Type_Group>();

            _DefaultList.Add(new DM_DM_Entity_Type_Group(INTENT, "Chủ Đề".Translate(), 1));

            return _DefaultList;
        }
    }
}
