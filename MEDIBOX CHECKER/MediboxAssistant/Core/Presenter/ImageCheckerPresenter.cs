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
    public class ImageCheckerPresenter : BasePresenter
    {
        private const String TAG = "ImageCheckerPresenter";
        public static IList<ImageChecker> GetImageCheckers()
        {
            return ImageCheckerDB.mInstance.GetImageCheckers(null,null);
        }

        public static ImageChecker GetImageChecker()
        {
            return ImageCheckerDB.mInstance.GetImageChecker();
        }

        public static ImageChecker GetImageChecker(int ImageID)
        {
            return ImageCheckerDB.mInstance.GetImageChecker(ImageID);
        }
        public static void UpdateImageChecker(ImageChecker data)
        {
            ImageCheckerDB.mInstance.UpdateImageChecker(null, null, data);
        }

        public static void InsertImageChecker(ImageChecker data)
        {
            ImageCheckerDB.mInstance.InsertImageChecker(null, null, data);
        }

        public static int DeleteImageChecker(ImageChecker data)
        {
            return ImageCheckerDB.mInstance.DeleteImageChecker(data);
        }
    }

}
