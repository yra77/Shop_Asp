

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
//.AddRazorOptions(options =>
// {
//     options.ViewLocationFormats.Add("~/Views/Shared/Components/{0}/{0}.cshtml");
// });

//add services
builder.Services.AddScoped<IBrandsRepository, BrandsRepository>();
builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ICartsRepository, CartsRepository>();
builder.Services.AddScoped<DataManager>();


// Add Sql Server.
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection)
                                                                     .EnableSensitiveDataLogging()
                                                                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true);
//                                                              .AddEntityFrameworkStores<ApplicationContext>();


//builder.Services.Configure<SecurityStampValidatorOptions>(options =>
//{
//    options.ValidationInterval = TimeSpan.FromMinutes(10);
//});


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = false;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = "ShopLogin";
});
//����������� identity �������
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
{
   // opts.SignIn.RequireConfirmedAccount = true;
    opts.User.RequireUniqueEmail = false;
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
}).AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

//����������� authentication cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "shopAuth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});

//����������� �������� ����������� ��� Admin area
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
  //  x.AddPolicy("IdentityArea", policy => { policy.RequireRole("user"); });
});

//��������� ������� ��� ������������ � ������������� (MVC)
builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
   // x.Conventions.Add(new AdminAreaAuthorization("Identity", "IdentityArea"));
});


builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.UseSession();
app.MapControllerRoute("identity", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute("admin", "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute("default", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
