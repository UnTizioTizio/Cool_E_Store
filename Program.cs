using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CoolEStore.Data;
using CoolEStore.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("AppDbContext") 
        ?? 
        throw new InvalidOperationException("Connection string 'AppDbContext' not found.")
));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Authentication
builder.Services.AddAuthentication();

// Add Identity APIs
builder.Services
    .AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<AppDbContext>();



var app = builder.Build();

// Seed Database
using (var appDbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>())
{
    appDbContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapIdentityApi<IdentityUser>();

app.Run();
