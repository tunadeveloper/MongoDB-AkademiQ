using Microsoft.AspNetCore.Mvc;

namespace MongoDB_AkademiQ.ViewComponents.About
{
    public class _AboutSubscribeComponenPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
