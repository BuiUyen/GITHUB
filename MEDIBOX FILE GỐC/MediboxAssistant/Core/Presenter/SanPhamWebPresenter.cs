using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Medibox.Database;
using Medibox.Model;
using Sanita.Utility.Database.BaseDao;
using Sanita.Utility.Database.Utility;
using Sanita.Utility.ExtendedThread;

namespace Medibox.Presenter
{

    public class SanPhamWebPresenter : BasePresenter
    {
        private const String TAG = "SanPhamWebPresenter";
        public static IList<SanPhamWeb> GetSanPhamWebs()
        {
            return SanPhamWebDB.mInstance.GetSanPhamWebs();
        }

        public static SanPhamWeb GetSanPhamWeb()
        {
            return SanPhamWebDB.mInstance.GetSanPhamWeb();
        }

        public static SanPhamWeb GetSanPhamWeb(int SanPhamWebID)
        {
            return SanPhamWebDB.mInstance.GetSanPhamWeb(SanPhamWebID);
        }
        public static void UpdateSanPhamWeb(SanPhamWeb data)
        {
            SanPhamWebDB.mInstance.UpdateSanPhamWeb(null, null, data);
        }

        public static void InsertSanPhamWeb(SanPhamWeb data)
        {
            SanPhamWebDB.mInstance.InsertSanPhamWeb(null, null, data);
        }

        public static int DeleteSanPhamWeb(SanPhamWeb data)
        {
            return SanPhamWebDB.mInstance.DeleteSanPhamWeb(data);
        }

        public static int DeleteAllSanPhamWeb()
        {
            return SanPhamWebDB.mInstance.DeleteAllSanPhamWeb();
        }
    }
}

