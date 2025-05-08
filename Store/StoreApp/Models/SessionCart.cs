using Entities.Models;
using StoreApp.Infrastructe.Extensions;
using System.Text.Json.Serialization;


namespace StoreApp.Models
{
    public class SessionCart:Cart
    {
        [JsonIgnore] //deasilyoz aşamasında dikkate alınmamasını görmezden gel diyo
        public ISession? Session { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession? session=services.GetRequiredService<IHttpContextAccessor>()
                .HttpContext?.Session;
            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);//product ve guantity bağlı olarak add item yapıyo
            Session?.SetJson<SessionCart>("cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session?.Remove("cart");//cart mbilgisini sessiondan sildik
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session?.SetJson<SessionCart>("cart",this);
        }

    }
}
