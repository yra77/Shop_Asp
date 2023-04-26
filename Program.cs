

using Shop_Asp.Domain.Repositories.EntityFramework;
using Shop_Asp.Domain.Repositories.Interfaces;
using Shop_Asp.Services;
using Shop_Asp.Domain;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();// options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);


//add services
builder.Services.AddScoped<IBrandsRepository, BrandsRepository>();
builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<DataManager>();


// Add Sql Server.
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection)
                                                                     .EnableSensitiveDataLogging()
                                                                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));


//настраиваем identity систему
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
}).AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

//настраиваем authentication cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "shopAuth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});

//настраиваем политику авторизации для Admin area
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
});

//добавляем сервисы для контроллеров и представлений (MVC)
builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute( "default", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute("admin", "{controller=Home}/{action=Index}/{id?}");
//app.MapControllerRoute("adminShop", "{area:exists}/{controller=ShopModels}/{action=Index}/{id?}");

app.Run();
