using Microsoft.AspNetCore.Mvc;

namespace MongoDB_AkademiQ.Areas.Admin.ViewComponents.Category
{
    public class _CreateCategoryComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
