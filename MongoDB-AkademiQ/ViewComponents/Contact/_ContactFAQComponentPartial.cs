using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.Services.FAQs;
using System.Threading.Tasks;

namespace MongoDB_AkademiQ.ViewComponents.Contact
{
    public class _ContactFAQComponentPartial:ViewComponent
    {
        private readonly IFAQService _fAQService;

        public _ContactFAQComponentPartial(IFAQService fAQService)
        {
            _fAQService = fAQService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _fAQService.GetAllAsync();
            return View(values);
        }
    }
}
