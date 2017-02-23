using Microsoft.AspNet.SignalR;
using SrDemo1.Hubs.Chat;
using SrDemo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace SrDemo1.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index([FromUri]string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                FormsAuthentication.SetAuthCookie(id, false);
            }
            return View();
        }


        public ActionResult ChatUser1()
        {
            string userId = "A003";
            var clients = GlobalHost.ConnectionManager.GetHubContext<Chat>().Clients;
            List<string> connIdList = UserCache.GetConnectionId(userId, Chat.MyHubType);
            foreach (var connId in connIdList)
            {
                clients.Client(connId).addMessage("power by Chat Send", "message to A003");
            }
            return View();
        }
        
    }
}