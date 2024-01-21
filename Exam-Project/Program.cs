using Exam_Project.Context;
using Exam_Project.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BoocicDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<BoocicDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Service}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


PathConstants.RootPath = builder.Environment.WebRootPath;

app.Run();
