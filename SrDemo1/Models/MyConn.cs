using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SrDemo1.Models
{
    public class MyConn
    {
        public string MyUserId { get; set; }

        public HubType MyHubType { get; set; }


        public string MyConnId { get; set; }


        public MyConn(string userId, HubType type, string connId)
        {
            MyUserId = userId;
            MyHubType = type;
            MyConnId = connId;
        }
    }
}