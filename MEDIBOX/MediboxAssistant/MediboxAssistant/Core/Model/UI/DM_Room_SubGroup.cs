using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    //Nhóm danh mục dịch vụ
    [Serializable()]
    public class DM_Room_SubGroup : BaseModel
    {
        //Người thực hiện
        public const int HOME_INIT = 1000;
        public const int USER_INIT = 2000;

        public int DM_Room_SubGroupDBID { get; set; }
        public int DM_Room_SubGroupID { get; set; }
        public int DM_Room_GroupID { get; set; }
        public string DM_Room_SubGroupCode { get; set; }
        public string DM_Room_SubGroupName { get; set; }
        public int DM_Room_SubGroupHardcode { get; set; }
        public int DM_Room_SubGroupDisable { get; set; }

        //Contructor
        public DM_Room_SubGroup()
        {
            DM_Room_SubGroupHardcode = 0;
            DM_Room_SubGroupDisable = 0;
        }

        public DM_Room_SubGroup(int group_id, int _id, String _name, int _DM_Room_SubGroupHardcode)
        {
            DM_Room_GroupID = group_id;
            DM_Room_SubGroupID = _id;
            DM_Room_SubGroupName = _name;
            DM_Room_SubGroupHardcode = _DM_Room_SubGroupHardcode;
            DM_Room_SubGroupDisable = 0;
        }

        //Method
        public static int GetID(Object data)
        {
            if (data == null)
            {
                return 0;
            }
            if (!(data is DM_Room_SubGroup))
            {
                return 0;
            }
            return (data as DM_Room_SubGroup).DM_Room_SubGroupID;
        }
        public static DM_Room_SubGroup GetDefault(Object list, String _id)
        {
            if (list == null)
            {
                return null;
            }

            if (!(list is IList<DM_Room_SubGroup>))
            {
                return null;
            }

            IList<DM_Room_SubGroup> list_data = list as IList<DM_Room_SubGroup>;
            return list_data.FirstOrDefault(p => p.DM_Room_SubGroupID.ToString() == _id);
        }
        public static DM_Room_SubGroup GetDefault(Object list, int _id)
        {
            if (list == null)
            {
                return null;
            }

            if (!(list is IList<DM_Room_SubGroup>))
            {
                return null;
            }

            IList<DM_Room_SubGroup> list_data = list as IList<DM_Room_SubGroup>;
            return list_data.FirstOrDefault(p => p.DM_Room_SubGroupID == _id);
        }
        public static DM_Room_SubGroup GetDefault(int _id)
        {
            DM_Room_SubGroup data = GetDefaultList(1).FirstOrDefault(p => p.DM_Room_SubGroupID == _id);
            if (data == null)
            {
                data = new DM_Room_SubGroup();
            }

            return data;
        }

        public static void InitDefaultList(IList<DM_Room_SubGroup> list_data)
        {
            _DefaultList = null;
            GetDefaultList(1);

            foreach (DM_Room_SubGroup data in list_data)
            {
                DM_Room_SubGroup checkdata = _DefaultList.FirstOrDefault(p => p.DM_Room_SubGroupID == data.DM_Room_SubGroupID);
                if (checkdata != null)
                {
                    checkdata.DM_Room_SubGroupDBID = data.DM_Room_SubGroupDBID;
                    checkdata.DM_Room_SubGroupName = data.DM_Room_SubGroupName;
                    checkdata.DM_Room_SubGroupDisable = data.DM_Room_SubGroupDisable;
                }
                else
                {
                    _DefaultList.Add(data);
                }
            }
        }

        private static IList<DM_Room_SubGroup> _DefaultList = null;
        public static IList<DM_Room_SubGroup> GetDefaultList(int include_deactive)
        {
            if (_DefaultList != null)
            {
                if (include_deactive == 0)
                {
                    //Deactive
                    _DefaultList =
                        (from p in _DefaultList
                         where p.DM_Room_SubGroupDisable == 0
                         select p).ToList();
                }
                return _DefaultList;
            }

            _DefaultList = new List<DM_Room_SubGroup>();

            {
                foreach (Home data in MyVar.mListHome)
                {
                    _DefaultList.Add(new DM_Room_SubGroup(DM_Room_Group.HOME, HOME_INIT + data.HomeID, data.HomeName.Translate(), 1));
                }
            }

            {
                foreach (User data in MyVar.mListUser)
                {
                    _DefaultList.Add(new DM_Room_SubGroup(DM_Room_Group.USER, USER_INIT + data.UserID, data.UserName.Translate(), 1));
                }
            }

            return _DefaultList;
        }

        public static IList<DM_Room_SubGroup> GetDefaultList_Group(int include_deactive, int DM_Room_GroupID)
        {
            return GetDefaultList(include_deactive).Where(p => p.DM_Room_GroupID == DM_Room_GroupID).ToList();
        }
    }
}
