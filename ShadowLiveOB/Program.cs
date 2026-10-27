using Microsoft.EntityFrameworkCore;
using ShadowLiveOB.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add MVC and SignalR for Live
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ObHub>("/obHub");

app.Run();