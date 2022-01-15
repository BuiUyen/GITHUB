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
    public class UserPresenter : BasePresenter
    {
        private const String TAG = "UserPresenter";
        public static IList<User> GetUsers(IDbConnection connection, IDbTransaction trans)
        {
            return UserDB.mInstance.GetUsers(connection, trans);
        }

        public static User GetUser()
        {
            return UserDB.mInstance.GetUser();
        }

        public static User GetUser(int UserID)
        {
            return UserDB.mInstance.GetUser(UserID);
        }

        public static void UpdateUser(User data)
        {
            UserDB.mInstance.UpdateUser(null, null, data);
        }

        public static void InsertUser(User data)
        {
            UserDB.mInstance.InsertUser(null, null, data);
        }

        public static int DeleteUser(User data)
        {
            return UserDB.mInstance.DeleteUser(data);
        }
    }
}

