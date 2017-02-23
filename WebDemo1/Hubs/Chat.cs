using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebDemo1.Hubs
{
    public class Chat : Hub
    {

        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            //Clients.All.broadcastMessage(name, message);

            Clients.All.addNewMessageToPage(name, message);

        }

        //public void Hello()
        //{
        //    Clients.All.hello();
        //}
    }
}