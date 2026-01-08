using Microsoft.AspNetCore.Mvc;

namespace MongoDB_AkademiQ.ViewComponents.Layout
{
    public class _LayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
