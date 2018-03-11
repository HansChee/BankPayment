using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankPayment.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HomeController));

        public IActionResult Index()
        {
            log.Info("Enter Home Index");

            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
