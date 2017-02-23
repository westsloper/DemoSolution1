using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using SrDemo1.Models;

namespace SrDemo1.Hubs.Chat
{
    public class Chat : Hub
    {
        public const HubType MyHubType = HubType.Chat;

        public void SendToAll(string message)
        {
            Clients.All.addMessage("dd", message);
            
        }


        public void Send(string userId, string message)
        {
            List<string> connIdList = UserCache.GetConnectionId(userId, MyHubType);
            foreach (var connId in connIdList)
            {
                Clients.Client(connId).addMessage("power by Chat Send", message);
            }
        }


        public override Task OnConnected()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                string userId = Context.User.Identity.Name;
                MyConn conn = new MyConn(userId, MyHubType, Context.ConnectionId);
                UserCache.AddUserConn(conn);
            }

            return base.OnConnected();
        }


        public override Task OnDisconnected()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                string userId = Context.User.Identity.Name;
                MyConn conn = new MyConn(userId, MyHubType, Context.ConnectionId);
                UserCache.RemoveUserConn(conn);
            }

            return base.OnDisconnected();
        }


        public override Task OnReconnected()
        {

            return base.OnReconnected();
        }
    }
}