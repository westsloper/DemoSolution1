using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebDemo1.Hubs;
using WebDemo1.Utils.Websocket;

namespace WebDemo1.Controllers
{
    public class WebsocketController : Controller
    {
        // GET: Websocket
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult ChatUser1([FromUri]string n, [FromUri]string m)
        {
            n = string.IsNullOrWhiteSpace(n) ? "测试用户" : n.Trim();
            m = string.IsNullOrWhiteSpace(m) ? "测试消息" : m.Trim();
            PriceChange priceChange = new PriceChange(n);
            priceChange.BroadcastChangedPrice();

            return View();
        }


        public ActionResult Login()
        {
            string id = Session.SessionID;

            return View();
        }
    }
}