using Microsoft.AspNetCore.Mvc;
using MongoDB_AkademiQ.Services.Categories;
using MongoDB_AkademiQ.Services.Messages;
using MongoDB_AkademiQ.Services.Newsletters;
using MongoDB_AkademiQ.Services.Products;

namespace MongoDB_AkademiQ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMessageService _messageService;
        private readonly INewsletterService _newsletterService;

        public DashboardController(
            IProductService productService,
            ICategoryService categoryService,
            IMessageService messageService,
            INewsletterService newsletterService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _messageService = messageService;
            _newsletterService = newsletterService;
        }

        public async Task<IActionResult> Index()
        {
            var adminName = HttpContext.Session.GetString("AdminName");
            if (string.IsNullOrEmpty(adminName))
            {
                return Redirect("/Admin/Auth/Login");
            }

            var products = await _productService.GetAllAsync();
            var categories = await _categoryService.GetAllAsync();
            var messages = await _messageService.GetAllAsync();
            var newsletters = await _newsletterService.GetAllAsync();

            ViewBag.AdminName = adminName;
            ViewBag.TotalProducts = products.Count;
            ViewBag.TotalCategories = categories.Count;
            ViewBag.TotalMessages = messages.Count;
            ViewBag.TotalNewsletters = newsletters.Count;

            return View();
        }
    }
}
