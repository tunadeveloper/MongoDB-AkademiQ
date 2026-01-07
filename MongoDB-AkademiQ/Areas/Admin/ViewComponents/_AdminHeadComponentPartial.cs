using Microsoft.AspNetCore.Mvc;

namespace MongoDB_AkademiQ.Areas.Admin.ViewComponents
{
    public class _AdminHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
