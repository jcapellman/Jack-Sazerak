using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using JackSazerak.Web.Models;

namespace JackSazerak.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}