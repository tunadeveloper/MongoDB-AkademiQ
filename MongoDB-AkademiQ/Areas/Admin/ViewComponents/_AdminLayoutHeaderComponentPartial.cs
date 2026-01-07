using Microsoft.AspNetCore.Mvc;

namespace MongoDB_AkademiQ.Areas.Admin.ViewComponents
{
    public class _AdminLayoutHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
