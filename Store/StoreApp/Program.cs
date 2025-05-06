using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();//bu bir serves sağlayıcısıdır boş bir ASP.NET Core projesi açtığımız için mvc desteğı aktif et diyoruz tanımı

builder.Services.AddRazorPages();

builder.Services.AddDbContext<RepositoryContext>(options =>
{
  options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"), b => b.MigrationsAssembly("StoreApp"));
}); //producter servis sağlayıcı newlenmesini sağladık

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddScoped<IRepositoryManager, RepositoryManger>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryServic, CategoryManager>();

builder.Services.AddSingleton<Cart>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();


app.UseStaticFiles();//static dosyalarda kullanılar
app.UseSession();
app.UseHttpsRedirection();//https ekleriz

app.UseRouting();//yönlendirme işlemi yapar

//app.UseStaticFiles();//resim yapmak için(işe yaramadı)


app.UseEndpoints(endpoints =>
{

  endpoints.MapAreaControllerRoute(
    name:"Admin",
    areaName:"Admin",
    pattern:"Admin/{controller=Dashboard}/{action=Index}/{id?}"
  );

  endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});

app.Run();
// app.MapGet("/", () => "Hello World!");
// app.MapGet("/btk",()=>"Btk Akademi");

