using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.Services.Messages;

namespace MongoDB_AkademiQ.Areas.Admin.ViewComponents
{
    public class _AdminSidebarComponentPartial : ViewComponent
    {
        private readonly IMessageService _messageService;

        public _AdminSidebarComponentPartial(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var messages = await _messageService.GetAllAsync();
            var unreadCount = messages.Count(m => !m.IsRead);
            ViewBag.UnreadMessageCount = unreadCount;
            return View();
        }
    }
}
