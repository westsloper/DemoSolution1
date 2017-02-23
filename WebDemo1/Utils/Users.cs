using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo1.Utils
{
    public static class Users
    {

        private static Dictionary<string, User> UserConnDic = new Dictionary<string, User>();


        public static void ConnectUser(string userId, string userName)
        {
            if (!UserConnDic.ContainsKey(userId))
            {
                User user = new User();
                user.ID = userId;
                user.Name = userName;
                UserConnDic.Add("", user);
            }
        }

    }
}