using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.DTOs.ProductDTOs;
using MongoDB_AkademiQ.Services.Products;
using MongoDB_AkademiQ.Services.Categories;

namespace MongoDB_AkademiQ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetAllAsync();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            await _productService.CreateAsync(createProductDTO);
            return Redirect("/Admin/Product");
        }

        public async Task<IActionResult> UpdateProduct(string id)
        {
            var values = await _productService.GetByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            await _productService.UpdateAsync(updateProductDTO);
            return Redirect("/Admin/Product");
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteAsync(id);
            return Redirect("/Admin/Product");
        }
    }
}
