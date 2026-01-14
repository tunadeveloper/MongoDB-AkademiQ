using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.Services.Messages;

namespace MongoDB_AkademiQ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _messageService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetMessageDetails(string id)
        {
            var message = await _messageService.GetByIdAsync(id);
            if (message == null)
            {
                return Json(new { success = false, message = "Mesaj bulunamadı!" });
            }

            // Mesajı okundu olarak işaretle
            if (!message.IsRead)
            {
                message.IsRead = true;
                await _messageService.UpdateAsync(message);
            }

            return Json(new { 
                success = true, 
                message = new {
                    id = message.Id,
                    name = message.Name,
                    surname = message.Surname,
                    email = message.Email,
                    subject = message.Subject,
                    content = message.Content,
                    sendDate = message.SendDate.ToString("dd.MM.yyyy HH:mm"),
                    isRead = message.IsRead
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMessage([FromBody] DeleteMessageRequest request)
        {
            try
            {
                await _messageService.DeleteAsync(request.Id);
                TempData["Success"] = "Mesaj başarıyla silindi!";
                return Json(new { success = true, message = "Mesaj başarıyla silindi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        public class DeleteMessageRequest
        {
            public string Id { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsRead(string id)
        {
            try
            {
                var message = await _messageService.GetByIdAsync(id);
                if (message != null)
                {
                    message.IsRead = true;
                    await _messageService.UpdateAsync(message);
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }
    }
}
