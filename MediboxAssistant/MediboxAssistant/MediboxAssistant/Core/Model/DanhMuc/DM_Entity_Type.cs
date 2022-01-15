using System;
using System.Collections.Generic;
using System.Linq;

namespace Medibox.Model
{
    [Serializable()]
    public class DM_Entity_Type
    {
        public const int THOI_GIAN_HOM_NAY = DM_Intent_Type.THOI_GIAN * 1000 + 1;
        public const int THOI_GIAN_AM_LICH_HOM_NAY = DM_Intent_Type.THOI_GIAN * 1000 + 2;
        public const int THOI_GIAN_HOM_NAY_DIA_DIEM = DM_Intent_Type.THOI_GIAN * 1000 + 3;

        public const int NGAY_THANG_HOM_NAY = DM_Intent_Type.NGAY_THANG * 1000 + 1;
        public const int NGAY_THANG_NGAY_MAI = DM_Intent_Type.NGAY_THANG * 1000 + 2;
        public const int NGAY_THANG_AM_LICH_HOM_NAY = DM_Intent_Type.NGAY_THANG * 1000 + 3;
        public const int NGAY_THANG_AM_LICH_NGAY_MAI = DM_Intent_Type.NGAY_THANG * 1000 + 4;

        public const int THOI_TIET_HOM_NAY = DM_Intent_Type.THOI_TIET * 1000 + 1;
        public const int THOI_TIET_NGAY_MAI = DM_Intent_Type.THOI_TIET * 1000 + 2;
        public const int THOI_TIET_3_NGAY_TOI = DM_Intent_Type.THOI_TIET * 1000 + 3;

        public const int KE_CHUYEN_CUOI = DM_Intent_Type.KE_CHUYEN * 1000 + 1;
        public const int KE_CHUYEN_KHAC = DM_Intent_Type.KE_CHUYEN * 1000 + 2;
        public const int KE_CHUYEN_HAT = DM_Intent_Type.KE_CHUYEN * 1000 + 3;

        public const int LINH_TINH_TEN_DEVICE = DM_Intent_Type.LINH_TINH * 1000 + 1;
        public const int LINH_TINH_TEN_OWNER = DM_Intent_Type.LINH_TINH * 1000 + 2;
        public const int LINH_TINH_WHERE_DEVICE = DM_Intent_Type.LINH_TINH * 1000 + 3;
        public const int LINH_TINH_WHERE_OWNER = DM_Intent_Type.LINH_TINH * 1000 + 4;

        public const int TIN_TUC_TONG_HOP = DM_Intent_Type.TIN_TUC * 1000 + 1;
        public const int TIN_TUC_VN_EXPRESS = DM_Intent_Type.TIN_TUC * 1000 + 2;
        public const int TIN_TUC_VN_DAN_TRI = DM_Intent_Type.TIN_TUC * 1000 + 3;

        public const int WIKI_LA_AI = DM_Intent_Type.WIKI * 1000 + 1;
        public const int WIKI_LA_GI = DM_Intent_Type.WIKI * 1000 + 2;
        public const int WIKI_DINH_NGHIA = DM_Intent_Type.WIKI * 1000 + 3;

        public const int HOME_CONTROL_BAT_THIET_VI = DM_Intent_Type.HOME_CONTROL * 1000 + 1;
        public const int HOME_CONTROL_TAT_THIET_VI = DM_Intent_Type.HOME_CONTROL * 1000 + 2;
        public const int HOME_CONTROL_KIEM_TRA_THIET_VI = DM_Intent_Type.HOME_CONTROL * 1000 + 3;

        public int DM_Entity_TypeDBID { get; set; }
        public int DM_Entity_TypeID { get; set; }
        public int DM_Intent_TypeID { get; set; }
        public string DM_Entity_TypeName { get; set; }
        public int DM_Entity_TypeHardcode { get; set; }
        public int DM_Entity_TypeDisable { get; set; }

        //Ref
        public IList<DM_Entity_Type> mListSubData { get; set; }

        //Contructor
        public DM_Entity_Type()
        {
            DM_Entity_TypeHardcode = 0;
            DM_Entity_TypeDisable = 0;
        }

        public DM_Entity_Type(int _intent_id, int _id, String _name, int _DM_Entity_TypeHardcode)
        {
            DM_Entity_TypeID = _id;
            DM_Intent_TypeID = _intent_id;
            DM_Entity_TypeName = _name;
            DM_Entity_TypeHardcode = _DM_Entity_TypeHardcode;
            DM_Entity_TypeDisable = 0;
        }

        //Method
        public static int GetID(String name, int idintent)
        {
            DM_Entity_Type data = DM_Entity_Type.GetDefaultList(0).FirstOrDefault(p => p != null && p.DM_Entity_TypeName == name && p.DM_Intent_TypeID == idintent);
            data = data ?? new DM_Entity_Type();
            return data.DM_Entity_TypeID;
        }

        public static int GetID(Object data)
        {
            if (data == null)
            {
                return 0;
            }
            if (!(data is DM_Entity_Type))
            {
                return 0;
            }
            return (data as DM_Entity_Type).DM_Entity_TypeID;
        }
        public static DM_Entity_Type GetDefault(Object list, int _id)
        {
            if (list == null)
            {
                return null;
            }

            if (!(list is IList<DM_Entity_Type>))
            {
                return null;
            }

            IList<DM_Entity_Type> list_data = list as IList<DM_Entity_Type>;
            return list_data.FirstOrDefault(p => p.DM_Entity_TypeID == _id);
        }

