using Microsoft.Extensions.Options;
using MongoDB_AkademiQ.Services.Abouts;
using MongoDB_AkademiQ.Services.Admin;
using MongoDB_AkademiQ.Services.Categories;
using MongoDB_AkademiQ.Services.ContactInfos;
using MongoDB_AkademiQ.Services.FAQs;
using MongoDB_AkademiQ.Services.Messages;
using MongoDB_AkademiQ.Services.Newsletters;
using MongoDB_AkademiQ.Services.Products;
using MongoDB_AkademiQ.Services.References;
using MongoDB_AkademiQ.Services.Teams;
using MongoDB_AkademiQ.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<INewsletterService, NewsletterService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactInfoService, ContactInfoService>();
builder.Services.AddScoped<IFAQService, FAQService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IReferenceService, ReferenceService>();
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
