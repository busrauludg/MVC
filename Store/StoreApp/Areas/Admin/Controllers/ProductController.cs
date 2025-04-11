using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;//artık servis odaklı çalışıyoruz

        public ProductController(IServiceManager manager)//enjekte ettik
        {
            _manager = manager;
        }

        public IActionResult Index()
        {   var model=_manager.ProductService.GetAllProducts(false);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]Product product)
        {
            return View();
        }
    }
}