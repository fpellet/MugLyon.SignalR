using System.Web;
using System.Web.Mvc;

namespace MugLyon.SignalR.SharedWhiteboard
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}