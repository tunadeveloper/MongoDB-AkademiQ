using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.Services.Newsletters;

namespace MongoDB_AkademiQ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsletterController : Controller
    {
        private readonly INewsletterService _newsletterService;

        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _newsletterService.GetAllAsync();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteNewsletter([FromBody] DeleteRequest request)
        {
            try
            {
                await _newsletterService.DeleteAsync(request.Id);
                return Json(new { success = true, message = "Abone başarıyla silindi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        public class DeleteRequest
        {
            public string Id { get; set; }
        }
    }
}
