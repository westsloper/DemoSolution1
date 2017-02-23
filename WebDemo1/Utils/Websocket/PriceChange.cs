using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using WebDemo1.Hubs;

namespace WebDemo1.Utils.Websocket
{
    public class PriceChange
    {
        private string Name { get; set; }
        public PriceChange(string name)
        {
            Name = name;
        }

        public void BroadcastChangedPrice()
        {
            var clients = GlobalHost.ConnectionManager.GetHubContext<Chat>().Clients;
            for (int i = 0; i < 20; i++)
            {
                string message = string.Format("price {0}:{1}", i + 1, new Random(i).Next());
                clients.All.addNewMessageToPage(Name, message);
                Thread.Sleep(2000);
            }
            
        }
    }
}