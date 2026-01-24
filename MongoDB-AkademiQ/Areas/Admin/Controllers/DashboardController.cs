using Microsoft.AspNetCore.Mvc;

namespace MongoDB_AkademiQ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var adminName = HttpContext.Session.GetString("AdminName");
            if (string.IsNullOrEmpty(adminName))
            {
                return Redirect("/Admin/Auth/Login");
            }

            ViewBag.AdminName = adminName;
            return View();
        }
    }
}
