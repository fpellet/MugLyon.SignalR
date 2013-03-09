using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MugLyon.SignalR.Demo.Hubs
{
    [HubName("moveShape")]
    public class MoveShapeHub : Hub
    {
        public void MoveShape(int x, int y)
        {
            Clients.Others.shapeMoved(x, y);
        }
    }
}