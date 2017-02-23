using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SrDemo1.Models
{
    public class UserData
    {
        public static readonly List<User> AllUser = new List<User>()
        {
            new User() { UserId = "A001", UserName = "张三" },
            new User() { UserId = "A002", UserName = "Lucy" },
            new User() { UserId = "A003", UserName = "小红" },
            new User() { UserId = "A004", UserName = "小明" },
            new User() { UserId = "A005", UserName = "tom" }
        };
    }
}