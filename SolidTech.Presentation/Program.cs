
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

//Servislerin tanýmlandýðý yer burasý


builder.Services.AddBusinessServices();//Servis Injections
builder.Services.AddAutoMapper(); //AutoMapper Injections

builder.Services.AddControllersWithViews();//Uygulamada Controller ve View yapýsnýn kullanabilmek için bu servisi ekliyoruz 

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(c =>
    {
        c.LoginPath = "/Admin/Auth";
        c.AccessDeniedPath = "/Admin/Auth/AccessDenied";
    }
    );
//appsetings.json 'dan Connection bilgilerini al ve Data katmanýndaki Constructor'a aktar
//builder.Services.AddDbContext<SolidTechContext>(options =>
//{
//    options.UseSqlServer("Server=.;Database=SolidTechDb;Trusted_Connection=True;Encrypt=False");
//});

builder.Services.AddDbContext<SolidTechContext>();

var app = builder.Build();

app.UseStatusCodePagesWithReExecute("/ErrorPages/{0}");

app.UseStaticFiles();//Uygulamada "wwwroot" klasörü altýnda static dosyalarý kullanabilmek için ekliyoruz(css,js,images)


app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(name: "admin_default",
                       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(name: "default",
                       pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
