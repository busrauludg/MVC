using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructe.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
        public Cart Cart { get; set; }//ýoc
        public string ReturnUrl { get; set; } = "/";
        

        public CartModel(IServiceManager manager,Cart cartService)//enjeksiyonu burda yaptýk
                                                
        {
            _manager = manager;
            Cart = cartService; //scoped icin yaptýk
        }
        //bunlarý yapýnca aþaðýdaki bir cok yere gerek kalmadý
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart=HttpContext.Session.GetJson<Cart>("cart")??new Cart(); bunu
        }
        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager
                .ProductService
                .GetOneProduct(productId,false);
            if(product is not null)
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();//cart nesnesine bakýyoruz yoksa oluþturuyoruz bunada gerek yok
                Cart.AddItem(product,1);//her ürün eklendiginde bir tana ekle
               // HttpContext.Session.SetJson<Cart>("cart", Cart);//ilgili ifadeyi sessiona yazýyoruz bunada
            }
            return RedirectToPage(new {returnUrl=returnUrl});

        }
        public IActionResult OnPostRemove(int id , string returnUrl)
        {
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();//cart nesnesine bakýyoruz yoksa oluþturuyoruz bu ve 
            Cart.RemoveLine(Cart.Lines.First(cl=>cl.Product.ProductId.Equals(id)).Product);
           // HttpContext.Session.SetJson<Cart>("cart", Cart);//ilgili ifadeyi sessiona yazýyoruz bunada
            return Page();
        
        }

    }
}
