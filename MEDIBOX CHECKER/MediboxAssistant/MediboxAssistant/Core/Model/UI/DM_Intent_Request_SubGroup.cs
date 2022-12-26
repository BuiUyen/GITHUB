using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    //Nhóm danh mục dịch vụ
    [Serializable()]
    public class DM_Intent_Request_SubGroup : BaseModel
    {
        //Người thực hiện
        public const int INTENT_INIT = 1000;
        public const int ENTITY_INIT = 2000;

        public int DM_Intent_Request_SubGroupDBID { get; set; }
        public int DM_Intent_Request_SubGroupID { get; set; }
        public int DM_Intent_Request_GroupID { get; set; }
        public string DM_Intent_Request_SubGroupCode { get; set; }
        public string DM_Intent_Request_SubGroupName { get; set; }
        public int DM_Intent_Request_SubGroupHardcode { get; set; }
        public int DM_Intent_Request_SubGroupDisable { get; set; }

        //Contructor
        public DM_Intent_Request_SubGroup()
        {
            DM_Intent_Request_SubGroupHardcode = 0;
            DM_Intent_Request_SubGroupDisable = 0;
        }

        public DM_Intent_Request_SubGroup(int group_id, int _id, String _name, int _DM_Intent_Request_SubGroupHardcode)
        {
            DM_Intent_Request_GroupID = group_id;
            DM_Intent_Request_SubGroupID = _id;
            DM_Intent_Request_SubGroupName = _name;
            DM_Intent_Request_SubGroupHardcode = _DM_Intent_Request_SubGroupHardcode;
            DM_Intent_Request_SubGroupDisable = 0;
        }

        //Method
        public static int GetID(Object data)
        {
            if (data == null)
            {
                return 0;
            }
            if (!(data is DM_Intent_Request_SubGroup))
            {
                return 0;
            }
            return (data as DM_Intent_Request_SubGroup).DM_Intent_Request_SubGroupID;
        }
        public static DM_Intent_Request_SubGroup GetDefault(Object list, String _id)
        {
            if (list == null)
            {
                return null;
            }

            if (!(list is IList<DM_Intent_Request_SubGroup>))
            {
                return null;
            }

            IList<DM_Intent_Request_SubGroup> list_data = list as IList<DM_Intent_Request_SubGroup>;
            return list_data.FirstOrDefault(p => p.DM_Intent_Request_SubGroupID.ToString() == _id);
        }
        public static DM_Intent_Request_SubGroup GetDefault(Object list, int _id)
        {
            if (list == null)
            {
                return null;
            }

            if (!(list is IList<DM_Intent_Request_SubGroup>))
            {
                return null;
            }

            IList<DM_Intent_Request_SubGroup> list_data = list as IList<DM_Intent_Request_SubGroup>;
            return list_data.FirstOrDefault(p => p.DM_Intent_Request_SubGroupID == _id);
        }
        public static DM_Intent_Request_SubGroup GetDefault(int _id)
        {
            DM_Intent_Request_SubGroup data = GetDefaultList(1).FirstOrDefault(p => p.DM_Intent_Request_SubGroupID == _id);
            if (data == null)
            {
                data = new DM_Intent_Request_SubGroup();
            }

            return data;
        }

        public static void InitDefaultList(IList<DM_Intent_Request_SubGroup> list_data)
        {
            _DefaultList = null;
            GetDefaultList(1);

            foreach (DM_Intent_Request_SubGroup data in list_data)
            {
                DM_Intent_Request_SubGroup checkdata = _DefaultList.FirstOrDefault(p => p.DM_Intent_Request_SubGroupID == data.DM_Intent_Request_SubGroupID);
                if (checkdata != null)
                {
                    checkdata.DM_Intent_Request_SubGroupDBID = data.DM_Intent_Request_SubGroupDBID;
                    checkdata.DM_Intent_Request_SubGroupName = data.DM_Intent_Request_SubGroupName;
                    checkdata.DM_Intent_Request_SubGroupDisable = data.DM_Intent_Request_SubGroupDisable;
                }
                else
                {
                    _DefaultList.Add(data);
                }
            }
        }

        private static IList<DM_Intent_Request_SubGroup> _DefaultList = null;
        public static IList<DM_Intent_Request_SubGroup> GetDefaultList(int include_deactive)
        {
            if (_DefaultList != null)
            {
                if (include_deactive == 0)
                {
                    //Deactive
                    _DefaultList =
                        (from p in _DefaultList
                         where p.DM_Intent_Request_SubGroupDisable == 0
                         select p).ToList();
                }
                return _DefaultList;
            }

            _DefaultList = new List<DM_Intent_Request_SubGroup>();

            //Loai
            {
                foreach (DM_Intent_Type data in DM_Intent_Type.GetDefaultList(0))
                {
                    _DefaultList.Add(new DM_Intent_Request_SubGroup(DM_Intent_Request_Group.INTENT, INTENT_INIT + data.DM_Intent_TypeID, data.DM_Intent_TypeName.Translate(), 1));
                }
            }

            //Loai
            {
                foreach (DM_Entity_Type data in DM_Entity_Type.GetDefaultList(0))
                {
                    _DefaultList.Add(new DM_Intent_Request_SubGroup(DM_Intent_Request_Group.ENTITY, ENTITY_INIT + data.DM_Entity_TypeID, data.DM_Entity_TypeName.Translate(), 1));
                }
            }

            return _DefaultList;
        }

        public static IList<DM_Intent_Request_SubGroup> GetDefaultList_Group(int include_deactive, int DM_Intent_Request_GroupID)
        {
            return GetDefaultList(include_deactive).Where(p => p.DM_Intent_Request_GroupID == DM_Intent_Request_GroupID).ToList();
        }
    }
}
