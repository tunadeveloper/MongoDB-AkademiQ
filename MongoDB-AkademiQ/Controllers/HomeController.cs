using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.Models;

namespace MongoDB_AkademiQ.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
