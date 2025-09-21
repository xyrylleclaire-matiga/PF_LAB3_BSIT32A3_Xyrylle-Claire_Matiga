using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PF_LAB3_BSIT32A3_Xyrylle_Claire_Matiga.Data;
using PF_LAB3_BSIT32A3_Xyrylle_Claire_Matiga.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register GreedDbContext for your Cards system
builder.Services.AddDbContext<GreedDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GreedConnection")));

// Register ApplicationDbContext for Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContextConnection")));

// Add ASP.NET Core Identity
// ✅ CORRECTED: Use your custom ApplicationUser model here
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // disable email confirm for now
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// Add Razor Pages support
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Must come before Authorization
app.UseAuthorization();

// Map your custom controller routes
app.MapControllerRoute(
    name: "account",
    pattern: "Account/{action=Login}/{id?}",
    defaults: new { controller = "Account", action = "Login" }
);

// Map the default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Identity Razor Pages
app.MapRazorPages();

app.Run();