using Microsoft.AspNetCore.Mvc;

namespace MongoDB_AkademiQ.ViewComponents.Home
{
    public class _HomeDiscountComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
