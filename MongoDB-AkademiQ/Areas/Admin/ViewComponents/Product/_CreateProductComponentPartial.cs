using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.DTOs.CategoryDTOs;
using MongoDB_AkademiQ.Services.Categories;

namespace MongoDB_AkademiQ.Areas.Admin.ViewComponents.Product
{
    public class _CreateProductComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CreateProductComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }
    }
}
