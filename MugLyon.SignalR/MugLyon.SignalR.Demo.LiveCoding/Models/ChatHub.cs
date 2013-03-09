using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MugLyon.SignalR.Demo.LiveCoding.Models
{
    public class ChatHub : Hub
    {
        public void Send(string msg)
        {
            Clients.All.newMessage(msg);
        }

        public void Echo(string msg)
        {
            Clients.Caller.newMessage(msg);
        }
    }
}