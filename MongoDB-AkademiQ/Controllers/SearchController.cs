using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.Services.Products;

namespace MongoDB_AkademiQ.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductService _productService;

        public SearchController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(string q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return View(new List<DTOs.ProductDTOs.ResultProductDTO>());
            }

            var results = await _productService.SearchAsync(q);
            ViewBag.SearchTerm = q;
            return View(results);
        }
    }
}
