using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.Services.Products;

namespace MongoDB_AkademiQ.ViewComponents.Home
{
    public class _HomeTrendingProductsComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _HomeTrendingProductsComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productService.GetAllAsync();
            var trendingProducts = products.Where(p => p.IsPopular).Take(10).ToList();
            return View(trendingProducts);
        }
    }
}
