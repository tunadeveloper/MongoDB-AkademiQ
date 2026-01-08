using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.Services.Categories;
using System.Threading.Tasks;

namespace MongoDB_AkademiQ.ViewComponents.Home
{
    public class _HomeCategoryListComponentPartial:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _HomeCategoryListComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllAsync();
            return View(values);
        }
    }
}
