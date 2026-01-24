using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.DTOs.AboutDTOs;
using MongoDB_AkademiQ.Services.Abouts;

namespace MongoDB_AkademiQ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _aboutService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetAboutDetails(string id)
        {
            try
            {
                var about = await _aboutService.GetByIdAsync(id);
                if (about == null)
                {
                    return Json(new { success = false, message = "Hakkımızda bulunamadı!" });
                }

                return Json(new
                {
                    success = true,
                    about = new
                    {
                        id = about.Id,
                        title = about.Title,
                        description = about.ShortDescription
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout([FromBody] CreateAboutDTO model)
        {
            try
            {
                await _aboutService.CreateAsync(model);
                return Json(new { success = true, message = "Hakkımızda başarıyla eklendi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout([FromBody] UpdateAboutDTO model)
        {
            try
            {
                await _aboutService.UpdateAsync(model);
                return Json(new { success = true, message = "Hakkımızda başarıyla güncellendi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAbout([FromBody] DeleteRequest request)
        {
            try
            {
                await _aboutService.DeleteAsync(request.Id);
                return Json(new { success = true, message = "Hakkımızda başarıyla silindi!" });
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
