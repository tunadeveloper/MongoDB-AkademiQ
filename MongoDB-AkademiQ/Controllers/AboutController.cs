using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Abouts;
using System.Threading.Tasks;

namespace MongoDB_AkademiQ.Controllers
{
    public class AboutController : Controller
    {
        public async Task<IActionResult> Index(About about)
        {
            return View(about);
        }
    }
}
