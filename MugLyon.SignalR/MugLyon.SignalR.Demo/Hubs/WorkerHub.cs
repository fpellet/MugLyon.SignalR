using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace MugLyon.SignalR.Demo.Hubs
{
    public class Process
    {
        public string Name { get; set; }

        public void Work()
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<WorkerHub>();

            for (int i = 0; i < 100; i++)
            {
                hub.Clients.All.SetProgress(i);
                Thread.Sleep(2000);
            }

            hub.Clients.All.Notify("End");
        }
    }

    public class WorkerHub : Hub
    {
        public void DoWork(Process process)
        {
            Clients.All.Notify("Start " + process.Name + " by " + Clients.Caller.Name);

            for (int i = 0; i < 100; i++)
            {
                Clients.All.SetProgress(i);
                Thread.Sleep(2000);
            }

            Clients.All.Notify("End");
        }

        public Task DoWork2(Process process)
        {

            return ((Task)Clients.All.Notify("Start " + process.Name)).ContinueWith(_ => process.Work());
        }
    }
}