using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.ContactInfos;

namespace MongoDB_AkademiQ.ViewComponents.Contact
{
    public class _ContactInfoComponentPartial:ViewComponent
    {
        private readonly IContactInfoService _contactInfoService;

        public _ContactInfoComponentPartial(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _contactInfoService.GetAllAsync();
            var result = list.FirstOrDefault();

            return View(result);
        }
    }
}
