using BusinessLogic.AutoMappers;
using BusinessLogic.Constant.StatusConstant;
using BusinessLogic.Service.Abstraction;
using BusinessLogic.Service.Implementation;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Repository.Repositories;
using Repository.UnitOfWork;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// DbContext
//builder.Services.AddDbContext<BirdCageProductionContext>(option
//    => option.UseSqlServer(builder.Configuration.GetConnectionString("BirdCageProduction")));
builder.Services.AddDbContext<BirdCageProductionContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("BirdCageProduction")),
    ServiceLifetime.Transient);

// DI Container
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
// Repository
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IAccountStatusRepository, AccountStatusRepository>();
builder.Services.AddTransient<IBirdCageRepository, BirdCageRepository>();
builder.Services.AddTransient<IColorRepository, ColorRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomerStatusRepository, CustomerStatusRepository>();
builder.Services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderStatusRepository, OrderStatusRepository>();
builder.Services.AddTransient<IPartItemRepository, PartItemRepository>();
builder.Services.AddTransient<IPartRepository, PartRepository>();
builder.Services.AddTransient<IProcedureRepository, ProcedureRepository>();
builder.Services.AddTransient<IProcedureStepRepository, ProcedureStepRepository>();
builder.Services.AddTransient<IProgressRepository, ProgressRepository>();
builder.Services.AddTransient<IProgressStatusRepository, ProgressStatusRepository>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();


// Service
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IPartService, PartService>();
builder.Services.AddTransient<IStatusConstant, StatusConstant>();
builder.Services.AddTransient<IColorService, ColorService>();
builder.Services.AddTransient<IBirdCageService, BirdCageService>();
builder.Services.AddTransient<IPartItemService, PartItemSerivce>();


//AutoMapper
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper
(typeof(AutoMapperProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
