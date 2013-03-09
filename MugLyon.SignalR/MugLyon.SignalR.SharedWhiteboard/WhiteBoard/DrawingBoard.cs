using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace MugLyon.SignalR.SharedWhiteboard.WhiteBoard
{
    public class DrawingBoard : Hub
    {
        public Task BroadcastPoint(int x, int y)
        {
            return Clients.Others.drawPoint(x, y, Clients.Caller.color);
        }
        public Task BroadcastClear()
        {
            return Clients.Others.clear();
        }
    } 
}