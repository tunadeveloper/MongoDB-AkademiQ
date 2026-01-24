using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.DTOs.ContactInfoDTOs;
using MongoDB_AkademiQ.Services.ContactInfos;

namespace MongoDB_AkademiQ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactInfoController : Controller
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("AdminId") == null)
            {
                return Redirect("/Admin/Auth/Login");
            }
            var values = await _contactInfoService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetContactInfoDetails(string id)
        {
            try
            {
                var contactInfo = await _contactInfoService.GetByIdAsync(id);
                if (contactInfo == null)
                {
                    return Json(new { success = false, message = "İletişim bilgisi bulunamadı!" });
                }

                return Json(new
                {
                    success = true,
                    contactInfo = new
                    {
                        id = contactInfo.Id,
                        address = contactInfo.Address,
                        phoneNumber = contactInfo.PhoneNumber,
                        email = contactInfo.Email
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContactInfo(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return Json(new { success = false, message = "Geçersiz iletişim bilgisi ID'si!" });
                }
                await _contactInfoService.DeleteAsync(id);
                return Json(new { success = true, message = "İletişim bilgisi başarıyla silindi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactInfo([FromBody] CreateContactInfoDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "Lütfen tüm alanları doldurun!" });
                }
                await _contactInfoService.CreateAsync(model);
                return Json(new { success = true, message = "İletişim bilgisi başarıyla eklendi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContactInfo([FromBody] UpdateContactInfoDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "Lütfen tüm alanları doldurun!" });
                }
                await _contactInfoService.UpdateAsync(model);
                return Json(new { success = true, message = "İletişim bilgisi başarıyla güncellendi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }
    }
}
