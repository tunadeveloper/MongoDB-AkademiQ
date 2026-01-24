using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.DTOs.ReferenceDTOs;
using MongoDB_AkademiQ.Services.References;

namespace MongoDB_AkademiQ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReferenceController : Controller
    {
        private readonly IReferenceService _referenceService;

        public ReferenceController(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("AdminId") == null)
            {
                return Redirect("/Admin/Auth/Login");
            }
            var values = await _referenceService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetReferenceDetails(string id)
        {
            try
            {
                var reference = await _referenceService.GetByIdAsync(id);
                if (reference == null)
                {
                    return Json(new { success = false, message = "Referans bulunamadı!" });
                }

                return Json(new
                {
                    success = true,
                    reference = new
                    {
                        id = reference.Id,
                        companyName = reference.CompanyName,
                        logoUrl = reference.LogoUrl,
                        description = reference.Description
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReference(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return Json(new { success = false, message = "Geçersiz referans ID'si!" });
                }
                await _referenceService.DeleteAsync(id);
                return Json(new { success = true, message = "Referans başarıyla silindi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReference([FromBody] CreateReferenceDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "Lütfen tüm alanları doldurun!" });
                }
                await _referenceService.CreateAsync(model);
                return Json(new { success = true, message = "Referans başarıyla eklendi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReference([FromBody] UpdateReferenceDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "Lütfen tüm alanları doldurun!" });
                }
                await _referenceService.UpdateAsync(model);
                return Json(new { success = true, message = "Referans başarıyla güncellendi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }
    }
}
