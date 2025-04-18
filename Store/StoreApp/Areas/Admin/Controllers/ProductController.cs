using Entities.Dtos;
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
            ViewBag.Categories = GetCategoriesSelectedList();
                 return View();
        }

        private SelectList GetCategoriesSelectedList()
        {
            return new SelectList(_manager.CategoryServic.GetAllCategories(false),
            "CategoryId", 
            "CategoryName", "1");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]ProductDtoForInsertion productDto)
        {
            if (ModelState.IsValid)
            { 
                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
            
            }
            return View();
        }
        public IActionResult Update([FromRoute(Name ="id")]int id)
        {
            ViewBag.Categories = GetCategoriesSelectedList();
            var model=_manager.ProductService.GetOneProductForUpdate(id ,false);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm]ProductDtoForUpdate product)
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