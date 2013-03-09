using System.Web.Mvc;

namespace MugLyon.SignalR.Demo.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Chat()
        {
            return View();
        }

        public virtual ActionResult ChatHub()
        {
            return View();
        }

        public virtual ActionResult MoveShape()
        {
            return View();
        }

        public virtual ActionResult Worker()
        {
            return View();
        }
    }
}
