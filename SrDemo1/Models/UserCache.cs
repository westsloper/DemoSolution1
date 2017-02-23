using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SrDemo1.Models
{
    public static class UserCache
    {
        public static Dictionary<string, User> UserDic = new Dictionary<string, User>();


        public static void AddUserConn(MyConn conn)
        {
            if (conn != null)
            {
                string userId = conn.MyUserId;
                if (!string.IsNullOrWhiteSpace(userId))
                {
                    User user;
                    if (!UserDic.ContainsKey(userId))
                    {
                        user = new User();
                        user.UserId = userId;
                        user.UserName = string.Format("user_{0}", userId);
                        user.MyConnDic.Add(conn.MyConnId, conn);
                        UserDic.Add(userId, user);
                    }
                    else
                    {
                        user = UserDic[userId];
                        if (!user.MyConnDic.ContainsKey(conn.MyConnId))
                        {
                            user.MyConnDic.Add(conn.MyConnId, conn);
                        }
                    }
                }
            }
        }

        public static void RemoveUserConn(MyConn conn)
        {
            if (conn != null)
            {
                string userId = conn.MyUserId;
                if (!string.IsNullOrWhiteSpace(userId))
                {
                    User user;
                    if (UserDic.ContainsKey(userId))
                    {
                        user = UserDic[userId];
                        user.MyConnDic.Remove(conn.MyConnId);
                    }
                }
            }
        }


        public static List<string> GetConnectionId(string userId, HubType type)
        {
            List<string> idList = new List<string>();
            if (UserDic != null)
            {
                User user = UserDic[userId];
                if (user != null)
                {
                    idList = user.MyConnDic.Where(d => d.Value.MyHubType == type).Select(d => d.Value.MyConnId).ToList();
                }
            }
            return idList;
        }
    }
}