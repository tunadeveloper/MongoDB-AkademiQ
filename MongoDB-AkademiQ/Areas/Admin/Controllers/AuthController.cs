using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.DTOs.AdminDTOs;
using MongoDB_AkademiQ.Services.Admin;

namespace MongoDB_AkademiQ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly IAdminService _adminService;

        public AuthController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var admin = await _adminService.ValidateAsync(username, password);
            
            if (admin != null)
            {
                HttpContext.Session.SetString("AdminId", admin.Id);
                HttpContext.Session.SetString("AdminName", admin.NameSurname);
                return Redirect("/Admin/Dashboard/Index");
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateAdminDTO model)
        {
            model.IsVerified = false;
            await _adminService.CreateAsync(model);
            return Redirect("/Admin/Auth/Login");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Admin/Auth/Login");
        }
    }
}
