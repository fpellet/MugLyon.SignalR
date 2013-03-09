using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace MugLyon.SignalR.Demo.LiveCoding.Models
{
    public class WorkerHub : Hub
    {
        public void DoWork(ProgressModel progress)
        {
            Clients.Caller.Name = "joe2";
            ((Task)Clients.All.Notify("Start " + progress.Name)).ContinueWith(o =>
                {
                    Clients.All.Notify("End");
                });

            //for (var i = 1; i < 100; i++)
            //{
            //    Thread.Sleep(2000);
            //    Clients.All.SetProgress(i);
            //}

            //Clients.All.Notify("End");
        }

        public void DoWork2(ProgressModel progress)
        {
            var name = Clients.Caller.Name as string;
            Task.Run(() => progress.Execute(name));
        }
    }

    public class ProgressModel
    {
        public string Name { get; set; }

        public void Execute(string user)
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<WorkerHub>();

            hub.Clients.All.Notify(user + " Start " + Name);

            for (var i = 1; i < 100; i++)
            {
                Thread.Sleep(2000);
                hub.Clients.All.SetProgress(i);
            }

            hub.Clients.All.Notify("End");
        }
    }
}