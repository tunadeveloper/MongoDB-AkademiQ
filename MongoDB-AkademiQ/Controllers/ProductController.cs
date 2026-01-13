using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.Services.Products;
using MongoDB_AkademiQ.Services.Categories;

namespace MongoDB_AkademiQ.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(List<string> category,decimal? minPrice,decimal? maxPrice,string sort)
        {
            var categories = await _categoryService.GetAllAsync();
            var values = await _productService.GetFilteredAsync(category, minPrice, maxPrice, sort);
            var categoryProductCounts = await _productService.GetCategoryProductCountsAsync();

            ViewBag.Categories = categories;
            ViewBag.CategoryProductCounts = categoryProductCounts;
            ViewBag.SelectedCategories = category ?? new List<string>();
            ViewBag.SelectedSort = sort ?? "default";
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            ViewBag.ProductCount = values.Count;

            return View(values);
        }
    }
}
