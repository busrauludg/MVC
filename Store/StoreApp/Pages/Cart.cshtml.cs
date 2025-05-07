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
        

        public CartModel(IServiceManager manager)//,Cart cart
                                                
        {
            _manager = manager;
            //Cart = cart; scoped icin yaptýk
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
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();//cart nesnesine bakýyoruz yoksa oluþturuyoruz
                Cart.AddItem(product,1);//her ürün eklendiginde bir tana ekle
                HttpContext.Session.SetJson<Cart>("cart", Cart);//ilgili ifadeyi sessiona yazýyoruz
            }
            return Page();

        }
        public IActionResult OnPostRemove(int id , string returnUrl)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();//cart nesnesine bakýyoruz yoksa oluþturuyoruz
            Cart.RemoveLine(Cart.Lines.First(cl=>cl.Product.ProductId.Equals(id)).Product);
            HttpContext.Session.SetJson<Cart>("cart", Cart);//ilgili ifadeyi sessiona yazýyoruz
            return Page();
        
        }

    }
}
