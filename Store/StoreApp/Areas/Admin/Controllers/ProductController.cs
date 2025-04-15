using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
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
            ViewBag.Categories =new SelectList(
                _manager.CategoryServic.GetAllCategories(false),"CategoryId","CategoryName","1");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]Product product)
        {
            if (ModelState.IsValid)
            { 
                _manager.ProductService.CreateProduct(product);
                return RedirectToAction("Index");
            
            }
            return View();
        }
        public IActionResult Update([FromRoute(Name ="id")]int id)
        {
            var model=_manager.ProductService.GetOneProduct(id,false);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid) 
            {
                _manager.ProductService.UpdateOneProduct(product);
                return RedirectToAction("Index"); 
            }
            return View();

        }
        [HttpGet]
        public IActionResult Delete([FromRoute(Name ="id")]int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }
    }
}