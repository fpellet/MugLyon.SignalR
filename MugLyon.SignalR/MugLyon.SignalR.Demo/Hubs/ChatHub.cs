using Microsoft.AspNet.SignalR;

namespace MugLyon.SignalR.Demo.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.newMessage(message);
        }

        public void Echo(string message)
        {
            Clients.Caller.newMessage(message);
        }
    }
}