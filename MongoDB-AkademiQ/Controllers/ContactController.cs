using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.DTOs.MessageDTOs;
using MongoDB_AkademiQ.Services.Messages;
using System.Threading.Tasks;

namespace MongoDB_AkademiQ.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMessageService _messageService;

        public ContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDTO createMessageDTO)
        {
            if (ModelState.IsValid)
            {
                await _messageService.CreateAsync(createMessageDTO);
                TempData["MessageSuccess"] = "Mesajınız iletilmiştir, en kısa sürede sizlerle iletişime geçeceğiz!";
            }
            else
            {
                TempData["MessageError"] = "Lütfen tüm alanları doldurun.";
            }
            return RedirectToAction("Index");
        }
    }
}
