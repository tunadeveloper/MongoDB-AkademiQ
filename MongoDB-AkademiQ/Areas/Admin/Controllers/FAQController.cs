using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.DTOs.FAQDTOs;
using MongoDB_AkademiQ.Services.FAQs;

namespace MongoDB_AkademiQ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FAQController : Controller
    {
        private readonly IFAQService _faqService;

        public FAQController(IFAQService faqService)
        {
            _faqService = faqService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _faqService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetFAQDetails(string id)
        {
            try
            {
                var faq = await _faqService.GetByIdAsync(id);
                if (faq == null)
                {
                    return Json(new { success = false, message = "SSS bulunamadı!" });
                }

                return Json(new
                {
                    success = true,
                    faq = new
                    {
                        id = faq.Id,
                        question = faq.Question,
                        answer = faq.Answer
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFAQ([FromBody] CreateFAQDTO model)
        {
            try
            {
                await _faqService.CreateAsync(model);
                return Json(new { success = true, message = "SSS başarıyla eklendi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFAQ([FromBody] UpdateFAQDTO model)
        {
            try
            {
                await _faqService.UpdateAsync(model);
                return Json(new { success = true, message = "SSS başarıyla güncellendi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFAQ([FromBody] DeleteRequest request)
        {
            try
            {
                await _faqService.DeleteAsync(request.Id);
                return Json(new { success = true, message = "SSS başarıyla silindi!" });
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
