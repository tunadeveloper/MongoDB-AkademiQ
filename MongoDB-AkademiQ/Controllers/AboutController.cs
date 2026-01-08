using Microsoft.AspNetCore.Mvc;

namespace MongoDB_AkademiQ.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
