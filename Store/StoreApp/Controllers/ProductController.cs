using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;


namespace StoreApp.Controllers
{
    public class ProductController:Controller
    {

        /************Uzun Yol***************/
        // public IEnumerable<Product>Index()
        // {
        //     var context=new RepositoryContext(
        //         new DbContextOptionsBuilder<RepositoryContext>()
        //         .UseSqlite("Data Source= C:\\Users\\Büşra\\Documents\\GitHub\\MVC\\ProductDb.db")
        //         .Options);// contexe erişim sağlanır
        //     //veriler burdan ulaşır
        //     //eğer ropositorycontext döndürmek istiyorsak dbcontexoptions ile dönüş yapmamız lazım

        //     return context.Products;

        //     // return new List<Product>()
        //     // {
        //     //     new Product(){ProductId=1,ProductName="Computer",Price=5}
        //     // };
        // }


/************Burdan devam et***************/
        private readonly IServiceManager _manager;//parap fiel tanımı

        public ProductController(IServiceManager  manager)
        {
            _manager = manager; //burası gibi
        }
        //yapıcı metot sayesinde RepositoryContext enjekte edilmesini sağladım

        //RepositoryContext e ihtiyacımız varsa bir serves araya giricek program.cs de böyle bir tanım vardı o serces devreye girince bağlatı dizesi otomatik oluşturucak  ve bizim yukarıda yaptığımız gibi newlicek ve bize kullanabiliceğimiz bir contex ifadesi verice

        public IActionResult Index()//product erişim sağlanır
        {
            var model=_manager.ProductService.GetAllProducts(false);
            return View(model);
        }
        public IActionResult Get([FromRoute(Name ="id")]int id)
        {
            // Product product=_contex.Products.First(p=>p.ProductId.Equals(id));
            var model=_manager.ProductService.GetOneProduct(id,false);//interfave te olmadığı için göremiyorum
           return View(model);
        }
    }

}