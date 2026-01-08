using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.Services.Products;
using System.Threading.Tasks;

namespace MongoDB_AkademiQ.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetAllAsync();
            return View(values);
        }
    }
}
