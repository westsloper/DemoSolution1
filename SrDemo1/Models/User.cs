using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SrDemo1.Models
{
    public class User
    {
        public string UserId { get; set; }


        public string UserName { get; set; }


        public Dictionary<string, MyConn> MyConnDic { get; set; }


        public User()
        {
            MyConnDic = new Dictionary<string, MyConn>();
        }
    }
}