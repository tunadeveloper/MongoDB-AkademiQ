using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.DTOs.ContactInfoDTOs;
using MongoDB_AkademiQ.Services.ContactInfos;

namespace MongoDB_AkademiQ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _contactInfoService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetContactDetails(string id)
        {
            try
            {
                var contact = await _contactInfoService.GetByIdAsync(id);
                if (contact == null)
                {
                    return Json(new { success = false, message = "İletişim bilgisi bulunamadı!" });
                }

                return Json(new
                {
                    success = true,
                    contact = new
                    {
                        id = contact.Id,
                        address = contact.Address,
                        phoneNumber = contact.PhoneNumber,
                        email = contact.Email
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactInfoDTO model)
        {
            try
            {
                await _contactInfoService.CreateAsync(model);
                return Json(new { success = true, message = "İletişim bilgisi başarıyla eklendi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContactInfoDTO model)
        {
            try
            {
                await _contactInfoService.UpdateAsync(model);
                return Json(new { success = true, message = "İletişim bilgisi başarıyla güncellendi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContact([FromBody] DeleteRequest request)
        {
            try
            {
                await _contactInfoService.DeleteAsync(request.Id);
                return Json(new { success = true, message = "İletişim bilgisi başarıyla silindi!" });
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
