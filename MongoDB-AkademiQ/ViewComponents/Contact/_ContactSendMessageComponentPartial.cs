using Microsoft.AspNetCore.Mvc;

namespace MongoDB_AkademiQ.ViewComponents.Contact
{
    public class _ContactSendMessageComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
