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
        

        public CartModel(IServiceManager manager)//,Cart cart
                                                
        {
            _manager = manager;
            //Cart = cart; scoped icin yapt�k
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart=HttpContext.Session.GetJson<Cart>("cart")??new Cart();
        }
        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager
                .ProductService
                .GetOneProduct(productId,false);
            if(product is not null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();//cart nesnesine bak�yoruz yoksa olu�turuyoruz
                Cart.AddItem(product,1);//her �r�n eklendiginde bir tana ekle
                HttpContext.Session.SetJson<Cart>("cart", Cart);//ilgili ifadeyi sessiona yaz�yoruz
            }
            return Page();

        }
        public IActionResult OnPostRemove(int id , string returnUrl)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();//cart nesnesine bak�yoruz yoksa olu�turuyoruz
            Cart.RemoveLine(Cart.Lines.First(cl=>cl.Product.ProductId.Equals(id)).Product);
            HttpContext.Session.SetJson<Cart>("cart", Cart);//ilgili ifadeyi sessiona yaz�yoruz
            return Page();
        
        }

    }
}