        public static DM_Entity_Type GetDefault(int _id)
        {
            DM_Entity_Type data = GetDefaultList(0).FirstOrDefault(p => p.DM_Entity_TypeID == _id);
            if (data == null)
            {
                data = new DM_Entity_Type();
            }

            return data;
        }

        private static IList<DM_Entity_Type> _DefaultList = null;
        public static void InitDefaultList(IList<DM_Entity_Type> list_data)
        {
            _DefaultList = null;
            GetDefaultList(1);

            foreach (DM_Entity_Type data in list_data)
            {
                DM_Entity_Type checkdata = _DefaultList.FirstOrDefault(p => p.DM_Entity_TypeID == data.DM_Entity_TypeID);
                if (checkdata != null)
                {
                    checkdata.DM_Entity_TypeDBID = data.DM_Entity_TypeDBID;
                    checkdata.DM_Entity_TypeID = data.DM_Entity_TypeID;
                    checkdata.DM_Entity_TypeName = data.DM_Entity_TypeName;
                    checkdata.DM_Entity_TypeDisable = data.DM_Entity_TypeDisable;
                    checkdata.DM_Entity_TypeHardcode = data.DM_Entity_TypeHardcode;
                }
                else
                {
                    _DefaultList.Add(data);
                }
            }
        }

        public static IList<DM_Entity_Type> GetDefaultList(int include_deactive)
        {
            if (_DefaultList != null)
            {
                if (include_deactive == 0)
                {
                    //Deactive
                    _DefaultList =
                        (from p in _DefaultList
                         where p.DM_Entity_TypeDisable == 0
                         select p).ToList();
                }
                return _DefaultList;
            }
            _DefaultList = new List<DM_Entity_Type>();

            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.THOI_GIAN, 0, "(Chưa phân loại)".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.THOI_GIAN, THOI_GIAN_HOM_NAY, "Lịch dương hiện tại".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.THOI_GIAN, THOI_GIAN_AM_LICH_HOM_NAY, "Lịch âm hiện tại".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.THOI_GIAN, THOI_GIAN_HOM_NAY_DIA_DIEM, "Thời gian hiện tại ở 1 địa điểm nào đó".Translate(), 1));

            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.NGAY_THANG, 0, "(Chưa phân loại)".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.NGAY_THANG, NGAY_THANG_HOM_NAY, "Lịch dương hôm nay".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.NGAY_THANG, NGAY_THANG_NGAY_MAI, "Lịch dương ngày mai".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.NGAY_THANG, NGAY_THANG_AM_LICH_HOM_NAY, "Lịch âm hôm nay".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.NGAY_THANG, NGAY_THANG_AM_LICH_NGAY_MAI, "Lịch âm ngày mai".Translate(), 1));

            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.THOI_TIET, 0, "(Chưa phân loại)".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.THOI_TIET, THOI_TIET_HOM_NAY, "Thời tiết hôm nay".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.THOI_TIET, THOI_TIET_NGAY_MAI, "Thời tiết ngày mai".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.THOI_TIET, THOI_TIET_3_NGAY_TOI, "Thời tiết 3 ngày tới".Translate(), 1));

            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.KE_CHUYEN, 0, "(Chưa phân loại)".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.KE_CHUYEN, KE_CHUYEN_CUOI, "Kể chuyện cười".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.KE_CHUYEN, KE_CHUYEN_KHAC, "Kể chuyện khác chưa phân loại".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.KE_CHUYEN, KE_CHUYEN_HAT, "Hát".Translate(), 1));

            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.LINH_TINH, 0, "(Chưa phân loại)".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.LINH_TINH, LINH_TINH_TEN_DEVICE, "Hỏi tên trợ lý ảo".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.LINH_TINH, LINH_TINH_TEN_OWNER, "Hỏi chủ của thiết bị".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.LINH_TINH, LINH_TINH_WHERE_DEVICE, "Hỏi địa chỉ trợ lý ảo".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.LINH_TINH, LINH_TINH_WHERE_OWNER, "Hỏi địa chị của chủ thiết bị".Translate(), 1));

            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.TIN_TUC, 0, "(Chưa phân loại)".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.TIN_TUC, TIN_TUC_TONG_HOP, "Tin tức tổng hợp".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.TIN_TUC, TIN_TUC_VN_DAN_TRI, "Tin tức dân trí".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.TIN_TUC, TIN_TUC_VN_EXPRESS, "Tin tức vnexpress".Translate(), 1));

            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.WIKI, 0, "(Chưa phân loại)".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.WIKI, WIKI_LA_AI, "Hỏi về ai đó".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.WIKI, WIKI_LA_GI, "Hỏi về cái gì đó".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.WIKI, WIKI_DINH_NGHIA, "Định nghĩa cái gì đó".Translate(), 1));

            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.HOME_CONTROL, 0, "(Chưa phân loại)".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.HOME_CONTROL, HOME_CONTROL_BAT_THIET_VI, "Bật thiết bị".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.HOME_CONTROL, HOME_CONTROL_TAT_THIET_VI, "Tắt thiết bị".Translate(), 1));
            _DefaultList.Add(new DM_Entity_Type(DM_Intent_Type.HOME_CONTROL, HOME_CONTROL_KIEM_TRA_THIET_VI, "Kiểm tra trạng thái thiết bị".Translate(), 1));

            return _DefaultList;
        }
    }
}
