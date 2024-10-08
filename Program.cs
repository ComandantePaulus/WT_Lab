using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WT_Lab.Components;
using WT_Lab.Data;
using WT_Lab.Services;
using WT_Lab.TagHelpers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// ����������� ������� MemoryAssetService
builder.Services.AddScoped<ICategoryService,MemoryCategoryService>();
// ����������� ������� MemoryAssetService
builder.Services.AddScoped<IAssetService,MemoryAssetService>();
//��� ��������� ������ �������� RazorPages
builder.Services.AddHttpContextAccessor();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("admin", p =>
    p.RequireClaim(ClaimTypes.Role, "admin"));
});
builder.Services.AddSingleton<IEmailSender, NoOpEmailSender>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

//await DBInit.SetupIdentityAdmin(app);

app.Run();
