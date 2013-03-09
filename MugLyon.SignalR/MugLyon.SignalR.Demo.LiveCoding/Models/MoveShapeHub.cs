using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MugLyon.SignalR.Demo.LiveCoding.Models
{
    [HubName("moveShape")]
    public class MoveShapeHub : Hub
    {
        public void MoveShape(int x, int y)
        {
            Clients.Others.SHAPEMoved(x, y);
        }
    }
}