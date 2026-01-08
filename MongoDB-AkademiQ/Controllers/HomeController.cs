using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.DTOs.NewsletterDTOs;
using MongoDB_AkademiQ.Models;
using MongoDB_AkademiQ.Services.Newsletters;

namespace MongoDB_AkademiQ.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsletterService _newsletterService;

        public HomeController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubscribeNewsletter(CreateNewsletterDTO createNewsletterDTO)
        {
            if (ModelState.IsValid)
            {
                await _newsletterService.CreateAsync(createNewsletterDTO);
                TempData["NewsletterSuccess"] = "Başarıyla abone oldunuz!";
            }
            else
            {
                TempData["NewsletterError"] = "Lütfen geçerli bir e-posta adresi girin.";
            }
            return RedirectToAction("Index");
        }
    }
}
