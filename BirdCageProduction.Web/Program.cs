using BusinessLogic.Constant.StatusConstant;
using BusinessLogic.Service.Abstraction;
using BusinessLogic.Service.Implementation;
using BusinessLogic.Constant.StatusConstant;
using DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Repository.Repositories;
using Repository.UnitOfWork;
using BusinessLogic.Models.Part;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// DbContext
builder.Services.AddDbContext<BirdCageProductionContext>(option
    => option.UseSqlServer(builder.Configuration.GetConnectionString("BirdCageProduction")));

// DI Container
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
 // Repository
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IAccountStatusRepository, AccountStatusRepository>();
builder.Services.AddTransient<IPartRepository, PartRepository>();
builder.Services.AddTransient<IColorRepository, ColorRepository>();
 // Service
builder.Services.AddTransient<IAuthService, AuthService>(); 
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IPartService, PartService>();
builder.Services.AddTransient<IStatusConstant, StatusConstant>();
builder.Services.AddTransient<IColorService, ColorService>();

// Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
        options.LoginPath = "/Login";
    });
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 

// Other
builder.Configuration.AddJsonFile("bird_cage_parts_option.json", true, true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();




System.Diagnostics.Debug.WriteLine("hello world!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
app.Run();



