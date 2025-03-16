var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();//bu bir serves sağlayıcısıdır boş bir ASP.NET Core projesi açtığımız için mvc desteğı aktif et diyoruz tanımı

var app = builder.Build();

app.UseHttpsRedirection();//https ekleriz

app.UseRouting();//yönlendirme işlemi yapar

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}");

// app.MapGet("/", () => "Hello World!");
// app.MapGet("/btk",()=>"Btk Akademi");

app.Run();
