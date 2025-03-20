using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();//bu bir serves sağlayıcısıdır boş bir ASP.NET Core projesi açtığımız için mvc desteğı aktif et diyoruz tanımı

builder.Services.AddDbContext<RepositoryContext>(options=>
{
  options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"));
}); //producter servis sağlayıcı newlenmesini sağladık

var app = builder.Build();

app.UseStaticFiles();//static dosyalarda kullanılar
app.UseHttpsRedirection();//https ekleriz

app.UseRouting();//yönlendirme işlemi yapar

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}");

// app.MapGet("/", () => "Hello World!");
// app.MapGet("/btk",()=>"Btk Akademi");

app.Run();
