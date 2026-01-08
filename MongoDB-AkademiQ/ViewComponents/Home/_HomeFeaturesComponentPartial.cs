using Microsoft.AspNetCore.Mvc;

namespace MongoDB_AkademiQ.ViewComponents.Home
{
    public class _HomeFeaturesComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
