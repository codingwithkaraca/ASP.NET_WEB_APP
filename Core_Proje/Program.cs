using DataAccessLayer.Concretes;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<WriterUser, WriterRole>().AddEntityFrameworkStores<Context>();

// ders 26 proje seviyesinde authorize

builder.Services.AddMvc(config =>
{
    //burda authenticationu zorunlu kılmak istiyoruz
    var policy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()// burda sisteme authentike olmuş kullanıcı olmasını istiyoruz
            .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();
/*builder.Services.AddAuthentication(
        CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(x =>
        {
            x.LoginPath = "/AdminLogin/Index/";
        });*/
builder.Services.ConfigureApplicationCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
        options.AccessDeniedPath = "/ErrorPage/Index";
        options.LoginPath = "/Writer/Login/Index/";
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// bu bizim projemizde son kullanıcı geçersiz bir sayfa linkine gitmek istediğinde
// anlamlı bir 404 sayfası göstermek için
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");


app.Run();