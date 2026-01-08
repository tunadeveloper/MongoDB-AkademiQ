using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.DTOs.CategoryDTOs;
using MongoDB_AkademiQ.Services.Categories;

namespace MongoDB_AkademiQ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _categoryService.GetAllAsync();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            await _categoryService.CreateAsync(createCategoryDTO);
            return Redirect("/Admin/Category");
        }

        public async Task<IActionResult> UpdateCategory(string id)
        {
            var values = await _categoryService.GetByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            await _categoryService.UpdateAsync(updateCategoryDTO);
            return Redirect("/Admin/Category");
        }

        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteAsync(id);
            return Redirect("/Admin/Category");
        }
    }
}
