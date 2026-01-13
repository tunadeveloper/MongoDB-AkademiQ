using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.Services.Products;
using System.Threading.Tasks;

namespace MongoDB_AkademiQ.ViewComponents.Product
{
    public class _ProductFourListComponentPartial:ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductFourListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllAsync();
            return View(values);
        }
    }
}
