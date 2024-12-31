using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Concrete;
using SignalROnionArchitecture.Application;
using SignalROnionArchitecture.Application.Concrete;
using SignalROnionArchitecture.Application.Services;
using SignalROnionArchitecture.Core.Entities;
using SignalROnionArchitecture.Infrastructure;
using SignalROnionArchitecture.Infrastructure.EntityFramework;
using SignalROnionArchitecture.Presentation.Api.Hubs;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// CORS Ayarlar�
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .SetIsOriginAllowed((host) => true)
               .AllowCredentials();
    });
});

// SignalR
builder.Services.AddSignalR();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// HttpClient DI Tan�m� (BURAYA EKLEY�N)
builder.Services.AddHttpClient();

// AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// JSON Ayarlar�
builder.Services.AddControllersWithViews(opt =>
{
    var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
}).AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Servisler ve Dependency Injection
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IBasketService, BasketManager>();
builder.Services.AddScoped<IBasketDal, EfBasketDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IDiscountService, DiscountManager>();
builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();
builder.Services.AddScoped<IMenuTableService, MenuTableManager>();
builder.Services.AddScoped<IMenuTableDal, EfMenuTableDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
builder.Services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();
builder.Services.AddScoped<INotificationService, NotificationManager>();
builder.Services.AddScoped<INotificationDal, EfNotificationDal>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();
builder.Services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IOrderDal, EfOrderDal>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<ISliderService, SliderManager>();
builder.Services.AddScoped<ISliderDal, EfSliderDal>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cookie Ayarlar� (WebUI i�in)
builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = "/WebUI/Login/Index";
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/WebUI/Home/Error");
    app.UseHsts();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// API ve WebUI i�in route tan�mlar�
app.MapControllers(); // Hem API hem de WebUI i�in Controller tan�mlar�
app.MapHub<SignalRHub>("/signalrhub"); // SignalR Hubs i�in
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // WebUI i�in

app.Run();
