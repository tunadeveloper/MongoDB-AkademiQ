using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.Services.Teams;

namespace MongoDB_AkademiQ.ViewComponents.About
{
    public class _AboutTeamComponenPartial:ViewComponent
    {
        private readonly ITeamService _service;

        public _AboutTeamComponenPartial(ITeamService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _service.GetAllAsync();
            return View(values);
        }
    }
}
