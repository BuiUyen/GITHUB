using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    //Nhóm danh mục dịch vụ
    [Serializable()]
    public class DM_Intent_SubGroup : BaseModel
    {
        //Người thực hiện
        public const int LOAI_INIT = 1000;

        public int DM_Intent_SubGroupDBID { get; set; }
        public int DM_Intent_SubGroupID { get; set; }
        public int DM_Intent_GroupID { get; set; }
        public string DM_Intent_SubGroupCode { get; set; }
        public string DM_Intent_SubGroupName { get; set; }
        public int DM_Intent_SubGroupHardcode { get; set; }
        public int DM_Intent_SubGroupDisable { get; set; }

        //Contructor
        public DM_Intent_SubGroup()
        {
            DM_Intent_SubGroupHardcode = 0;
            DM_Intent_SubGroupDisable = 0;
        }

        public DM_Intent_SubGroup(int group_id, int _id, String _name, int _DM_Intent_SubGroupHardcode)
        {
            DM_Intent_GroupID = group_id;
            DM_Intent_SubGroupID = _id;
            DM_Intent_SubGroupName = _name;
            DM_Intent_SubGroupHardcode = _DM_Intent_SubGroupHardcode;
            DM_Intent_SubGroupDisable = 0;
        }

        //Method
        public static int GetID(Object data)
        {
            if (data == null)
            {
                return 0;
            }
            if (!(data is DM_Intent_SubGroup))
            {
                return 0;
            }
            return (data as DM_Intent_SubGroup).DM_Intent_SubGroupID;
        }
        public static DM_Intent_SubGroup GetDefault(Object list, String _id)
        {
            if (list == null)
            {
                return null;
            }

            if (!(list is IList<DM_Intent_SubGroup>))
            {
                return null;
            }

            IList<DM_Intent_SubGroup> list_data = list as IList<DM_Intent_SubGroup>;
            return list_data.FirstOrDefault(p => p.DM_Intent_SubGroupID.ToString() == _id);
        }
        public static DM_Intent_SubGroup GetDefault(Object list, int _id)
        {
            if (list == null)
            {
                return null;
            }

            if (!(list is IList<DM_Intent_SubGroup>))
            {
                return null;
            }

            IList<DM_Intent_SubGroup> list_data = list as IList<DM_Intent_SubGroup>;
            return list_data.FirstOrDefault(p => p.DM_Intent_SubGroupID == _id);
        }
        public static DM_Intent_SubGroup GetDefault(int _id)
        {
            DM_Intent_SubGroup data = GetDefaultList(1).FirstOrDefault(p => p.DM_Intent_SubGroupID == _id);
            if (data == null)
            {
                data = new DM_Intent_SubGroup();
            }

            return data;
        }

        public static void InitDefaultList(IList<DM_Intent_SubGroup> list_data)
        {
            _DefaultList = null;
            GetDefaultList(1);

            foreach (DM_Intent_SubGroup data in list_data)
            {
                DM_Intent_SubGroup checkdata = _DefaultList.FirstOrDefault(p => p.DM_Intent_SubGroupID == data.DM_Intent_SubGroupID);
                if (checkdata != null)
                {
                    checkdata.DM_Intent_SubGroupDBID = data.DM_Intent_SubGroupDBID;
                    checkdata.DM_Intent_SubGroupName = data.DM_Intent_SubGroupName;
                    checkdata.DM_Intent_SubGroupDisable = data.DM_Intent_SubGroupDisable;
                }
                else
                {
                    _DefaultList.Add(data);
                }
            }
        }

        private static IList<DM_Intent_SubGroup> _DefaultList = null;
        public static IList<DM_Intent_SubGroup> GetDefaultList(int include_deactive)
        {
            if (_DefaultList != null)
            {
                if (include_deactive == 0)
                {
                    //Deactive
                    _DefaultList =
                        (from p in _DefaultList
                         where p.DM_Intent_SubGroupDisable == 0
                         select p).ToList();
                }
                return _DefaultList;
            }

            _DefaultList = new List<DM_Intent_SubGroup>();

            //Loai khoa
            {
                foreach (DM_Intent_Type data in DM_Intent_Type.GetDefaultList(0))
                {
                    _DefaultList.Add(new DM_Intent_SubGroup(DM_Intent_Group.LOAI, LOAI_INIT + data.DM_Intent_TypeID, data.DM_Intent_TypeName.Translate(), 1));
                }
            }

            return _DefaultList;
        }

        public static IList<DM_Intent_SubGroup> GetDefaultList_Group(int include_deactive, int DM_Intent_GroupID)
        {
            return GetDefaultList(include_deactive).Where(p => p.DM_Intent_GroupID == DM_Intent_GroupID).ToList();
        }
    }
}
