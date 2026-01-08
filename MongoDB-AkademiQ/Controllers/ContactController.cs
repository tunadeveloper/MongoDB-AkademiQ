using Microsoft.AspNetCore.Mvc;

namespace MongoDB_AkademiQ.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
