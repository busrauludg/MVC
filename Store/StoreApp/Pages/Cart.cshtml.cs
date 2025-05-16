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
        public Cart Cart { get; set; }//�oc
        public string ReturnUrl { get; set; } = "/";
        

        public CartModel(IServiceManager manager,Cart cartService)//enjeksiyonu burda yapt�k
                                                
        {
            _manager = manager;
            Cart = cartService; //scoped icin yapt�k
        }
        //bunlar� yap�nca a�a��daki bir cok yere gerek kalmad�
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
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();//cart nesnesine bak�yoruz yoksa olu�turuyoruz bunada gerek yok
                Cart.AddItem(product,1);//her �r�n eklendiginde bir tana ekle
               // HttpContext.Session.SetJson<Cart>("cart", Cart);//ilgili ifadeyi sessiona yaz�yoruz bunada
            }
            return RedirectToPage(new {returnUrl=returnUrl});

        }
        public IActionResult OnPostRemove(int id , string returnUrl)
        {
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();//cart nesnesine bak�yoruz yoksa olu�turuyoruz bu ve 
            Cart.RemoveLine(Cart.Lines.First(cl=>cl.Product.ProductId.Equals(id)).Product);
           // HttpContext.Session.SetJson<Cart>("cart", Cart);//ilgili ifadeyi sessiona yaz�yoruz bunada
            return Page();
        
        }

    }
}
